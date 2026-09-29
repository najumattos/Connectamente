using AutoMapper;
using Connectamente.API.DTOs.TratamentoAnteriorDto;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;

namespace Connectamente.API.Services;

public class TratamentoAnteriorService(
    ITratamentoAnteriorRepository repository,
    IProntuarioRepository prontuarioRepository,
    IMapper mapper,
    ILogger<TratamentoAnteriorService> logger) : ITratamentoAnteriorService
{
    public async Task<Result> EditarTratamentoAnteriorAsync(TratamentoAnteriorDetalhesDto dto)
    {
        if (dto == null) return Result.Fail("Os dados para atualização não foram informados.");

        // Regra de Negócio: Se houve internação, o motivo torna-se obrigatório
        if (dto.Internacao && string.IsNullOrWhiteSpace(dto.MotivoInternacao))
        {
            return Result.Fail("O motivo da internação deve ser obrigatoriamente preenchido quando há histórico de internação.");
        }
        try
        {
            var tratamento = await repository.BuscarDetalhesAsync(dto.Id);
            if (tratamento == null)
            {
                return Result.Fail("O registro de tratamento anterior não foi localizado no sistema.");
            }
            var motivoFinal = dto.Internacao ? dto.MotivoInternacao?.Trim() : null;

            tratamento.Internacao = dto.Internacao;
            tratamento.MotivoInternacao = motivoFinal;
            tratamento.Observacoes = dto.Observacoes?.Trim();
            tratamento.TipoTratamento = dto.TipoTratamento;

            tratamento.DataAtualizacao = DateTime.UtcNow;

            await repository.EditarAsync(tratamento);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro crítico de infraestrutura ao atualizar o tratamento ID: {Id}", dto.Id);
            return Result.Fail("Ocorreu uma falha interna ao salvar as alterações do tratamento.");
        }
    }


    public async Task<Result<TratamentoAnteriorDetalhesDto>> BuscarTratamentoAnteriorPorIdAsync(int id)
    {
        if (id <= 0) return Result.Fail("Tratamento anterior inválido ou não informado.");

        try
        {
            var response = await repository.BuscarDetalhesAsync(id);
            if (response == null)
            {
                return Result.Fail("Tratamento anterior não encontrado.");
            }
            return Result.Ok(mapper.Map<TratamentoAnteriorDetalhesDto>(response));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar tratamento anterior pelo ID: {Id}", id);
            return Result.Fail("Não foi possível obter os detalhes do tratamento.");
        }

    }

    public async Task<Result> DeletarTratamentoAnteriorAsync(int id)
    {
        if (id <= 0)
            return Result.Fail("O identificador do tratamento anterior é inválido.");
        try
        {
            var tratamento = await repository.BuscarDetalhesAsync(id);
            if (tratamento == null)
            {
                return Result.Fail("Tratamento anterior não encontrado para exclusão.");
            }

            // 2. Passa o objeto anexado/rastreado para o Delete, evitando novas queries desnecessárias
            await repository.ExcluirAsync(tratamento.Id);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro de infraestrutura ao excluir tratamento anterior pelo ID: {Id}", id);
            return Result.Fail($"Falha interna ao processar a exclusão do tratamento anterior: {ex.Message}");
        }
    }

    public async Task<Result> AdicionarTratamentoAnteriorAsync(TratamentoAnteriorAdicionarDto dto)
    {
        if (dto == null)
            return Result.Fail("Tratamento inválido ou não informado.");
        if (!dto.Internacao)
            dto.MotivoInternacao = null;
        bool prontuarioExiste = await prontuarioRepository.ExisteProntuarioAsync(dto.ProntuarioId);
        if (!prontuarioExiste)
        {
            return Result.Fail($"Operação abortada: O prontuário com ID {dto.ProntuarioId} não foi encontrado.");
        }
        try
        {
            var tratamentoEntidade = mapper.Map<TratamentoAnteriorModel>(dto);
            await repository.AdicionarAsync(tratamentoEntidade);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro de infraestrutura ao tentar adicionar tratamento no banco de dados. ProntuarioId: {ProntuarioId}", dto.ProntuarioId);
            return Result.Fail("Não foi possível salvar o tratamento anterior devido a uma falha interna no servidor.");
        }
    }
}