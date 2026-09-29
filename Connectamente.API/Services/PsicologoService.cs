using AutoMapper;
using Connectamente.API.DTOs.PsicologoDto;
using Connectamente.API.Repositories.Interfaces;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Services;

public class PsicologoService(IApplicationUserRepository repository,
    IMapper mapper,
    ILogger<PsicologoService> logger) : IPsicologoService
{
    public async Task<Result<IEnumerable<PsicologoListaDto>>> BuscarTodosPsicologosAsync()
    {
        var psicologosEntidade = await repository.BuscarTodosAsync();      
        var psicologosDto = mapper.Map<IEnumerable<PsicologoListaDto>>(psicologosEntidade);    
        return Result.Ok(psicologosDto);
    }

     public async Task<Result<IEnumerable<PsicologoListaDto>>> BuscarPsicologosDisponiveisAsync()
{
    var psicologos = await repository.ObterQueryable()
        .AsNoTracking()
        .Where(p => p.Ativo)
        .Select(u => new PsicologoListaDto
        {
            PsicologoResponsavelId = u.Id,
            Matricula = u.Matricula ?? string.Empty,
            NomeCompleto = u.NomeCompleto            
        })
        .ToListAsync();

    return Result.Ok<IEnumerable<PsicologoListaDto>>(psicologos);
}

    public async Task<Result<PsicologoDetalhesDto>> BuscarPsicologoPorIdAsync(string id)
    {
       var psicologoEntidade = await repository.BuscarDetalhesAsync(id);

        if (psicologoEntidade is null)
        {
            return Result.Fail<PsicologoDetalhesDto>($"psicologo com o ID {id} não foi encontrado.");
        }
        var psicologoDto = mapper.Map<PsicologoDetalhesDto>(psicologoEntidade);   
        return Result.Ok(psicologoDto);
    }
}