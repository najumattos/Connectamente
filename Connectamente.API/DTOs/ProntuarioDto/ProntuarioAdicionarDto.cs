using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.ProntuarioDto;

public class ProntuarioAdicionarDto{

    public int PacienteId { get; set; }

     [Display(Name = "Número do Prontuário")]
    public string NumeroProntuario { get; set; } = string.Empty;

    [Display(Name = "Situação do Prontuário")]
    public SituacaoEnum SituacaoProntuario { get; set; }

    [Display(Name = "Data de Cadastro")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime DataCriacao { get; set; }

    [Display(Name = "Observações Gerais")]
    [DataType(DataType.MultilineText)]
    public string? Observacoes { get; set; }
     [Display(Name = "Status do Cadastro")]
    public bool Ativo { get; set; }
}