using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Data.Repositories.ConsultaRepository
{
    public interface IConsultaRepository
    {
        public Task<Result<IEnumerable<ConsultaDto>>> BuscarTodasConsultas();
        public Task<Result<IEnumerable<ConsultaDto>>> FiltrarConsultasPorPsicologo(string idPsicologo);

        public Task<Result<ConsultaDto>> BuscarConsultaPorId(string idConsulta);
        public Task<Result<bool>> AlterarStatusConsulta(string idConsulta);
    }
}
