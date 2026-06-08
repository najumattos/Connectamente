using AutoMapper;
using AutoMapper.QueryableExtensions;
using Connectamente.API.DTOs.PacienteDto;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Services;

public class PacienteService(
    IPacienteRepository repository, 
    IMapper mapper) : IPacienteService
{   
    public async Task<Result<IEnumerable<PacienteListaDto>>> BuscarTodosPacientesAsync()
    {
        // 1. Obtém o IQueryable do repositório (Sem descarregar na memória ainda)
        var query = repository.ObterQueryable();

        // 2. Projeta cirurgicamente para o DTO e executa a consulta no banco
        var pacientesDto = await query
            .AsNoTracking()
            .ProjectTo<PacienteListaDto>(mapper.ConfigurationProvider)
            .ToListAsync(); 

        return Result.Ok<IEnumerable<PacienteListaDto>>(pacientesDto);
    }

    public async Task<Result<PacienteDetalhesDto>> BuscarPacientePorIdAsync(int id)
    {
        var query = repository.ObterQueryable();

        // Projeta diretamente para o DTO de detalhes filtrando pelo ID
        var pacienteDto = await query
            .AsNoTracking()
            .Where(p => p.Id == id)
            .ProjectTo<PacienteDetalhesDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        if (pacienteDto is null)
        {
            return Result.Fail<PacienteDetalhesDto>($"Paciente com o ID {id} não foi encontrado.");
        }

        return Result.Ok(pacienteDto);
    }

    public Task<Result> ArquivarPacienteAsync(int id)
    {
        throw new NotImplementedException();
    }

}