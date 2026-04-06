using Connectamente.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.Models.ViewModel
{
    public class PacienteDto
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string PsicologoResponsavelId { get; set; }

    }
}
