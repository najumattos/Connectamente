using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/familiares")]
[ApiController]
public class FamiliarController : MainController
{
    /// <summary>
    /// Listar familiares permitidos
    /// </summary>
      [Authorize(Policy="CLINICO")]
    [HttpGet]
    public IActionResult GetFamiliares()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar familiar
    /// </summary>
       [Authorize(Policy="CLINICO")]
    [HttpGet("{id}")]
    public IActionResult GetFamiliarById(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Cadastrar familiar
    /// </summary>
      [Authorize(Policy="CLINICO")]
    [HttpPost]
    public IActionResult CreateFamiliar()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar familiar
    /// </summary>
      [Authorize(Policy="CLINICO")]
    [HttpPut("{id}")]
    public IActionResult UpdateFamiliar(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

  /// <summary>
    /// Consultar familiares arquivados
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedFamiliares()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar familiar
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveFamiliar(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar familiar
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreFamiliar(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}