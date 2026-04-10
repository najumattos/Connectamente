using Microsoft.AspNetCore.Mvc;
using Connectamente.API.Services.PacienteService;
using System;
using Connectamente.API.Enums;
using Connectamente.API.Services;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Domain;

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
        var resposta = await service.BuscarPacientes(auth);

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
            false when resposta.Error.Contains("permissão")
                  => StatusCode(StatusCodes.Status403Forbidden, resposta),
            _ => NotFound(resposta)
        };
    }

    /// <summary>
    /// Busca Dados do Paciente
    /// </summary>     
    [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PacienteDto>> GetPaciente([FromQuery] AuthAcessoDto auth, string id)
    {
        var resposta = await service.BuscarPacientePorId(auth,id);

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
                false when resposta.Error.Contains("permissão")
                      => StatusCode(StatusCodes.Status403Forbidden, resposta),
                _ => NotFound(resposta)
            };
    }

    /// <summary>
    /// Arquiva Paciente
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("Arquivar")]
    public async Task<ActionResult> ArquivarPaciente([FromQuery] AuthAcessoDto auth, string id)
    {
        var resposta = await service.ArquivarPaciente(auth, id);
        return resposta switch
        {
            null => NotFound(resposta.Error),
            _ => NoContent()
        };
    }

}
