

using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public class AtendimentoModel : EntityBase
{
    public int ProntuarioId { get; set; }  
    public TipoAtendimentoEnum TipoAtendimento { get; set; }
    public DateTime? DataHoraInicio { get; set; }
    public DateTime? DataHoraFim { get; set; }
    public StatusAtendimentoEnum StatusAtendimento { get; set; } = StatusAtendimentoEnum.Agendado;
    public ProntuarioModel Prontuario { get; set; } = null!;
    
    public ICollection<DocumentoClinicoModel> DocumentosClinicos { get; set; } = [];    
}
