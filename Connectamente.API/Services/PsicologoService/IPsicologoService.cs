using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Services.PsicologoService;

public interface IPsicologoService
{
    public Task<Result<UsuarioListaDto>> BuscarTodosPsicologos();
    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo);

}
