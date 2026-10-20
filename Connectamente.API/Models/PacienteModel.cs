

namespace Connectamente.API.Models;

public class PacienteModel : EntityBase
{    
    public Identificacao? Identificacao { get; set; } 
    public Endereco? Endereco { get; set; } 
    public ProntuarioModel? Prontuario { get; set; }    
    public ICollection<FamiliarModel> Familiares { get; set; } = [];
    public ICollection<AtendimentoModel> Atendimentos { get; set; } = [];
    public ICollection<VinculoPacientePsicologoModel> VinculosPacientePsicologo { get; set; } = [];
    public ICollection<AuditoriaModel> Auditorias { get; set; } = [];
}