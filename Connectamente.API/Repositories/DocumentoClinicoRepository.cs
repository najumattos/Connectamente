using Connectamente.API.Data;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class DocumentoClinicoRepository(AppDbContext AppDbContext) : IDocumentoClinicoRepository
{
  
  public Task<DocumentoClinicoModel> AddAsync(DocumentoClinicoModel documento)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DocumentoClinicoModel>> GetAllAtivosAsync()
    {
        throw new NotImplementedException();
    }

    public Task<DocumentoClinicoModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DocumentoClinicoModel>> GetByProntuarioIdAsync(int prontuarioId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DocumentoClinicoModel>> GetByStatusAsync(StatusDocumentoClinicoEnum status)
    {
        throw new NotImplementedException();
    }

    public Task<DocumentoClinicoModel> UpdateAsync(DocumentoClinicoModel documento)
    {
        throw new NotImplementedException();
    }
}