using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class AtendimentoRepository(AppDbContext context) : IAtendimentoRepository
{
    public async Task<AgendamentoModel> AdicionarAsync(AgendamentoModel atendimento)
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

    public async Task<IEnumerable<AgendamentoModel>> BuscarAtendimentosDaSemanaPorPsicologoAsync(string id)
{
    var hoje = DateTime.UtcNow.Date;
    var fimDaSemana = hoje.AddDays(7);

     return await context.Atendimentos
        .AsNoTracking()
        .Include(a => a.VinculoPacientePsicologo)
            .ThenInclude(v => v.Paciente)
                .ThenInclude(p => p.Identificacao)
        .Include(a => a.VinculoPacientePsicologo)
            .ThenInclude(v => v.PsicologoResponsavel)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
                .ThenInclude(p => p.Identificacao)
        .Where(a =>
            a.VinculoPacientePsicologo.PsicologoResponsavelId == id &&
            a.VinculoPacientePsicologo.Ativo &&
            a.VinculoPacientePsicologo.DataEncerramento == null &&
            a.DataHoraInicio.HasValue &&
            a.DataHoraInicio.Value >= hoje &&
            a.DataHoraInicio.Value < fimDaSemana)
        .OrderBy(a => a.DataHoraInicio)
        .ToListAsync();
}

   public async Task<AgendamentoModel?> BuscarDetalhesAsync(int id)
{
    return await context.Atendimentos
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente.VinculosPacientePsicologo)
              .Where(p => p.VinculoPacientePsicologo.Ativo)
        .Include(a => a.DocumentosClinicos)
        .FirstOrDefaultAsync(a => a.Id == id);
}

    public async Task<IEnumerable<AgendamentoModel>> BuscarPorIdPsicologoAsync(string psicologoId)
    {
        return await context.Atendimentos
            .AsNoTracking()
             .Include(a => a.Prontuario)
                 .ThenInclude(p => p.Paciente)
            .Include(a => a.Prontuario)
                .ThenInclude(p => p.Paciente.VinculosPacientePsicologo)
                .Where(p => p.VinculoPacientePsicologo.Ativo &&
                p.VinculoPacientePsicologo.PsicologoResponsavelId == psicologoId)                 
            .OrderByDescending(a => a.DataHoraInicio)
            .ToListAsync();
    }

    public async Task<IEnumerable<AgendamentoModel>> BuscarTodosAsync()
    {
        return await context.Atendimentos
            .AsNoTracking()
             .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
        .Include(a => a.Prontuario)
                .ThenInclude(p => p.Paciente.VinculosPacientePsicologo)
            .OrderByDescending(a => a.DataHoraInicio)
            .ToListAsync();
    }

    public async Task<IEnumerable<AgendamentoModel>> BuscarTodosAtendimentosDaSemanaAsync()
    {
       var hoje = DateTime.UtcNow.Date;
    var fimDaSemana = hoje.AddDays(7);

    return await context.Atendimentos
        .AsNoTracking()
        .Include(a => a.Prontuario)
            .ThenInclude(p => p.Paciente)
         .Include(a => a.Prontuario)
                .ThenInclude(p => p.Paciente.VinculosPacientePsicologo)
        .Where(a => a.Ativo 
                    && a.DataHoraInicio >= hoje 
                    && a.DataHoraInicio <= fimDaSemana)
        .OrderBy(a => a.DataHoraInicio)
        .ToListAsync();
    }

    public async Task<bool> EditarAsync(AgendamentoModel atendimento)
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