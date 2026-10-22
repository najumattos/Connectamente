using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/tratamentos-anteriores")]
[ApiController]
public class TratamentoAnteriorController : MainController
{
    /// <summary>
    /// Listar tratamentos anteriores permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetTratamentosAnteriores()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar tratamento anterior
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetTratamentoAnteriorById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar registros arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedTratamentosAnteriores()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar registro
    /// </summary>
    [HttpPost]
    public IActionResult CreateTratamentoAnterior()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar registro
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateTratamentoAnterior(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar registro
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveTratamentoAnterior(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar registro
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreTratamentoAnterior(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}