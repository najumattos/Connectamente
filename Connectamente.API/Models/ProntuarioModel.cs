
using Connectamente.API.Enums;

namespace Connectamente.API.Models;
public class ProntuarioModel : EntityBase
{
    public string NumeroProntuario { get; set; } = string.Empty;
    public DateTime? DataPrimeiraConsulta { get; set; }
    public SituacaoEnum SituacaoProntuario { get; set; } = SituacaoEnum.Ativo;

    public ICollection<TratamentoAnteriorModel> TratamentosAnteriores { get; set; } = [];    
    public ICollection<DocumentoClinicoModel> DocumentosClinicos { get; set; } = [];   
    public ICollection<AuditoriaModel> Auditorias { get; set; } = [];
}