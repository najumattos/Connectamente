using AutoMapper;
using Connectamente.API.DTOs.AtendimentoDto;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;

namespace Connectamente.API.Services;

public class AtendimentoService(
    IAtendimentoRepository repository,
    IProntuarioRepository prontuarioRepository,
    ILogger<TratamentoAnteriorService> logger,
    IMapper mapper) : IAtendimentoService
{
    public async Task<Result> AdicionarAtendimentoAsync(AtendimentoAdicionarDto dto)
    {
         if (dto == null)
            return Result.Fail("Atendimento inválido ou não informado.");
            
       var prontuarioEntidade = await prontuarioRepository.BuscarDetalhesAsync(dto.ProntuarioId);
        if (prontuarioEntidade == null)
        {
            return Result.Fail($"Operação abortada: O prontuário com ID {dto.ProntuarioId} não foi encontrado.");
        }
         if (prontuarioEntidade.PsicologoResponsavelId == null)
        {
            return Result.Fail($"Operação abortada: O prontuário com ID {dto.ProntuarioId} não tem um psicologo vinculado");
        }
        try
        {
            var atendimentoEntidade = mapper.Map<AtendimentoModel>(dto);
            await repository.AdicionarAsync(atendimentoEntidade);
                 return Result.Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro de infraestrutura ao tentar adicionar atendimento no banco de dados. ProntuarioId: {ProntuarioId}", dto.ProntuarioId);
            return Result.Fail("Não foi possível salvar o atendimento devido a uma falha interna no servidor.");
        }
    }

public async Task<Result> AtualizarAtendimentoAsync(AtendimentoAtualizarDto dto)
{
    if (dto == null) return Result.Fail("Os dados para atualização não foram informados.");
    try
    {
       var atendimentoEntidade = await repository.BuscarDetalhesAsync(dto.Id); 

        if (atendimentoEntidade == null)
        {
            return Result.Fail("O atendimento não foi encontrado na base de dados.");
        }
        mapper.Map(dto, atendimentoEntidade);
        atendimentoEntidade.DataAtualizacao = DateTime.UtcNow;
        await repository.EditarAsync(atendimentoEntidade); 
        return Result.Ok();    
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Erro crítico de infraestrutura ao atualizar o atendimento ID: {Id}", dto.Id);
        return Result.Fail("Ocorreu uma falha interna ao salvar as alterações do atendimento.");
    }
}


    public async Task<Result<AtendimentoDetalhesDto>> BuscarAtendimentoPorIdAsync(int id)
    {
        var atendimentoEntidade = await repository.BuscarDetalhesAsync(id);
       if (atendimentoEntidade == null)
        {
           return Result.Fail<AtendimentoDetalhesDto>("Atendimento não encontrado.");
        }
        
        var atendimentoDto = mapper.Map<AtendimentoDetalhesDto>(atendimentoEntidade);   
        return Result.Ok(atendimentoDto);
    }


    public async Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarAtendimentosDaSemanaPorPsicologoAsync(string id)
    {
         if (string.IsNullOrWhiteSpace(id))
        {
            return Result.Fail("O identificador do psicólogo é inválido ou não foi informado.");
        }

      var atendimentos = await repository.BuscarAtendimentosDaSemanaPorPsicologoAsync(id);      
         var atendimentosDto = mapper.Map<IEnumerable<AtendimentoListaDto>>(atendimentos);
    return Result.Ok(atendimentosDto);
    }

    public async Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarAtendimentosPorPsicologoAsync(string id)
    {
          if (string.IsNullOrWhiteSpace(id))
        {
            return Result.Fail("O identificador do psicólogo é inválido ou não foi informado.");
        }

      var atendimentos = await repository.BuscarPorIdPsicologoAsync(id);      
         var atendimentosDto = atendimentos.Select(a => new AtendimentoListaDto
    {
        Id = a.Id,
        TipoAtendimento = a.TipoAtendimento,
        DataHoraInicio = a.DataHoraInicio,
        StatusAtendimento = a.StatusAtendimento,
        NumeroProntuario = a.Prontuario?.NumeroProntuario ?? string.Empty,
        NomePaciente = a.Prontuario?.Paciente?.Identificacao?.NomeCompleto ?? string.Empty,
        PsicologoResponsavel = a.Prontuario?.PsicologoResponsavel?.NomeCompleto ?? string.Empty
    });
    return Result.Ok(atendimentosDto);
    }

    public async Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarTodosAtendimentosAsync()
    {
         var atendimentos = await repository.BuscarTodosAsync();
         
      var atendimentosDto = atendimentos.Select(a => new AtendimentoListaDto
    {
        Id = a.Id,
        TipoAtendimento = a.TipoAtendimento,
        DataHoraInicio = a.DataHoraInicio,
        StatusAtendimento = a.StatusAtendimento,
        NumeroProntuario = a.Prontuario?.NumeroProntuario ?? string.Empty,
        NomePaciente = a.Prontuario?.Paciente?.Identificacao?.NomeCompleto ?? string.Empty,
        PsicologoResponsavel = a.Prontuario?.PsicologoResponsavel?.NomeCompleto ?? string.Empty
    });

    return Result.Ok(atendimentosDto);
    }

    public async Task<Result<IEnumerable<AtendimentoListaDto>>> BuscarTodosAtendimentosDaSemanaAsync()
{
    var atendimentos = await repository.BuscarTodosAtendimentosDaSemanaAsync();  var atendimentosDto = atendimentos.Select(a => new AtendimentoListaDto
    {
        Id = a.Id,
        TipoAtendimento = a.TipoAtendimento,
        DataHoraInicio = a.DataHoraInicio,
        StatusAtendimento = a.StatusAtendimento,
        NumeroProntuario = a.Prontuario?.NumeroProntuario ?? string.Empty,
        NomePaciente = a.Prontuario?.Paciente?.Identificacao?.NomeCompleto ?? string.Empty,
        PsicologoResponsavel = a.Prontuario?.PsicologoResponsavel?.NomeCompleto ?? string.Empty
    });

    return Result.Ok(atendimentosDto);
}

}