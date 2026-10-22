

using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public class AgendamentoModel : EntityBase
{
    public int VinculoPacientePsicologoId { get; set; }//referece a qual psicologo atendeu tal paciente
    public VinculoPacientePsicologoModel VinculoPacientePsicologo { get; set; } = null!;

       public TipoAtendimentoEnum TipoAtendimento { get; set; }

    public DateTime? DataHoraInicio { get; set; }
    public DateTime? DataHoraFim { get; set; }

    public StatusAtendimentoEnum StatusAtendimento { get; set; }            
}