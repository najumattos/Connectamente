using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Connectamente.API.Repositories;

public class DocumentoClinicoRepository(AppDbContext context) : IDocumentoClinicoRepository
{
    public async Task<bool> AddDocumentoClinicoAsync(DocumentoClinicoModel documentoClinico)
    {
          
        documentoClinico.Ativo = true;

        await context.DocumentosClinicos.AddAsync(documentoClinico);
        
        var linhasAfetadas = await context.SaveChangesAsync();
        return linhasAfetadas > 0;
    }

    public async Task<DocumentoClinicoModel?> BuscarDetalhesAsync(int id)
    {
        return await context.Set<DocumentoClinicoModel>()
            .AsNoTracking()
            .Include(a => a.Prontuario)
            .ThenInclude(p => p.PsicologoResponsavel)
           .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<DocumentoClinicoModel>> BuscarPorprontuarioIdAsync(int prontuarioId)
    {
        return await context.Set<DocumentoClinicoModel>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<DocumentoClinicoModel>> BuscarPorIdPsicologoAsync(string psicologoId)
    {
        // Nota técnica: Mapeado com base na Shadow Property "UsuarioId" ou propriedade física correspondente
        return await context.Set<DocumentoClinicoModel>()
            .AsNoTracking()
            .Where(d => EF.Property<string>(d, "UsuarioId") == psicologoId)
            .ToListAsync();
    }

    public async Task EditarAsync(DocumentoClinicoModel documentoClinico)
    {
        context.Entry(documentoClinico).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExcluirAsync(int id)
    {
      var linhasAfetadas = await context.Set<DocumentoClinicoModel>()
        .Where(d => d.Id == id)
        .ExecuteDeleteAsync();

    return linhasAfetadas > 0;
    }

   public async Task<bool> ArquivarAsync(int id)
{
    var documento = await context.Set<DocumentoClinicoModel>().FindAsync(id);
    if (documento is null) return false;

    documento.Ativo = true; 

    return await context.SaveChangesAsync() > 0;
}
}