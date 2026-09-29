using Connectamente.API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
namespace Connectamente.API.Data;
public class AuditEntry(EntityEntry entry)
{

    public EntityEntry Entry { get; } = entry;
    public string? UsuarioId { get; set; }
    public string UsuarioEmail { get; set; } = string.Empty;
    public string NomeTabela { get; set; } = string.Empty;
    public string TipoAcao { get; set; } = string.Empty;
    public string RegistroId { get; set; } = string.Empty;
    public Dictionary<string, object> ValoresAntigos { get; } = new();
    public Dictionary<string, object> ValoresNovos { get; } = new();
    public List<PropertyEntry> PropriedadesTemporarias { get; } = new();

    public AuditoriaModel ToAudit()
    {
        return new AuditoriaModel
        {
            UsuarioEmail = UsuarioEmail,
            TipoAcao = TipoAcao,
            NomeTabela = NomeTabela,
            RegistroId = RegistroId,
            ValoresAntigos = ValoresAntigos.Count == 0 ? null : JsonSerializer.Serialize(ValoresAntigos),
            ValoresNovos = ValoresNovos.Count == 0 ? null : JsonSerializer.Serialize(ValoresNovos),
            DataHora = DateTime.UtcNow
        };
    }
}