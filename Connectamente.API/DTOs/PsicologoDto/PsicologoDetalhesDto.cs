using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.PsicologoDto;

public class PsicologoDetalhesDto : EntityBaseDetalhesDto
{
  public string Id { get; set; }
  public string NomeCompleto { get; set; } = string.Empty;
    public string? Cpf { get; set; }
    public string? Matricula { get; set; }
    public string? Crp { get; set; }
    public TipoUsuarioEnum TipoUsuario { get; set; }
    public bool Ativo { get; set; } = true;
    public bool AssinouTermoResponsabilidadeEstagiario { get; set; } = false;   
    public DateTime DataCadastro { get; set; } 
    public string? Email { get; set; }
    public string? Telefone { get; set;}
}