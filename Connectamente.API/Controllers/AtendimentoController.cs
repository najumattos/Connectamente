using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/atendimentos")]
[ApiController]
public class AtendimentoController : MainController
{
    /// <summary>
    /// Listar atendimentos permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetAtendimentos()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar atendimento
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetAtendimentoById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar atendimento a partir de agendamento
    /// </summary>
    [HttpPost]
    public IActionResult CreateAtendimento()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar atendimento
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateAtendimento(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar atendimentos arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedAtendimentos()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar atendimento
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveAtendimento(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar atendimento arquivado
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreAtendimento(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}