using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.TratamentoAnteriorDto;

public class TratamentoAnteriorAdicionarDto
{  
    [Required(ErrorMessage = "O identificador do prontuário é obrigatório.")]
    public int ProntuarioId { get; set; }

    public string? NomePaciente { get; set; }

    [Display(Name = "Tipo de Tratamento")]
    public TipoTratamentoAnteriorEnum TipoTratamento { get; set; }

    [Display(Name = "Sofreu Internação?")]
    public bool Internacao { get; set; }

    [Display(Name = "Motivo da Internação")]
    public string? MotivoInternacao { get; set; }

    [Display(Name = "Observações")]
    public string? Observacoes { get; set; }
}