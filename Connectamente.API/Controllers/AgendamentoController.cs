using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/agendamentos")]
[ApiController]
public class AgendamentoController : MainController
{
    /// <summary>
    /// Listar todos os agendamentos
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpGet]
    public IActionResult GetAgendamentos()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar agendamento por ID
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpGet("{id}")]
    public IActionResult GetAgendamentoById(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Listar agendamentos arquivados
    /// </summary>
    [Authorize(Policy = "ADMIN")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedAgendamentos()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar agendamento
    /// </summary>
    [Authorize(Policy = "ADMIN")]
    [HttpPost]
    public IActionResult CreateAgendamento()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar agendamento
    /// </summary>
    [Authorize(Policy = "ADMIN")]
    [HttpPut("{id}")]
    public IActionResult UpdateAgendamento(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar agendamento
    /// </summary>
    [Authorize(Policy = "ADMIN")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveAgendamento(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar agendamento arquivado
    /// </summary>
    [Authorize(Policy = "ADMIN")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreAgendamento(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}