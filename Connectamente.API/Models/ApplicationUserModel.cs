using Connectamente.API.Enums;
using Microsoft.AspNetCore.Identity;

namespace Connectamente.API.Models;

public class ApplicationUserModel : IdentityUser
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string? Matricula { get; set; }
    public string? Crp { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public bool Ativo { get; set; } = true;
    public bool AssinouTermoResponsabilidadeEstagiario { get; set; } = false;   
    public DateTime DataCadastro { get; set; }   
    public ICollection<DocumentoClinicoModel> DocumentosCriados { get; set; } = [];
    public ICollection<AuditoriaModel> Auditorias { get; set; } = [];
       public ICollection<ProntuarioModel> ProntuariosResponsavel { get; set; } = [];
}
