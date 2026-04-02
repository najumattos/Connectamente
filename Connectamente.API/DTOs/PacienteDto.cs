using Connectamente.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs
{
    public class PacienteDto
    {
        public string NomeCompleto { get; set; }
        public string ContatoEmergencia { get; set; }
        public string Historico { get; set; }
    }
}
