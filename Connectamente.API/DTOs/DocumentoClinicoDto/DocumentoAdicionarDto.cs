using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.DocumentoClinicoDto;

public class DocumentoAdicionarDto
{
    public EntityBaseDetalhesDto DadosAuditaveis { get; set; }
    public int AtendimentoId { get; set; }    //vem da rota    
 public int ProntuarioId { get; set; } //somente leitura
 public string NumeroProntuario { get; set; }= string.Empty;
    public string UsuarioResponsavelId { get; set; } = string.Empty;   //vem de quem ta logado
    public TipoDocumentoClinicoEnum TipoDocumentoClinico { get; set; }
  public string NomeArquivo { get; set; } = string.Empty;
    public string CaminhoArquivo { get; set; } = string.Empty; // Onde o arquivo físico está armazenado <Folder Include="wwwroot\docsClinicosAnexados" />

}