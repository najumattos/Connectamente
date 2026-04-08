using Connectamente.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Connectamente.API.Models;

[Table("Paciente")]
public class PacienteModel
{
    [Key] public string PacienteId { get; set; }

    [Required]public string UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public virtual UsuarioModel Usuario { get; set; }
    public string PsicologoResponsavelId { get; set; }
    [ForeignKey("PsicologoResponsavelId")]
    [Required(ErrorMessage = "O psicologo é obrigatório.")]
    public virtual PsicologoModel PsicologoResponsavel { get; set; }
    
    [Required] public string ContatoEmergencia { get; set; }  

}

