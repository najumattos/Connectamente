using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Services.PsicologoService;
using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;

namespace Connectamente.API.Controllers;

public class PsicologosController() : MainController
{

    /// <summary>
    /// Busca Todos Psicologos
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<FichaUsuarioDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<FichaUsuarioDto>>> GetPsicologos()
    {       
                 // Somente rota coordenador tem acesso
    }

    /// <summary>
    /// Exibe Dados do Psicologo
    /// </summary>     
    [ProducesResponseType(typeof(PsicologoDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<PsicologoDto>> GetPsicologo(string id)
    {

        // Somente rota coordenador tem acesso
    }
}
