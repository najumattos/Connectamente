namespace Connectamente.API.Models;

public class TermoResponsabilidadeEstagiario : EntityBase
{
    public string EstagiarioUsuarioId { get; set; } = string.Empty;
    public string? MatriculaInformada { get; set; }
    public bool DeclarouRecebimentoManual { get; set; }
    public bool DeclarouCienciaNormas { get; set; }
    public DateTime? DataAssinatura { get; set; }
    public string? Observacoes { get; set; }

    public ApplicationUserModel EstagiarioUsuario { get; set; }
}