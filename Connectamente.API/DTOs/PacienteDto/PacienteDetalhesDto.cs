using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs.PacienteDto;

public class PacienteDetalhesDto : EntityBaseDetalhesDto
{
    [Required] public int Id { get; set; }
    public IdentificacaoDto? Identificacao { get; set; } 
    public EnderecoDto? Endereco { get; set; } 
     [Display(Name = "Idade")]
    public int? Idade { get; set; }

    [Display(Name = "Familiar Principal")]
    public string? ResponsavelLegal { get; set; }

    [Display(Name = "Número do Prontuário")]
    public string NumeroProntuario { get; set; } = string.Empty;
   
}