using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.TratamentoAnteriorDto;

//tambem serve para editar 
public class TratamentoAnteriorDetalhesDto : EntityBaseDetalhesDto
{
    [Required]
    public int Id { get; set; }

    [Display(Name = "Paciente")]
    public string NomePaciente { get; set; } = string.Empty;

    [Display(Name = "Tipo de Tratamento")]
    public TipoTratamentoAnteriorEnum TipoTratamento { get; set; }

    [Display(Name = "Sofreu Internação?")]
    public bool Internacao { get; set; }

    [Display(Name = "Motivo da Internação")]
    public string? MotivoInternacao { get; set; }
}