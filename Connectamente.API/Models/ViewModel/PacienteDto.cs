using Connectamente.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.Models.ViewModel
{
    public class PacienteDto
    {
        [Required] public string Id { get; set; }
        [Required] public string IdUsuario { get; set; }

        [Required] public DateOnly PrimeiraConsulta { get; set; }
        [Required] public DateOnly DataNascimento { get; set; }
        [Required] public string Sexo { get; set; }

        [Required] public string NomeCompleto { get; set; }
        [Required] public string Telefone { get; set; }
        [Required] public bool Ativo { get; set; } = true;
        [Required] public string ContatoEmergencia { get; set; }
        [Required] public string HistoricoPaciente { get; set; }
        [Required] public string PsicologoResponsavelId { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }

    }
}
