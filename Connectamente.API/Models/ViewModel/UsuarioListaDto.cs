using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.Models.ViewModel
{
    public class UsuarioListaDto
    {
        [Required] public string Id { get; set; }
        [Required] public string NomeCompleto { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Celular { get; set; }
        [Required] public bool Ativo { get; set; } = true;
        public string? PsicologoResponsavel { get; set; }


        /*
         * 
          Genérico o bastante para comportar uma lista de dados basicos de psicologos e pacientes e responsaveisPorPaciente
         */
    }
}
