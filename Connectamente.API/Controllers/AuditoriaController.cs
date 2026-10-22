using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/auditoria")]
[ApiController]
public class AuditoriaController : MainController
{
    /// <summary>
    /// Listar eventos de auditoria
    /// </summary>
    [HttpGet]
    public IActionResult GetAuditorias()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar um evento
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetAuditoriaById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar eventos de um usuário
    /// </summary>
    [HttpGet("por-usuario/{usuarioId}")]
    public IActionResult GetAuditoriasByUsuario(int usuarioId)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Filtrar eventos por entidade e identificador do registro
    /// </summary>
    [HttpGet("por-entidade")]
    public IActionResult GetAuditoriasByEntidade()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}