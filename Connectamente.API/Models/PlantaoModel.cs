namespace Connectamente.API.Models;

public class PlantaoModel : EntityBase
{
    public int PacienteId { get; set; }
    public PacienteModel Paciente { get; set; } = null!;

    public int VinculoPacientePsicologoId { get; set; }
    public VinculoPacientePsicologoModel VinculoPacientePsicologo
        { get; set; } = null!;
    public StatusPlantaoEnum StatusPlantao { get; set; }
    
    public ICollection<DocumentoClinicoModel> DocumentosClinicos
        { get; set; } = new List<DocumentoClinicoModel>();
}