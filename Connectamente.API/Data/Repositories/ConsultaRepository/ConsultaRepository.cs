using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.ConsultaRepository;

public class ConsultaRepository : IConsultaRepository
{
    /// <summary>
    /// 
    /// </summary>
    public Task<Result<bool>> AlterarStatusConsulta(string idConsulta)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retorna Dados de uma Consulta
    /// </summary>  
    public Task<Result<ConsultaDto>> BuscarConsultaPorId(string idConsulta)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retorna Todas As Consultas
    /// </summary>  
    public Task<Result<IEnumerable<ConsultaDto>>> BuscarTodasConsultas()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retorna todas as Consultas de um Psicologo
    /// </summary>
    public Task<Result<IEnumerable<ConsultaDto>>> FiltrarConsultasPorPsicologo(string idPsicologo)
    {
        throw new NotImplementedException();
    }
}
