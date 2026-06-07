using Connectamente.API.Domain;
using Connectamente.API.DTOs;

namespace Connectamente.API.Services.Interfaces;

public interface IConsultaService
{
    public Task<Result<IEnumerable<ConsultaDto>>> BuscarTodasConsultas();
    public Task<Result<ConsultaDto>> BuscarConsultaPorId(string idPaciente);
    public Task<Result<bool>> AlterarStatusConsulta(string id);
}
