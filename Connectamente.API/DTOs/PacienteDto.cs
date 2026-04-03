using Connectamente.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs
{
    public class PacienteDto
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
    }
}
