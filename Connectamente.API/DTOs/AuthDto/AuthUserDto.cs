using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.AuthDto;

public record AuthUserDto
{
 public string Id { get; init; }= string.Empty;
    public string NomeCompleto { get; init; } = string.Empty;  
    public string Email { get; init; } = string.Empty; 
    public TipoUsuarioEnum TipoUsuario { get; init; } 
    public string Token { get; set; } = string.Empty;
    
}