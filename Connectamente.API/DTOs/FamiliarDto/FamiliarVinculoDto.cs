using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.FamiliarDto;

public class FamiliarVinculoDto
{
    [Required(ErrorMessage = "O identificador do paciente é obrigatório.")]
    public int PacienteId { get; set; }    
    public string NomeCompletoPaciente { get; set; } = string.Empty;
    public bool PacienteMenorDeIdade { get; set; }
     [Display(Name = "Grau de Parentesco")]
    public ParentescoEnum Parentesco { get; set; }
    public bool ResponsavelPrincipal { get; set; }
    public bool TermoAutorizacaoMenor { get; set; }
}