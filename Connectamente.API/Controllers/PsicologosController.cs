using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Services.PsicologoService;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Services.PacienteService;

namespace Connectamente.API.Controllers;

public class PsicologosController(IPsicologoService service) : MainController
{

    /// <summary>
    /// Busca Todos Psicologos
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<UsuarioListaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<UsuarioListaDto>>> GetPsicologos(AuthAcessoDto auth)
    {
        var resposta = await service.BuscarPsicologos(auth);

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
            false when resposta.Error.Contains("permissão")
                  => StatusCode(StatusCodes.Status403Forbidden, resposta),
            _ => NotFound(resposta)
        };
    }

    /// <summary>
    /// Busca Dados do Psicologo
    /// </summary>     
    [ProducesResponseType(typeof(PsicologoDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PsicologoDto>> GetPsicologo(AuthAcessoDto auth, string id)
    {
        var resposta = await service.BuscarPsicologoPorId(auth, id);

        return resposta.IsSuccess switch
        {                                     
            true => Ok(resposta.Value),
            false when resposta.Error.Contains("permissão")
                  => StatusCode(StatusCodes.Status403Forbidden, resposta),
            _ => NotFound(resposta)
        };
    }
}
