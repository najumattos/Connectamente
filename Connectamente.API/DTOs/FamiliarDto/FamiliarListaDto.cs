using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.FamiliarDto;

public class FamiliarListaDto
{
    public int Id { get; set; }
    [Display(Name = "Nome Completo")]
    public string NomeCompleto { get; set; } = string.Empty;

    [Display(Name = "Grau de Parentesco")]
    public ParentescoEnum Parentesco { get; set; }
    [Display(Name = "Telefone de Contato")]
    public string Telefone { get; set; } = string.Empty;
    [Display(Name = "Responsável Principal")]
    public bool ResponsavelPrincipal { get; set; }
}