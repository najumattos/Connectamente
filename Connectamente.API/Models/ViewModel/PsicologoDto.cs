using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.Models.ViewModel
{
    public class PsicologoDto
    {
        [Required] public string Id { get; set; }
        [Required] public string IdUsuario { get; set; }
        [Required] public string NomeCompleto { get; set; }
        [Required] public string Telefone { get; set; }
        [Required] public DateOnly DataNascimento { get; set; }
        [Required] public string Email { get; set; }
        [Required] public bool Ativo { get; set; } = true;
        public string Foto { get; set; }
    }
}
