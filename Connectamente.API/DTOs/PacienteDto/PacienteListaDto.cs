namespace Connectamente.API.DTOs.PacienteDto;

public record PacienteListaDto
{
    public int Id { get; init; }
    public string NomeCompleto { get; init; } = string.Empty;  
    public string? Telefone { get; init; }
    public string? TelefoneRecado { get; init; }
    public int? Idade { get; init; }
    public string? ResponsavelLegal { get; init; }
    public bool Ativo { get; init; }
}