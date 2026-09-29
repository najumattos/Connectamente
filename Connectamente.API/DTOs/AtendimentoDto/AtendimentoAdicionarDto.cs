using System.ComponentModel.DataAnnotations;
using Connectamente.API.Enums;
using Connectamente.API.Models;

namespace Connectamente.API.DTOs.AtendimentoDto;

public class AtendimentoAdicionarDto
{
   [Required(ErrorMessage = "O prontuário é obrigatório.")]
    [Display(Name = "Prontuário")]
    public int ProntuarioId { get; set; }
    [Required(ErrorMessage = "O tipo de atendimento é obrigatório.")]
    [Display(Name = "Tipo de Atendimento")]
    public TipoAtendimentoEnum TipoAtendimento { get; set; }

    [Required(ErrorMessage = "A data e hora de início são obrigatórias.")]
    [DataType(DataType.DateTime)]
    [Display(Name = "Data/Hora de Início")]
    public DateTime DataHoraInicio { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O status do atendimento é obrigatório.")]
    [Display(Name = "Status do Atendimento")]
    public StatusAtendimentoEnum StatusAtendimento { get; set; } = StatusAtendimentoEnum.Agendado;

    [Display(Name = "Observações Gerais")]
    [DataType(DataType.MultilineText)]
    [StringLength(500, ErrorMessage = "As observações não podem exceder {1} caracteres.")]
    public string? Observacoes { get; set; }

    [Required(ErrorMessage = "A data do agendamento é obrigatória.")]
    [DataType(DataType.Date)]
    [Display(Name = "Data do Agendamento")]
    public DateTime DataAgendamento { get; set; } = DateTime.Today;
}