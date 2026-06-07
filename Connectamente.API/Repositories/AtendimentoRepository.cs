using Connectamente.API.Data;
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;

namespace Connectamente.API.Repositories;

public class AtendimentoRepository(AppDbContext AppDbContext) : IAtendimentoRepository
{
    public Task<AtendimentoModel> AddAsync(AtendimentoModel atendimento)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AtendimentoModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AtendimentoModel>> GetByAlunoIdAsync(string alunoId)
    {
        throw new NotImplementedException();
    }

    public Task<AtendimentoModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AtendimentoModel>> GetByPacienteIdAsync(int pacienteId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AtendimentoModel>> GetByStatusAsync(StatusAtendimentoEnum status)
    {
        throw new NotImplementedException();
    }

    public Task<AtendimentoModel> UpdateAsync(AtendimentoModel atendimento)
    {
        throw new NotImplementedException();
    }
}