using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public class TratamentoAnteriorModel : EntityBase
{
    public int PacienteId { get; set; }
    public PacienteModel Paciente { get; set; } = null!;
    public int? ProntuarioModelId { get; set; } 
    public ProntuarioModel? Prontuario { get; set; }
    public TipoTratamentoAnteriorEnum TipoTratamento { get; set; }
    public bool Internacao { get; set; }
    public string? MotivoInternacao { get; set; }
    public string? Observacoes { get; set; }
}