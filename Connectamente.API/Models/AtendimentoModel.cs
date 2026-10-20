

using Connectamente.API.Enums;

namespace Connectamente.API.Models;

public class AtendimentoModel : EntityBase
{
    public int VinculoPacientePsicologoId { get; set; }
    public VinculoPacientePsicologoModel VinculoPacientePsicologo { get; set; } = null!;

    public int ProntuarioId { get; set; }
    public ProntuarioModel Prontuario { get; set; } = null!;

    public TipoAtendimentoEnum TipoAtendimento { get; set; }

    public DateTime? DataHoraInicio { get; set; }
    public DateTime? DataHoraFim { get; set; }

    public StatusAtendimentoEnum StatusAtendimento { get; set; }
        

    public ICollection<DocumentoClinicoModel> DocumentosClinicos { get; set; } = [];
}