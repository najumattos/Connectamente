using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.TratamentoAnteriorDto;

public class TratamentoAnteriorListaDto
{
   [Required]
    public int Id { get; set; }

    [Display(Name = "Tipo de Tratamento")]
    public TipoTratamentoAnteriorEnum TipoTratamento { get; set; } 

    [Display(Name = "Houve Internação?")]
    public bool Internacao { get; set; }

    [Display(Name = "Motivo da Internação")]
    public string? MotivoInternacao { get; set; }
}