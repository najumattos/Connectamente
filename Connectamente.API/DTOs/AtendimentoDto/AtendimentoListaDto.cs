using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.AtendimentoDto;

public class AtendimentoListaDto
{
    public int Id { get; set; }
    [Display(Name = "Número do Prontuario")]
    public string? NumeroProntuario { get; set; } = string.Empty;

    [Display(Name = "Tipo Atendimento")]
    public TipoAtendimentoEnum TipoAtendimento { get; set; }
    [Display(Name = "Data")]
    public DateTime? DataHoraInicio { get; set; }
    [Display(Name = "Status")]
    public StatusAtendimentoEnum StatusAtendimento { get; set; } = StatusAtendimentoEnum.Agendado;

    [Display(Name = "Paciente")]
    public string? NomePaciente { get; set; } = string.Empty;
    [Display(Name = "Psicologo")]
    public string? PsicologoResponsavel { get; set; } = string.Empty;
}