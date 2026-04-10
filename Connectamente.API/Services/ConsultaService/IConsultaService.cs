using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Services.ConsultaService
{
    public interface IConsultaService
    {
        public Task<Result<IEnumerable<ConsultaDto>>> BuscarConsultas(AuthAcessoDto authAcessoDto);
        public Task<Result<ConsultaDto>> BuscarConsultaPorId(AuthAcessoDto authAcessoDto, string idPaciente);
        public Task<Result<bool>> AlterarStatusConsulta(AuthAcessoDto authAcessoDto, string id);
    }
}
