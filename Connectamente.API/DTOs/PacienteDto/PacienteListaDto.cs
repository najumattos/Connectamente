using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs.PacienteDto;

public class PacienteListaDto
{
   [Required]
    public int Id { get; set; }

    [Display(Name = "Nome Paciente")]
    public string NomeCompleto { get; set; } = string.Empty;  

    [Display(Name = "Telefone")]
    public string? Telefone { get; set; }

    [Display(Name = "Familiar Responsável")]
    public string? TelefoneRecado { get; set; }

    [Display(Name = "Idade")]
    public int? Idade { get; set; }
    
    [Display(Name = "Familiar Principal")]
    public string? ResponsavelLegal { get; set; }

    [Display(Name = "Status")]
    public bool Ativo { get; set; }

        [Display(Name = "Número Prontuario")]
    public string? NumeroProntuario { get; set; }
}