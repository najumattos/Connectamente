using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class AtendimentoRepository(AppDbContext context) : IAtendimentoRepository
{
    public async Task<AgendamentoModel> AdicionarAsync(AgendamentoModel atendimento)
    {      

        await context.Atendimentos.AddAsync(atendimento);
        await context.SaveChangesAsync();
        
        return atendimento;
    }

    public async Task<bool> ArquivarAsync(int id)
    {
       var atendimento = await context.Atendimentos.FindAsync(id);
        if (atendimento == null) return false;
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
        .ToListAsync();
}

   public async Task<AgendamentoModel?> BuscarDetalhesAsync(int id)
{
    return await context.Atendimentos       
        .FirstOrDefaultAsync(a => a.Id == id);
}

    public async Task<IEnumerable<AgendamentoModel>> BuscarPorIdPsicologoAsync(string psicologoId)
    {
        return await context.Atendimentos
            .AsNoTracking()          
            .ToListAsync();
    }

    public async Task<IEnumerable<AgendamentoModel>> BuscarTodosAsync()
    {
        return await context.Atendimentos
            .AsNoTracking()         
            .ToListAsync();
    }

    public async Task<IEnumerable<AgendamentoModel>> BuscarTodosAtendimentosDaSemanaAsync()
    {
       var hoje = DateTime.UtcNow.Date;
    var fimDaSemana = hoje.AddDays(7);

    return await context.Atendimentos
        .AsNoTracking()      
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