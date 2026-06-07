using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class AnamneseAdultoRepository(AppDbContext AppDbContext) : IAnamneseAdultoRepository
{
  
 public Task<AnamneseAdultoModel> AddAsync(AnamneseAdultoModel anamneseAdulto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int documentoClinicoId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AnamneseAdultoModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AnamneseAdultoModel> GetByIdAsync(int documentoClinicoId)
    {
        throw new NotImplementedException();
    }

    public Task<AnamneseAdultoModel> UpdateAsync(AnamneseAdultoModel anamneseAdulto)
    {
        throw new NotImplementedException();
    }
}