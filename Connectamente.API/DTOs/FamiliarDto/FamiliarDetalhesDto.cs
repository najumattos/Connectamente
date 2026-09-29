using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.FamiliarDto;

public class FamiliarDetalhesDto : EntityBaseDetalhesDto
{
    public int Id { get; set; }
    public int ProntuarioId { get; set; }
    public IdentificacaoDto? Identificacao { get; set; }
   public EnderecoDto? Endereco { get; set; }
       public bool? TermoAutorizacaoMenor { get; set; } 
     public bool ResponsavelPrincipal { get; set; } 
     public ParentescoEnum Parentesco { get; set; }
} 
     