using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Connectamente.API.Repositories;

public class ApplicationUserRepository(AppDbContext context) : IApplicationUserRepository
{
    public async Task<ApplicationUserModel> AdicionarAsync(ApplicationUserModel usuario)
    {
        await context.Set<ApplicationUserModel>().AddAsync(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> ArquivarAsync(string id)
    {
        var usuario = await context.Set<ApplicationUserModel>().FindAsync(id);
        if (usuario is null) return false;

        usuario.Ativo = false; // Soft delete / arquivamento baseado na propriedade configurada
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<ApplicationUserModel?> BuscarDetalhesAsync(string id)
    {
        return await context.Set<ApplicationUserModel>()
            .Include(u => u.DocumentosCriados)
            .Include(u => u.ProntuariosResponsavel)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<ApplicationUserModel?> BuscarPorCpfAsync(string cpf)
    {
        return await context.Set<ApplicationUserModel>()
            .FirstOrDefaultAsync(u => u.Cpf == cpf);
    }

    public async Task<IEnumerable<ApplicationUserModel>> BuscarTodosAsync()
    {
        return await context.Set<ApplicationUserModel>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task EditarAsync(ApplicationUserModel usuario)
    {
        context.Entry(usuario).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExcluirAsync(string id)
    {
        var usuario = await context.Set<ApplicationUserModel>().FindAsync(id);
        if (usuario is null) return false;

        context.Set<ApplicationUserModel>().Remove(usuario);
        return await context.SaveChangesAsync() > 0;
    }

     public IQueryable<ApplicationUserModel> ObterQueryable()
    {
        return context.Users;
    }
}