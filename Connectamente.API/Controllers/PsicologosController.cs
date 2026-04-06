using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Services.PsicologoService;
using Connectamente.API.Models.ViewModel;
using Connectamente.API.Services.PacienteService;

namespace Connectamente.API.Controllers;

public class PsicologosController(IPsicologoService psicologoService) : MainController
{

    /// <summary>
    /// Busca Todos Psicologos
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<UsuarioListaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<UsuarioListaDto>>> GetPsicologos(AuthAcessoDto authAcessoDto)
    {
        var resposta = await psicologoService.BuscarTodosPsicologos();

        if (!resposta.IsSuccess)
        {
            return NotFound(resposta);
        }
        return Ok(resposta);
    }

    /// <summary>
    /// Exibe Dados do Psicologo
    /// </summary>     
    [ProducesResponseType(typeof(PsicologoDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PsicologoDto>> GetPsicologo(string id)
    {
        var resposta = await psicologoService.BuscarPsicologoPorId(id);

        if (!resposta.IsSuccess)
        {
            return NotFound(resposta);
        }
        return Ok(resposta);
    }
}
