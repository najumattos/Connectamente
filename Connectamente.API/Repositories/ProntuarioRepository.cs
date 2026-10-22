using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class ProntuarioRepository(AppDbContext context) : IProntuarioRepository
{
    public async Task<bool> ExisteNumeroProntuarioAsync(string numeroProntuario)
    {
        return await context.Prontuarios
    .AnyAsync(p => p.NumeroProntuario == numeroProntuario);
    }

    public async Task<bool> ExisteProntuarioAsync(int id)
    {
        return await context.Prontuarios
          .AnyAsync(p => p.Id == id);
    }

   
    public async Task<ProntuarioModel> AdicionarAsync(ProntuarioModel prontuario)
    {
          prontuario.DataCriacao = DateTime.UtcNow;
            prontuario.Ativo = true;
        await context.Prontuarios.AddAsync(prontuario);
        await context.SaveChangesAsync();
        return prontuario;
    }

public async Task EditarAsync(ProntuarioModel prontuario)
    {
        prontuario.DataAtualizacao = DateTime.UtcNow;
        context.Entry(prontuario).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<bool> ArquivarAsync(int id)
    {
        var prontuario = await context.Set<ProntuarioModel>().FindAsync(id);
        if (prontuario is null) return false;

        prontuario.Ativo = false;
        prontuario.DataAtualizacao = DateTime.UtcNow;

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var prontuario = await context.Set<ProntuarioModel>().FindAsync(id);
        if (prontuario is null) return false;

        context.Set<ProntuarioModel>().Remove(prontuario);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<ProntuarioModel>> BuscarTodosAsync()
    {
        return await context.Prontuarios
            .AsNoTracking()
            .Include(p => p.Paciente)
            .ToListAsync();
    }

    public async Task<ProntuarioModel?> BuscarDetalhesAsync(int id)
    {
        return await context.Prontuarios
            .Include(p => p.Paciente)
            .Include(p => p.TratamentosAnteriores)
            .Include(p => p.DocumentosClinicos)           
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}