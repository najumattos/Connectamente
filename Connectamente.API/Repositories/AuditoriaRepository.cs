using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class AuditoriaRepository(AppDbContext AppDbContext) : IAuditoriaRepository
{
	
    public Task<AuditoriaModel> AddAsync(AuditoriaModel auditoria)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuditoriaModel>> GetByEntidadeERegistroAsync(string entidade, string registroId)
    {
        throw new NotImplementedException();
    }

    public Task<AuditoriaModel?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuditoriaModel>> GetByPeriodoAsync(DateTime inicio, DateTime fim)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AuditoriaModel>> GetByUsuarioIdAsync(string usuarioId)
    {
        throw new NotImplementedException();
    }
}