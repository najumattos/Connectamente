using Connectamente.API.DTOs.AuthDto;
using Connectamente.API.DTOs.PacienteDto;
using Connectamente.API.DTOs.PsicologoDto;
using Connectamente.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Authorize(Roles = "Professor")]
public class PsicologosController(IPsicologoService service) : MainController
{

    /// <summary Busca Todos Psicologos
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<PacienteListaDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<PacienteListaDto>>> GetPsicologos()
    {
        var resposta = await service.BuscarTodosPsicologosAsync();

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
           
            _ => NotFound(resposta)
        };
    }

    /// <summary> Busca Psicologo Por Id
    /// </summary>     
    [ProducesResponseType(typeof(PsicologoDetalhesDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PsicologoDetalhesDto>> GetPsicologo(string id)
    {
        var resposta = await service.BuscarPsicologoPorIdAsync(id);

        return resposta.IsSuccess switch
        {
            true => Ok(resposta.Value),
           
            _ => NotFound(resposta)
        };
    }

    /// <summary> Desativa Psicologo
    /// </summary>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("Desativar/{id}")]
    public async Task<ActionResult> DesativarPsicologo([FromQuery] AuthUserDto auth, string id)
    {
        var resposta = "desativar";
      //  var resposta = await service.DesativarPsicologo(id);
        return resposta switch
        {
         
            _ => NoContent()
        };
    }
}
