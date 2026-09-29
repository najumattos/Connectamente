

using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public class FamiliarModel : EntityBase
{
    public Identificacao? Identificacao { get; set; } 
    public Endereco? Endereco { get; set; }  

    public int ProntuarioId { get; set; } // FK Física
    public ProntuarioModel Prontuario { get; set; } = null!;
public ParentescoEnum Parentesco { get; set; }  
    public bool? TermoAutorizacaoMenor { get; set; } 
     public bool ResponsavelPrincipal { get; set; } 
}