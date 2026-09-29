using System.ComponentModel.DataAnnotations;
namespace Connectamente.API.Models;

public class VinculoProntuarioPsicologoModel
{
[Required]
    public int ProntuarioId { get; set; }

    [Required]
    public string PsicologoId { get; set; } = string.Empty;
}