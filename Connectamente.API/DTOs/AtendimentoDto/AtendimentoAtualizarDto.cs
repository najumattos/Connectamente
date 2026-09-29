using Connectamente.API.Enums;

namespace Connectamente.API.DTOs.AtendimentoDto;

public class AtendimentoAtualizarDto
{
    public int Id { get; set; }
    public EntityBaseDetalhesDto? DadosAuditaveis { get; set; }
    public TipoAtendimentoEnum TipoAtendimento { get; set; }
    public DateTime? DataHoraInicio { get; set; }
    public DateTime? DataHoraFim { get; set; }
    public StatusAtendimentoEnum StatusAtendimento { get; set; } = StatusAtendimentoEnum.Agendado;
}