using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class FamiliarRepository(AppDbContext context) : IFamiliarRepository
{
    public async Task<FamiliarModel> AdicionarAsync(FamiliarModel familiar)
    {
        familiar.Ativo = true;
        await context.Set<FamiliarModel>().AddAsync(familiar);
        await context.SaveChangesAsync();
        return familiar;
    }

    public async Task<FamiliarModel?> BuscarDetalhesAsync(int id)
    {
        return await context.Set<FamiliarModel>()
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    // CORREÇÃO: Alterado de Guid para int para casar com a FK física da FamiliarModel
    public async Task<IEnumerable<FamiliarModel>> BuscarPorProntuarioIdAsync(int prontuarioId)
    {
        // CORREÇÃO: Removido EF.Property. Consulta direta na propriedade física da classe.
        return await context.Set<FamiliarModel>()
            .AsNoTracking()
            .Where(f => f.ProntuarioId == prontuarioId)
            .ToListAsync();
    }

    public async Task<IEnumerable<FamiliarModel>> BuscarTodosAsync()
    {
        return await context.Set<FamiliarModel>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task EditarAsync(FamiliarModel Familiar)
    {
        context.Entry(Familiar).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var Familiar = await context.Set<FamiliarModel>().FindAsync(id);
        if (Familiar is null) return false;

        context.Set<FamiliarModel>().Remove(Familiar);
        return await context.SaveChangesAsync() > 0;
    }
}