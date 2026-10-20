namespace Connectamente.API.Models;

public class VinculoPacientePsicologoModel : EntityBase
{
    public int PacienteId { get; set; }
    public PacienteModel Paciente { get; set; } = null!;     
     public string PsicologoResponsavelId { get; set; }   
    public ApplicationUserModel PsicologoResponsavel { get; set; }
    public DateTime? DataEncerramento { get; set; }

}