using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class AnexoRepository(AppDbContext AppDbContext) : IAnexoRepository
{
    public Task<AnexoModel> AddAsync(AnexoModel anexo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnexoModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnexoModel>> GetByDocumentoClinicoIdAsync(int documentoClinicoId)
    {
        throw new NotImplementedException();
    }

    public Task<AnexoModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AnexoModel> UpdateAsync(AnexoModel anexo)
    {
        throw new NotImplementedException();
    }
}