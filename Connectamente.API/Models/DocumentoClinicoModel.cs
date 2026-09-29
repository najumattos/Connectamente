using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public class DocumentoClinicoModel : EntityBase
{
      public int ProntuarioId { get; set; } // FK Física
    public ProntuarioModel Prontuario { get; set; } = null!;
    public int? AtendimentoId { get; set; }    
    public string UsuarioResponsavelId { get; set; } = string.Empty;   
    public TipoDocumentoClinicoEnum TipoDocumentoClinico { get; set; }
  public string NomeArquivo { get; set; } = string.Empty;
    public string CaminhoArquivo { get; set; } = string.Empty; // Onde o arquivo físico está armazenado
    public AtendimentoModel? Atendimento { get; set; }
    public ApplicationUserModel Usuario { get; set; } = null!;
}