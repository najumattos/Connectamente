using Connectamente.API.DTOs.DocumentoClinicoDto;
using Connectamente.API.Enums;
using Connectamente.API.Models;

namespace Connectamente.API.DTOs.AtendimentoDto;

public class AtendimentoDetalhesDto : EntityBaseDetalhesDto
{
    public int Id { get; set; }
 public string? NumeroProntuario { get; set; }  = string.Empty;
  public string? NomePaciente { get; set; }  = string.Empty;
    public TipoAtendimentoEnum TipoAtendimento { get; set; }
    public DateTime? DataHoraInicio { get; set; }
    public DateTime? DataHoraFim { get; set; }
    public StatusAtendimentoEnum StatusAtendimento { get; set; } = StatusAtendimentoEnum.Agendado;
    public ProntuarioModel Prontuario { get; set; } = null!;
    
    public ICollection<DocumentoListaDto> DocumentosClinicos { get; set; } = [];    
}