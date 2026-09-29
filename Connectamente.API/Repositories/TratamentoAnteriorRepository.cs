using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class TratamentoAnteriorRepository(AppDbContext context) : ITratamentoAnteriorRepository
{
    public async Task<TratamentoAnteriorModel> AdicionarAsync(TratamentoAnteriorModel tratamentoAnterior)
    {
         tratamentoAnterior.Ativo = true;        
        context.TratamentosAnteriores.Add(tratamentoAnterior);
        await context.SaveChangesAsync();

        return tratamentoAnterior;
    }

    public async Task<TratamentoAnteriorModel?> BuscarDetalhesAsync(int id)
    {
         return await context.TratamentosAnteriores
            .AsNoTracking()
            .Include(t => t.Prontuario)
                .ThenInclude(p => p!.Paciente)
            .FirstOrDefaultAsync(t => t.Id == id);
    }


    public async Task<IEnumerable<TratamentoAnteriorModel>> BuscarTodosAsync()
    {
           return await context.TratamentosAnteriores
            .AsNoTracking()
            // Carrega o Prontuário e aninha o Paciente para que o AutoMapper consiga ler o NomeCompleto
            .Include(t => t.Prontuario)
                .ThenInclude(p => p!.Paciente)
            .OrderByDescending(t => t.Id)
            .ToListAsync();
    }

    public Task EditarAsync(TratamentoAnteriorModel tratamentoAnterior)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExcluirAsync(int id)
    {
         var linhasAfetadas = await context.TratamentosAnteriores
            .Where(tratamentoAnterior => tratamentoAnterior.Id == id)
            .ExecuteDeleteAsync();

        return linhasAfetadas > 0;
    }
}