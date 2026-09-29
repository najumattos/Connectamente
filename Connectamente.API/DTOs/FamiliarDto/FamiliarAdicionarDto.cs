
using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.FamiliarDto;

public class FamiliarAdicionarDto
{
        [Required(ErrorMessage = "O identificador do prontuário é obrigatório.")]
    public int ProntuarioId { get; set; }
    public IdentificacaoDto? Identificacao { get; set; }
    [Display(Name = "Data de Cadastro")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DataCriacao { get; set; }
   public EnderecoDto? Endereco { get; set; }
       public bool? TermoAutorizacaoMenor { get; set; } 
     public bool ResponsavelPrincipal { get; set; } 
     public ParentescoEnum Parentesco { get; set; } 
     public string Observacoes { get; set; } = string.Empty;
}