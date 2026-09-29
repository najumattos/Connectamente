using Connectamente.API.Enums;
namespace Connectamente.API.Models;

public class TratamentoAnteriorModel : EntityBase
{
    public int ProntuarioId { get; set; } 
    public ProntuarioModel? Prontuario { get; set; }
    public TipoTratamentoAnteriorEnum TipoTratamento { get; set; }
    public bool Internacao { get; set; }
    public string? MotivoInternacao { get; set; }
}