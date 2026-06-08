using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class PacienteRepository(AppDbContext context) : IPacienteRepository
{
    private readonly AppDbContext _context = context;

    public async Task<PacienteModel?> ObterPorIdAsync(int id)
    {
        // Usa AsNoTracking() se for apenas para leitura, mas para o repositório genérico de escrita, 
        // mantemos o rastreamento ativo para permitir modificações posteriores pelo Unit of Work / Service.
        return await _context.Pacientes
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<PacienteModel?> ObterCompletoPorIdAsync(int id)
    {
       return await _context.Pacientes
            .Include(p => p.Prontuario)
            .Include(p => p.Familiares)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<PacienteModel>> ObterPaginadoAsync(string? nome, int skip, int take)
    {
        var query = _context.Pacientes.AsNoTracking();

        // Filtro condicional por nome usando eficiência de string do EF Core
        if (!string.IsNullOrWhiteSpace(nome))
        {
            query = query.Where(p => p.NomeCompleto.Contains(nome));
        }

        // Paginação obrigatória para performance em bases grandes
        return await query
            .OrderBy(p => p.NomeCompleto)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public async Task<bool> ExisteCpfAsync(string cpf)
    {
        // AnyAsync é muito mais rápido do que fazer um Where().FirstOrDefault() != null,
        // pois o banco encerra a busca assim que encontra o primeiro registro correspondente.
        return await _context.Pacientes
            .AnyAsync(p => p.CPF == cpf);
    }

    public async Task AdicionarAsync(PacienteModel paciente)
    {
        await _context.Pacientes.AddAsync(paciente);
    }

    public void Atualizar(PacienteModel paciente)
    {
        // puramente síncrono. Altera o estado no ChangeTracker do EF para 'Modified'.
        _context.Pacientes.Update(paciente);
    }

    public void Remover(PacienteModel paciente)
    {
        // puramente síncrono. Altera o estado no ChangeTracker do EF para 'Deleted'.
        _context.Pacientes.Remove(paciente);
    }
}