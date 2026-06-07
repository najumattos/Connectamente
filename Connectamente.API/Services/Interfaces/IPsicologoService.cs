using Connectamente.API.Domain;
using Connectamente.API.DTOs;
namespace Connectamente.API.Services.Interfaces;

public interface IPsicologoService
{
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPsicologos();
    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo);
    public Task<Result<bool>> DesativarPsicologo(string psicologoId);
}
