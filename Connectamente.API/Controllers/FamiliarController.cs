using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/familiares")]
[ApiController]
public class FamiliarController : MainController
{
    /// <summary>
    /// Listar familiares permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetFamiliares()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar familiar
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetFamiliarById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar familiares arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedFamiliares()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Cadastrar familiar
    /// </summary>
    [HttpPost]
    public IActionResult CreateFamiliar()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar familiar
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateFamiliar(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar familiar
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveFamiliar(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar familiar
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreFamiliar(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}