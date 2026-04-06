using Microsoft.AspNetCore.Mvc;
using Connectamente.API.Services.PacienteService;
using System;
using Connectamente.API.Enums;
using Connectamente.API.Services;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Domain;

namespace Connectamente.API.Controllers;

public class PacientesController(IPacienteService pacienteService) : MainController
{

    /// <summary>
    /// Busca Todos Pacientes
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<UsuarioListaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<UsuarioListaDto>>> GetPacientes([FromQuery] AuthAcessoDto auth)
    {
        var resposta = await pacienteService.BuscarPacientes(auth);

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
        var resposta = await pacienteService.BuscarPacientePorId(auth,id);

            return resposta.IsSuccess switch
            {
                true => Ok(resposta.Value),
                false when resposta.Error.Contains("permissão")
                      => StatusCode(StatusCodes.Status403Forbidden, resposta),
                _ => NotFound(resposta)
            };
        }

}
