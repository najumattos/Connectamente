using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/prontuarios")]
[ApiController]
public class ProntuarioController : MainController
{
    /// <summary>
    /// Listar prontuários permitidos
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpGet]
    public IActionResult GetProntuarios()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar prontuário
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpGet("{id}")]
    public IActionResult GetProntuarioById(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Abrir prontuário a partir de um plantão
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpPost("por-plantao/{plantaoId}")]
    public IActionResult CreateProntuarioFromPlantao(int plantaoId)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

 /// <summary>
    /// Consultar prontuários arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedProntuarios()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar campos permitidos do prontuário
    /// </summary>
    [Authorize(Policy="CLINICO")]
   [HttpPut("{id}")]
    public IActionResult UpdateProntuario(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar prontuário
    /// </summary>
     [Authorize(Roles="Professor")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveProntuario(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar prontuário
    /// </summary>
     [Authorize(Roles="Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreProntuario(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}