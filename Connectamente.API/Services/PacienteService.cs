using Connectamente.API.Services.Interfaces;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.DTOs.PacienteDto;
using AutoMapper;
using FluentResults;

namespace Connectamente.API.Services;

public class PacienteService(
    IPacienteRepository repository,
    IMapper mapper,
    ILogger<PacienteService> logger) : IPacienteService
{
    public async Task<Result<IEnumerable<PacienteListaDto>>> BuscarTodosPacientesAsync()
    {
        var pacientesEntidade = await repository.BuscarTodosAsync();      
        var pacientesDto = mapper.Map<IEnumerable<PacienteListaDto>>(pacientesEntidade);    
        return Result.Ok(pacientesDto);
    }

    public async Task<Result<PacienteDetalhesDto>> BuscarPacientePorIdAsync(int id)
    {
        var pacienteEntidade = await repository.BuscarDetalhesAsync(id);

        if (pacienteEntidade is null)
        {
            return Result.Fail<PacienteDetalhesDto>($"Paciente com o ID {id} não foi encontrado.");
        }
        var pacienteDto = mapper.Map<PacienteDetalhesDto>(pacienteEntidade);   
        return Result.Ok(pacienteDto);
    }

    public async Task<Result> ArquivarPacienteAsync(int id)
    {
         if (id <= 0)
        return Result.Fail("O identificador do paciente informado é inválido.");

    var paciente = await repository.BuscarDetalhesAsync(id);
    if (paciente == null)
        return Result.Fail($"Paciente com o ID {id} não encontrado.");

    if (paciente.Ativo == false)
        return Result.Fail("Este paciente já se encontra arquivado no sistema.");

    paciente.Ativo = false;
    paciente.DataAtualizacao = DateTime.UtcNow;

    await repository.EditarAsync(paciente);
    return Result.Ok();
    }

    public async Task<Result<int>> AdicionarPacienteAsync(PacienteAdicionarDto dto)
    {
       if (dto == null) 
        return Result.Fail<int>("Paciente inválido ou não informado.");

    if (dto.Identificacao == null)
        return Result.Fail<int>("As informações de identificação do paciente são obrigatórias.");

    
    if (!string.IsNullOrWhiteSpace(dto.Identificacao.CPF))
    {
        dto.Identificacao.CPF = string.Concat(dto.Identificacao.CPF.Where(char.IsDigit));

        var cpfExiste = await repository.ExisteCpfAsync(dto.Identificacao.CPF);
        if (cpfExiste)
        {
            return Result.Fail<int>("O CPF informado já está cadastrado no sistema.");
        }
    }

    if (dto.Endereco != null && !string.IsNullOrWhiteSpace(dto.Endereco.CEP))
    {
        dto.Endereco.CEP = string.Concat(dto.Endereco.CEP.Where(char.IsDigit));
    }
        try
        {
            var pacienteEntidade = mapper.Map<PacienteModel>(dto);
            await repository.AdicionarAsync(pacienteEntidade);
            return Result.Ok(pacienteEntidade.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao tentar adicionar paciente no banco de dados.");
            return Result.Fail<int>("Não foi possível cadastrar o paciente no momento.");
        }
    }

    public async Task<Result<IEnumerable<PacienteListaDto>>> BuscarPacientesPorIdPsicologoAsync(string idPsicologo)
    {
        if (string.IsNullOrWhiteSpace(idPsicologo))
        {
            return Result.Fail("O identificador do psicólogo é inválido ou não foi informado.");
        }

      var pacientes = await repository.BuscarPorIdPsicologoAsync(idPsicologo);
         var pacientesDto = mapper.Map<IEnumerable<PacienteListaDto>>(pacientes);
    return Result.Ok(pacientesDto);
    }

   public async Task<Result> EditarPacienteAsync(PacienteDetalhesDto dto)
{
    if (dto == null) return Result.Fail("Os dados para atualização não foram informados.");

    try
    {
        var paciente = await repository.BuscarDetalhesAsync(dto.Id);
        if (paciente == null)
            return Result.Fail("O registro de paciente não foi localizado no sistema.");

        // Records são imutáveis — mapear o DTO para um novo PacienteModel
        // e depois atualizar apenas os campos editáveis manualmente
        if (dto.Identificacao != null)
        {
            paciente.Identificacao = mapper.Map<Identificacao>(dto.Identificacao);
        }

        if (dto.Endereco != null)
        {
            paciente.Endereco = mapper.Map<Endereco>(dto.Endereco);
        }

        paciente.Ativo = dto.Ativo;
        paciente.Observacoes = dto.Observacoes;
        paciente.DataAtualizacao = DateTime.UtcNow;

        await repository.EditarAsync(paciente);
        return Result.Ok();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Erro crítico ao atualizar paciente ID: {Id}", dto.Id);
        return Result.Fail("Ocorreu uma falha interna ao salvar as alterações do paciente.");
    }
}
}