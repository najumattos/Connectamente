using Connectamente.API.Domain;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Services.PsicologoService;

public interface IPsicologoService
{
    public Task<Result<IEnumerable<UsuarioListaDto>>> BuscarTodosPsicologos(AuthAcessoDto authAcessoDto);
    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(AuthAcessoDto authAcessoDto, string idPsicologo);

}
