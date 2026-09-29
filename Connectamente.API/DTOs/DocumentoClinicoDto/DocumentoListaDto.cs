using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs.DocumentoClinicoDto;

public class DocumentoListaDto
{
 [Required]    public int Id { get; set; }

    [Display(Name = "Tipo de Documento")]
      public string NomeArquivo { get; set; } = string.Empty;

    [Display(Name = "Data de Criação")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DataCriacao { get; set; }
}