using System.Linq.Expressions;
using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class PacienteRepository(AppDbContext context) : IPacienteRepository
{
    public Task AdicionarAsync(PacienteModel entidade)
    {
        throw new NotImplementedException();
    }
    public Task AdicionarVariosAsync(IEnumerable<PacienteModel> entidades)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(PacienteModel entidade)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PacienteModel>> BuscarAsync(Expression<Func<PacienteModel, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<PacienteModel?> ObterPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PacienteModel>> ObterTodosAsync()
    {
        throw new NotImplementedException();
    }

    public void Remover(PacienteModel entidade)
    {
        throw new NotImplementedException();
    }

    public Task RemoverPorIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}