using Connectamente.API.DTOs;
using Connectamente.API.DTOs.PacienteDto;
using FluentResults;
namespace Connectamente.API.Services.Interfaces;

public interface IPsicologoService
{
    public Task<Result<IEnumerable<PacienteListaDto>>> BuscarTodosPsicologos();
    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo);
    public Task<Result<bool>> DesativarPsicologo(string psicologoId);
}
