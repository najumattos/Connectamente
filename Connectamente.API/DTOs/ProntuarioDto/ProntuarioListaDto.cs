using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.ProntuarioDto;

public record ProntuarioListaDto
{
    public int Id { get; init; }
    public string NomeCompletoPaciente { get; init; } = string.Empty;  
    public string NomePsicologoResponsavel { get; init; } = string.Empty;  
    public string NumeroProntuario { get; init; } = string.Empty; 
    public SituacaoProntuarioEnum SituacaoProntuario { get; init; } 
}