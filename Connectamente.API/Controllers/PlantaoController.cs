using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/plantoes")]
[ApiController]
public class PlantaoController : MainController
{
    /// <summary>
    /// Listar plantões 
    /// </summary>
  [Authorize]
    [HttpGet]
    public IActionResult GetPlantoes()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar dados do plantão
    /// </summary>
    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetPlantaoById(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar dados permitidos do plantão
    /// </summary>
    [Authorize]
    [HttpPut("{id}")]
    public IActionResult UpdatePlantao(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Registrar plantão
    /// </summary>
       [Authorize(Policy="ADMIN")]
    [HttpPost]
    public IActionResult CreatePlantao()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
    /// <summary>
    /// Consultar plantões arquivados
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedPlantoes()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar plantão
    /// </summary>
      [Authorize(Policy="ADMIN")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchivePlantao(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar plantão
    /// </summary>
       [Authorize(Policy="ADMIN")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestorePlantao(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}