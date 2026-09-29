using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs;

public class IdentificacaoDto
{
    [Required(ErrorMessage = "O nome completo é obrigatório.")]
    [StringLength(150, ErrorMessage = "O nome não pode exceder 150 caracteres.")]
    public string NomeCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [StringLength(11, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
    public string? CPF { get; set; }

    [StringLength(20, ErrorMessage = "O RG não pode exceder 20 caracteres.")]
    public string? RG { get; set; }

    [Required(ErrorMessage = "O telefone principal é obrigatório.")]
    [StringLength(20, ErrorMessage = "O telefone não pode exceder 20 caracteres.")]
    public string TelefonePrincipal { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "O telefone de recado não pode exceder 20 caracteres.")]
    public string? TelefoneRecado { get; set; }

    public EscolaridadeEnum? Escolaridade { get; set; }
    public GeneroEnum? Genero { get; set; }

    [StringLength(100, ErrorMessage = "A profissão não pode exceder 100 caracteres.")]
    public string? Profissao { get; set; }

    [EmailAddress(ErrorMessage = "O formato do e-mail é inválido.")]
    [StringLength(150, ErrorMessage = "O e-mail não pode exceder 150 caracteres.")]
    public string? Email { get; set; }
    public int? Idade { get; set; }
    public EstadoCivilEnum? EstadoCivil { get; set; }

    [StringLength(100, ErrorMessage = "A naturalidade não pode exceder 100 caracteres.")]
    public string? Naturalidade { get; set; }

    [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve conter 2 caracteres.")]
    public string? EstadoNascimento { get; set; }

    [StringLength(50, ErrorMessage = "A religião não pode exceder 50 caracteres.")]
    public string? Religiao { get; set; }
}