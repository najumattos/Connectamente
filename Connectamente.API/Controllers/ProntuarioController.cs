using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/prontuarios")]
[ApiController]
public class ProntuarioController : MainController
{
    /// <summary>
    /// Listar prontuários permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetProntuarios()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar prontuário
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetProntuarioById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar prontuários arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedProntuarios()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Abrir prontuário a partir de um plantão
    /// </summary>
    [HttpPost("por-plantao/{plantaoId}")]
    public IActionResult CreateProntuarioFromPlantao(int plantaoId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar campos permitidos do prontuário
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateProntuario(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar prontuário
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveProntuario(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar prontuário
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreProntuario(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}