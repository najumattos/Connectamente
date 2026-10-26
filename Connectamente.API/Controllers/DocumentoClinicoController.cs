using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/documentos-clinicos")]
[ApiController]
public class DocumentoClinicoController : MainController
{
    /// <summary>
    /// Listar documentos clínicos
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpGet]
    public IActionResult GetDocumentosClinicos()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar documento clínico por ID
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpGet("{id}")]
    public IActionResult GetDocumentoClinicoById(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Listar documentos clínicos de um paciente
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpGet("por-paciente/{pacienteId}")]
    public IActionResult GetDocumentosClinicosByPaciente(int pacienteId)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Listar documentos clínicos arquivados
    /// </summary>
    [Authorize(Roles = "Professor")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedDocumentosClinicos()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar documento clínico
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpPost]
    public IActionResult CreateDocumentoClinico()
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar documento clínico
    /// </summary>
    [Authorize(Policy = "CLINICO")]
    [HttpPut("{id}")]
    public IActionResult UpdateDocumentoClinico(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar documento clínico
    /// </summary>
    [Authorize(Roles = "Professor")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveDocumentoClinico(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar documento clínico arquivado
    /// </summary>
    [Authorize(Roles = "Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreDocumentoClinico(int id)
    {
        var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();

        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}