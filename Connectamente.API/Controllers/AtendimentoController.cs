using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/atendimentos")]
[ApiController]
public class AtendimentoController : MainController
{
    /// <summary>
    /// Listar atendimentos
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpGet]
    public IActionResult GetAtendimentos()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar atendimento
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpGet("{id}")]
    public IActionResult GetAtendimentoById(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar atendimento a partir de agendamento
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpPost]
    public IActionResult CreateAtendimento()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar atendimento
    /// </summary>
   [Authorize(Policy="CLINICO")]
    [HttpPut("{id}")]
    public IActionResult UpdateAtendimento(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar atendimento ATTREADME
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveAtendimento(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

        /// <summary>
    /// Consultar atendimentos arquivados 
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedAtendimentos()
    {

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar atendimento arquivado
    /// </summary>
   [Authorize(Roles="Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreAtendimento(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}