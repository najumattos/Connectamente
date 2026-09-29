using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class AtendimentoRepository(AppDbContext context) : IAtendimentoRepository
{
    public async Task<AtendimentoModel> AdicionarAsync(AtendimentoModel atendimento)
    {
        if (atendimento.DataCriacao == default)
        {
            atendimento.Ativo = true;
        }

        await context.Atendimentos.AddAsync(atendimento);
        await context.SaveChangesAsync();
        
        return atendimento;
    }

    public async Task<bool> ArquivarAsync(int id)
    {
       var atendimento = await context.Atendimentos.FindAsync(id);
        if (atendimento == null) return false;

        atendimento.Ativo = false;
        atendimento.DataAtualizacao = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<AtendimentoModel>> BuscarAtendimentosDaSemanaPorPsicologoAsync(string id)
{
    var hoje = DateTime.UtcNow.Date;
    var fimDaSemana = hoje.AddDays(7);

    return await context.Atendimentos
        .AsNoTracking()
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.PsicologoResponsavel)
        .Where(a => a.Ativo
                    && a.Prontuario.PsicologoResponsavelId == id
                    && a.DataHoraInicio >= hoje
                    && a.DataHoraInicio <= fimDaSemana)
        .OrderBy(a => a.DataHoraInicio)
        .ToListAsync();
}

   public async Task<AtendimentoModel?> BuscarDetalhesAsync(int id)
{
    return await context.Atendimentos
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.PsicologoResponsavel) 
        .Include(a => a.DocumentosClinicos)
        .FirstOrDefaultAsync(a => a.Id == id);
}

    public async Task<IEnumerable<AtendimentoModel>> BuscarPorIdPsicologoAsync(string psicologoId)
    {
        return await context.Atendimentos
            .AsNoTracking()
             .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.PsicologoResponsavel)
            .Where(a => a.Prontuario.PsicologoResponsavelId == psicologoId) 
            .OrderByDescending(a => a.DataHoraInicio)
            .ToListAsync();
    }

    public async Task<IEnumerable<AtendimentoModel>> BuscarTodosAsync()
    {
        return await context.Atendimentos
            .AsNoTracking()
             .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.PsicologoResponsavel)
            .OrderByDescending(a => a.DataHoraInicio)
            .ToListAsync();
    }

    public async Task<IEnumerable<AtendimentoModel>> BuscarTodosAtendimentosDaSemanaAsync()
    {
       var hoje = DateTime.UtcNow.Date;
    var fimDaSemana = hoje.AddDays(7);

    return await context.Atendimentos
        .AsNoTracking()
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.PsicologoResponsavel)
        .Where(a => a.Ativo 
                    && a.DataHoraInicio >= hoje 
                    && a.DataHoraInicio <= fimDaSemana)
        .OrderBy(a => a.DataHoraInicio)
        .ToListAsync();
    }

    public async Task<bool> EditarAsync(AtendimentoModel atendimento)
    {             
    var linhasAfetadas = await context.SaveChangesAsync();
    return linhasAfetadas > 0;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
       var atendimento = await context.Atendimentos.FindAsync(id);
        if (atendimento == null) return false;

      context.Atendimentos.Remove(atendimento);
        await context.SaveChangesAsync();
        return true;
    }
}