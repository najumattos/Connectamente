using Connectamente.API.Domain;
using Connectamente.API.Enums;
using Connectamente.API.Models.ViewModel;

namespace Connectamente.API.Services.PsicologoService;

public class PsicologoService() : IPsicologoService
{
    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UsuarioListaDto>> BuscarTodosPsicologos()
    {
        /*TODO:Testar Adc Mock*/
        throw new NotImplementedException();
    }
}

