using Connectamente.API.Enums;
using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.Models.ViewModel
{
    public class UsuarioListaDto
    {
        [Required] public string Id { get; set; }    //pode ser idPsicologo ou idPaciente
        [Required] public string NomeCompleto { get; set; }          
        [Required] public string Email { get; set; }
        [Required] public string Celular { get; set; }
        [Required] public bool Ativo { get; set; } = true;
        [Required] public TipoPerfilEnum TipoPerfil { get; set; }        //se paciente os campos abaixo são retornados tambem
        public string? Foto { get; set; }
        public string? PsicologoResponsavelId { get; set; }           //se for paciente, nulo se psicologo
        public TipoProntuarioEnum? TipoPaciente { get; set; }           //se for paciente(adulto/infantil), nulo se psicologo


        /*
         * Flat DTO (DTO Achatado). É ótimo para performance e simplicidade.
          Genérico o bastante para comportar uma lista de dados basicos de psicologos e pacientes
         */
    }
}
