using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/pacientes")]
[ApiController]
public class PacienteController : MainController
{
    /// <summary>
    /// Listar pacientes permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetPacientes()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar paciente
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetPacienteById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Listar pacientes arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedPacientes()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Cadastrar paciente
    /// </summary>
    [HttpPost]
    public IActionResult CreatePaciente()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar paciente
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdatePaciente(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar paciente
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchivePaciente(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar paciente
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestorePaciente(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}