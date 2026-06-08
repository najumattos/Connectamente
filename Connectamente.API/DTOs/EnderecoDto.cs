namespace Connectamente.API.DTOs;

public record EnderecoDto
{
    public string Logradouro { get; init; } = string.Empty;
    public string Numero { get; init; } = string.Empty;
    public string Bairro { get; init; } = string.Empty;
    public string Cidade { get; init; } = string.Empty;
    public string Estado { get; init; } = string.Empty;
    public string CEP { get; init; } = string.Empty;
}