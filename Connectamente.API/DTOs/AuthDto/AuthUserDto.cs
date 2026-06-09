using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.AuthDto;

public record AuthUserDto
{
 public int Id { get; init; }
    public string NomeCompleto { get; init; } = string.Empty;  
    public string Email { get; init; } = string.Empty; 
    public TipoUsuarioEnum TipoUsuario { get; init; } 
}