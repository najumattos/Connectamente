using Connectamente.API.DTOs;
using Connectamente.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

public class PsicologosController(IPsicologoService service) : MainController
{

    /// <summary>
    /// Busca Todos Psicologos
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<UsuarioListaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<UsuarioListaDto>>> GetPsicologos()
    {
        var resposta = await service.BuscarTodosPsicologos();

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
            false when resposta.Error.Contains("permissao")
                  => StatusCode(StatusCodes.Status403Forbidden, resposta),
            _ => NotFound(resposta)
        };
    }

    /// <summary>
    /// Busca Psicologo Por Id
    /// </summary>     
    [ProducesResponseType(typeof(PsicologoDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PsicologoDto>> GetPsicologo(string id)
    {
        var resposta = await service.BuscarPsicologoPorId(id);

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
            false when resposta.Error.Contains("permissao")
                  => StatusCode(StatusCodes.Status403Forbidden, resposta),
            _ => NotFound(resposta)
        };
    }

    /// <summary>
    /// Desativa Psicologo
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("Desativar/{id}")]
    public async Task<ActionResult> DesativarPsicologo([FromQuery] AuthAcessoDto auth, string id)
    {
        var resposta = await service.DesativarPsicologo(id);
        return resposta switch
        {
            null => NotFound(resposta.Error),
            _ => NoContent()
        };
    }
}
