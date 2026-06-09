using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class ProntuarioRepository(AppDbContext context) : IProntuarioRepository
{
    public IQueryable<ProntuarioModel> ObterQueryable()
    {
        // Retorna o DbSet puro. O AsNoTracking() ou tracking deve ser decidido 
        // na camada de Serviço com base na necessidade da query.
        return context.Set<ProntuarioModel>();
    }

    public async Task<ProntuarioModel?> ObterPorIdAsync(int id)
    {
        // Busca simples por chave primária utilizando o cache local do EF antes de ir ao banco
        return await context.Set<ProntuarioModel>().FindAsync(id);
    }

    public async Task<ProntuarioModel?> ObterComDetalhesPorIdAsync(int id)
    {
        // 🧠 Uso de Eager Loading (.Include) para trazer o grafo completo da entidade
        // Evita o problema de "N+1 queries" no banco de dados.
        return await context.Set<ProntuarioModel>()
            .Include(p => p.Paciente)
            .Include(p => p.PsicologoResponsavel)
            .Include(p => p.TratamentosAnteriores)
            .Include(p => p.Atendimentos)
            .Include(p => p.DocumentosClinicos)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AdicionarAsync(ProntuarioModel prontuario)
    {
        // Adiciona a entidade ao rastreador do EF Core em estado 'Added'
        await context.Set<ProntuarioModel>().AddAsync(prontuario);
    }

    public void Atualizar(ProntuarioModel prontuario)
    {
        // Modifica o estado da entidade para 'Modified'. 
        // Nota: Se a entidade já foi rastreada pelo ObterPorId, este método é opcional, 
        // mas é uma boa prática para entidades desconectadas (vinda de APIs/DTo).
        context.Set<ProntuarioModel>().Update(prontuario);
    }

    public void Remover(ProntuarioModel prontuario)
    {
        // Modifica o estado para 'Deleted' (ou executa o Soft Delete se configurado globalmente)
        context.Set<ProntuarioModel>().Remove(prontuario);
    }

    public async Task<bool> CommitAsync()
    {
        // Executa o comando SQL (INSERT, UPDATE, DELETE) de forma transacional no banco
        var linhasAfetadas = await context.SaveChangesAsync();
        return linhasAfetadas > 0;
    }
}