using System.ComponentModel.DataAnnotations;

namespace Connectamente.API.DTOs;

public class EnderecoDto{
 [Display(Name = "Logradouro / Rua")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(200, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
    public string Logradouro { get; set; } = string.Empty; 

    [Display(Name = "Número")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(20, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
    public string Numero { get; set; } = string.Empty; 
    [Display(Name = "Bairro")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
    public string Bairro { get; set; } = string.Empty; 

    [Display(Name = "Cidade")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
    public string Cidade { get; set; } = string.Empty; 

    [Display(Name = "Estado (UF)")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O {0} deve conter exatamente {1} caracteres.")]
    public string Estado { get; set; } = string.Empty;

    [Display(Name = "CEP")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]    
    public string CEP { get; set; } = string.Empty; 

}