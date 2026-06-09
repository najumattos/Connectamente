namespace Connectamente.API.DTOs.AuthDto;

public record LoginDto
{
    public string Email { get; init; } = string.Empty; 
    public string Senha { get; init; } = string.Empty; 
    public bool LembrarDeMim { get; init; } = false;
}