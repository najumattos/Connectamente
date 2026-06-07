using Microsoft.AspNetCore.Mvc;
using Connectamente.API.DTOs;
using Connectamente.API.Services.Interfaces;

namespace Connectamente.API.Controllers;

public class PacientesController(IPacienteService service) : MainController
{

    /// <summary>
    /// Busca Todos Pacientes
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<UsuarioListaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<UsuarioListaDto>>> GetPacientes([FromQuery] AuthAcessoDto auth)
    {
        var resposta = await service.BuscarTodosPacientes();

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
            false when resposta.Error.Contains("permissao")
                  => StatusCode(StatusCodes.Status403Forbidden, resposta),
            _ => NotFound(resposta)
        };
    }

    /// <summary>
    /// Busca Paciente Por Id
    /// </summary>     
    [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PacienteDto>> GetPaciente(string id)
    {
        var resposta = await service.BuscarPacientePorId(id);

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
                false when resposta.Error.Contains("permissao")
                      => StatusCode(StatusCodes.Status403Forbidden, resposta),
                _ => NotFound(resposta)
            };
    }

    /// <summary>
    /// Arquiva Paciente
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("Arquivar")]
    public async Task<ActionResult> ArquivarPaciente(string id)
    {
        var resposta = await service.ArquivarPaciente(id);
        return resposta switch
        {
            null => NotFound(resposta.Error),
            _ => NoContent()
        };
    }

}
