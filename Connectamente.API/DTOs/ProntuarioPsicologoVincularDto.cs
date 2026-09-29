using System.ComponentModel.DataAnnotations;
using Connectamente.API.DTOs.PsicologoDto;

namespace Connectamente.API.DTOs;

public class ProntuarioPsicologoVincularDto
{
 [Required]
    public int Id { get; set; }

    [Display(Name = "Número do Prontuário")]
    public string NumeroProntuario { get; set; } = string.Empty; 

[Display(Name = "Última Atualização")]
[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
public DateTime? UltimaAtualizacao { get; set; }

    [Required]
    public int PacienteId { get; set; }

    [Display(Name = "Paciente")]
    public string PacienteNomeCompleto { get; set; } = string.Empty;

[Display(Name = "Psicologos Disponiveis")]
     public List<PsicologoListaDto> PsicologosDisponiveis { get; set; } = [];
}