using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.PsicologoDto;

public class PsicologoListaDto
{
public string PsicologoResponsavelId { get; set; } = string.Empty;
public string NomeCompleto { get; set; } = string.Empty;
public string? Matricula { get; set; }
public string? Email { get; set; } //vem do identity
public string? Telefone { get; set; } //vem do identity
public TipoUsuarioEnum TipoUsuario { get; set; }
public bool Ativo { get; set; } = true;

}