using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/pacientes")]
[ApiController]
public class PacienteController : MainController
{
    /// <summary>
    /// Listar pacientes permitidos
    /// </summary>
    [Authorize]
    [HttpGet]
    public IActionResult GetPacientes()
    {
          var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar paciente
    /// </summary>
    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetPacienteById(int id)
    {
          var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
    /// <summary>
    /// Atualizar paciente
    /// </summary>
    [Authorize]
    [HttpPut("{id}")]
    public IActionResult UpdatePaciente(int id)
    {
          var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
    /// <summary>
    /// Cadastrar paciente
    /// </summary>
   [Authorize(Policy="CLINICO")]
    [HttpPost]
    public IActionResult CreatePaciente()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar paciente
    /// </summary>
     [Authorize(Roles="Professor")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchivePaciente(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar paciente
    /// </summary>
     [Authorize(Roles="Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestorePaciente(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
        /// <summary>
    /// Listar pacientes arquivados
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedPacientes()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}