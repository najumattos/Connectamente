

namespace Connectamente.API.Models;

public class AuditoriaModel 
{
    public long Id { get; set; }    
    public string? UsuarioEmail { get; set; } = string.Empty;
    public string TipoAcao { get; set; } = string.Empty;
    public string NomeTabela { get; set; } = string.Empty;
      public string RegistroId { get; set; } = string.Empty; // O ID do registro alterado (como string para aceitar qualquer tipo de chave)
   public DateTime DataHora { get; set; } = DateTime.UtcNow; // Sempre salvar em formato UTC  
public string? ValoresAntigos { get; set; } // JSON com o estado do registro ANTES da alteração

public string? ValoresNovos { get; set; } // JSON com o estado do registro DEPOIS da alteração
}
