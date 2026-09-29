using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class PacienteRepository(AppDbContext context) : IPacienteRepository
{

    public async Task<bool> ExisteCpfAsync(string cpf)
    {
       return await context.Set<PacienteModel>()
            .AnyAsync(p => p.Identificacao.CPF == cpf);

    }

    public async Task<PacienteModel> AdicionarAsync(PacienteModel paciente)
    {
        paciente.DataCriacao = DateTime.UtcNow; 
        paciente.Ativo = true;
        await context.Pacientes.AddAsync(paciente);
        await context.SaveChangesAsync();
        return paciente;
    }

public async Task<IEnumerable<PacienteModel>> BuscarTodosAsync()
    {
      return await context.Set<PacienteModel>()
        .AsNoTracking()
        .Include(p => p.Prontuario)
            .ThenInclude(pr => pr.Familiares)
        .ToListAsync();
    }

    public async Task<PacienteModel?> BuscarDetalhesAsync(int id)
    {
       return await context.Set<PacienteModel>()
        .Include(p => p.Prontuario)
            .ThenInclude(pr => pr.Familiares)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task EditarAsync(PacienteModel paciente)
    {
        context.Set<PacienteModel>().Update(paciente);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ArquivarAsync(int id)
    {
        var paciente = await context.Set<PacienteModel>().FindAsync(id);
        if (paciente == null) return false;

        paciente.Ativo = false;
        paciente.DataAtualizacao = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExcluirAsync(int id)
    {
        var paciente = await context.Set<PacienteModel>().FindAsync(id);
        if (paciente == null) return false;

        context.Set<PacienteModel>().Remove(paciente);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<PacienteModel>> BuscarPorIdPsicologoAsync(string psicologoId)
    {
         if (string.IsNullOrWhiteSpace(psicologoId))
        {
            return Enumerable.Empty<PacienteModel>();
        }

        return await context.Pacientes
            .Where(p => p.Prontuario.PsicologoResponsavelId == psicologoId)
            .ToListAsync();
    }
}