using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.ProntuarioDto;

public class ProntuarioListaDto
{
   public int Id { get; init; }

    [Display(Name = "Paciente")]
    public string NomeCompletoPaciente { get; init; } = string.Empty;

    [Display(Name = "Psicólogo Responsável")]
    public string NomePsicologoResponsavel { get; init; } = string.Empty;

    [Display(Name = "Nº do Prontuário")]
    public string NumeroProntuario { get; init; } = string.Empty;

    [Display(Name = "Status do Prontuário")]
    public SituacaoEnum SituacaoProntuario { get; init; }

    /// <summary>
    /// Propriedade utilitária para renderização de badges HTML estilizadas (Bootstrap / Tailwind) baseadas no Enum.
    /// </summary>
    public string ClassCorStatus => SituacaoProntuario switch
    {
        SituacaoEnum.Ativo => "badge-success",
        SituacaoEnum.Arquivado => "badge-secondary",
        _ => "badge-info"
    };
}