using AutoMapper;
using Connectamente.API.DTOs.FamiliarDto;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;

namespace Connectamente.API.Services;

public class FamiliarService(IFamiliarRepository repository,
IProntuarioRepository prontuarioRepository,
 IMapper mapper,
    ILogger<FamiliarService> logger) : IFamiliarService
{
   public async Task<Result> AdicionarFamiliarAsync(FamiliarAdicionarDto dto)
    {
        if (dto == null)
            return Result.Fail("Tratamento inválido ou não informado.");      
        bool prontuarioExiste = await prontuarioRepository.ExisteProntuarioAsync(dto.ProntuarioId);
        if (!prontuarioExiste)
        {
            return Result.Fail($"Operação abortada: O prontuário com ID {dto.ProntuarioId} não foi encontrado.");
        }
        try
        {
            var familiarEntidade = mapper.Map<FamiliarModel>(dto);
            await repository.AdicionarAsync(familiarEntidade);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro de infraestrutura ao tentar adicionar familiar no banco de dados. ProntuarioId: {ProntuarioId}", dto.ProntuarioId);
            return Result.Fail("Não foi possível salvar o familiar devido a uma falha interna no servidor.");
        }
    }

    public async Task<Result<FamiliarDetalhesDto>> BuscarFamiliarPorIdAsync(int id)
    {
        if (id <= 0) return Result.Fail("Familiar inválido ou não informado.");

        try
        {
            var familiarEntidade = await repository.BuscarDetalhesAsync(id);
            if (familiarEntidade == null)
            {
                return Result.Fail("Familiar não encontrado.");
            }
            return Result.Ok(mapper.Map<FamiliarDetalhesDto>(familiarEntidade));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar familiar pelo ID: {Id}", id);
            return Result.Fail("Não foi possível obter os detalhes do familiar.");
        }

    }

    public async Task<Result> DeletarFamiliarAsync(int id)
    {
         if (id <= 0)
            return Result.Fail("O identificador do familiar é inválido.");
        try
        {
            var familiar = await repository.BuscarDetalhesAsync(id);
            if (familiar == null)
            {
                return Result.Fail("Familiar não encontrado para exclusão.");
            }

            // 2. Passa o objeto anexado/rastreado para o Delete, evitando novas queries desnecessárias
            await repository.ExcluirAsync(familiar.Id);

            return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro de infraestrutura ao excluir familiar pelo ID: {Id}", id);
            return Result.Fail($"Falha interna ao processar a exclusão do familiar: {ex.Message}");
        }
    }

    public Task<Result> EditarFamiliarAsync(FamiliarDetalhesDto dto)
    {
        throw new NotImplementedException();
    }
}