using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs;

public class VinculoProntuarioPsicologoDto
{
[Required]
    public int ProntuarioId { get; set; }

    [Required]
    public string PsicologoId { get; set; } = string.Empty;
}