

namespace Connectamente.API.Models;

public class PacienteModel : EntityBase
{    
    public Identificacao? Identificacao { get; set; } 
    public Endereco? Endereco { get; set; } 
    public ProntuarioModel? Prontuario { get; set; }    
    public ICollection<AuditoriaModel> Auditorias { get; set; } = [];
}