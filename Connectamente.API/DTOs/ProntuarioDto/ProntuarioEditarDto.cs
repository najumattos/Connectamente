using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.ProntuarioDto;

public class ProntuarioEditarDto
{
public int Id { get; set; }
    
    [Display(Name = "Situação do Prontuário")]
    public SituacaoEnum SituacaoProntuario { get; set; }

    [Display(Name = "Observações Gerais")]
    [DataType(DataType.MultilineText)]
    public string? Observacoes { get; set; }
     [Display(Name = "Status do Cadastro")]
    public bool Ativo { get; set; }
}
