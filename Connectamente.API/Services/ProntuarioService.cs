using AutoMapper;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.ProntuarioDto;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;

namespace Connectamente.API.Services;

public class ProntuarioService(
    IProntuarioRepository repository,
    IMapper mapper,
    IPsicologoService psicologoService,
    ILogger<ProntuarioService> logger) : IProntuarioService
{
    public async Task<Result<IEnumerable<ProntuarioListaDto>>> BuscarTodosProntuariosAsync()
    {
        var prontuarios = await repository.BuscarTodosAsync();
        var prontuariosDto = mapper.Map<IEnumerable<ProntuarioListaDto>>(prontuarios);
        return Result.Ok(prontuariosDto);
    }

    public async Task<Result<ProntuarioDetalhesDto>> BuscarProntuarioPorIdAsync(int id)
    {
        var prontuarioEntidade = await repository.BuscarDetalhesAsync(id);
       if (prontuarioEntidade == null)
        {
           return Result.Fail<ProntuarioDetalhesDto>("Prontuário não encontrado.");
        }
        
        var prontuarioDto = mapper.Map<ProntuarioDetalhesDto>(prontuarioEntidade);   
        return Result.Ok(prontuarioDto);
    }

    public async Task<Result> ArquivarProntuarioAsync(int id)
    {
       if (id <= 0)
        return Result.Fail("O identificador do prontuário informado é inválido.");

    var prontuario = await repository.BuscarDetalhesAsync(id);
    if (prontuario == null)
        return Result.Fail($"Prontuário com o ID {id} não encontrado.");

    if (prontuario.SituacaoProntuario == SituacaoEnum.Arquivado)
        return Result.Fail("Este prontuário já se encontra arquivado no sistema.");

    prontuario.SituacaoProntuario = SituacaoEnum.Arquivado;
    prontuario.DataAtualizacao = DateTime.UtcNow;

    await repository.EditarAsync(prontuario);
    return Result.Ok();
    }

    public async Task<Result<ProntuarioDetalhesDto>> AdicionarProntuarioAsync(ProntuarioAdicionarDto dto)
    {
        if (dto == null)
            return Result.Fail<ProntuarioDetalhesDto>("Prontuário inválido ou não informado.");

        var prontuarioExiste = await repository.ExisteNumeroProntuarioAsync(dto.NumeroProntuario);
        if (prontuarioExiste)
        {
            return Result.Fail("o numero do prontuario já existe no sistema");
        }

        try
        {
            var prontuarioEntidade = mapper.Map<ProntuarioModel>(dto);


            await repository.AdicionarAsync(prontuarioEntidade);
            var dtoDetalhes = mapper.Map<ProntuarioDetalhesDto>(prontuarioEntidade);

           return Result.Ok(dtoDetalhes);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao tentar adicionar prontuário no banco de dados. DTO: {@ProntuarioDto}", dto);
            return Result.Fail<ProntuarioDetalhesDto>("Não foi possível cadastrar o prontuário no momento.");
        }
    }

     public async Task<Result<ProntuarioPsicologoVincularDto>> ObterDadosParaVinculoAsync(int prontuarioId)
{
    var prontuarioResult = await BuscarProntuarioPorIdAsync(prontuarioId);
    if (prontuarioResult.IsFailed)
    {
        return Result.Fail<ProntuarioPsicologoVincularDto>("Prontuário não localizado ou encontra-se inativo.");
    }

    var psicologosResult = await psicologoService.BuscarPsicologosDisponiveisAsync();
    if (psicologosResult.IsFailed)
    {
        return Result.Fail<ProntuarioPsicologoVincularDto>("Não foi possível buscar os psicólogos disponíveis.");
    }

  var dto = mapper.Map<ProntuarioPsicologoVincularDto>(prontuarioResult.Value);
    dto.PsicologosDisponiveis = psicologosResult.Value.ToList();

    return Result.Ok(dto);
}

   public async Task<Result> EditarProntuarioAsync(ProntuarioEditarDto dto)
{
    if (dto == null) return Result.Fail("Os dados para atualização não foram informados.");

    try
    {
        var prontuario = await repository.BuscarDetalhesAsync(dto.Id);
        if (prontuario == null)
            return Result.Fail("O registro do prontuário não foi localizado no sistema.");

        prontuario.SituacaoProntuario = dto.SituacaoProntuario;
        prontuario.Ativo = dto.Ativo;
        prontuario.Observacoes = dto.Observacoes;

        await repository.EditarAsync(prontuario);
        return Result.Ok();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Erro crítico ao atualizar prontuário ID: {Id}", dto.Id);
        return Result.Fail("Ocorreu uma falha interna ao salvar as alterações do prontuário.");
    }
}
}