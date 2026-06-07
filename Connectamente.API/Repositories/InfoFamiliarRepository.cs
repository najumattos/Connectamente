using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class InfoFamiliarRepository(AppDbContext AppDbContext) : IInfoFamiliarRepository
{
    public Task<InfoFamiliarModel> AddAsync(InfoFamiliarModel familiar)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InfoFamiliarModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<InfoFamiliarModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<InfoFamiliarModel>> GetByPacienteIdAsync(Guid pacienteId)
    {
        throw new NotImplementedException();
    }

    public Task<InfoFamiliarModel?> GetResponsavelByIdAsync(int id, bool responsavel = true)
    {
        throw new NotImplementedException();
    }

    public Task<InfoFamiliarModel> UpdateAsync(InfoFamiliarModel familiar)
    {
        throw new NotImplementedException();
    }
}