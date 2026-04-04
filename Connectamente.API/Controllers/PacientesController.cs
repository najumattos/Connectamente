using Microsoft.AspNetCore.Mvc;
using Connectamente.API.Services.PacienteService;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;
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
    [ProducesResponseType(typeof(IEnumerable<FichaUsuarioDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetPacientes(AuthAcessoDto authAcessoDto)
    {
        var resposta = await pacienteService.BuscarPacientes(authAcessoDto);

        if (!resposta.IsSuccess)
        {
            return NotFound(resposta);
        }
        return Ok(resposta);

    }

    /// <summary>
    /// Exibe Dados do Paciente
    /// </summary>     
    [ProducesResponseType(typeof(PacienteDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PacienteDto>> GetPaciente(AuthAcessoDto authAcessoDto, string id)
    {
        var resposta = await pacienteService.BuscarPacientePorId(authAcessoDto, id);

        if (!resposta.IsSuccess)
        {
            return NotFound(resposta);
        }
        return Ok(resposta);
    }

}
