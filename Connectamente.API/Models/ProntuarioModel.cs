

namespace Connectamente.API.Models;
public class ProntuarioModel : EntityBase
{
        public int PacienteId { get; set; }
    public PacienteModel Paciente { get; set; } = null!;
    public string NumeroProntuario { get; set; } = string.Empty;
public int PlantaoId { get; set; }
    public PlantaoModel Plantao { get; set; } = null!;
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    
        public ICollection<TratamentoAnteriorModel> TratamentosAnteriores { get; set; } = [];    
    public ICollection<DocumentoClinicoModel> DocumentosClinicos { get; set; } = [];   
    public ICollection<AuditoriaModel> Auditorias { get; set; } = [];
}