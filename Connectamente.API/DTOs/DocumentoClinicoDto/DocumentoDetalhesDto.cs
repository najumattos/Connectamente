using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.DocumentoClinicoDto;

public class DocumentoDetalhesDto : EntityBaseDetalhesDto
{
public int Id { get; set; }
 public int? AtendimentoId { get; set; }    
    public string NomePsicologoResponsavel { get; set; } = string.Empty;   
    public TipoDocumentoClinicoEnum TipoDocumentoClinico { get; set; }
  public string NomeArquivo { get; set; } = string.Empty;
    public string CaminhoArquivo { get; set; } = string.Empty;
}