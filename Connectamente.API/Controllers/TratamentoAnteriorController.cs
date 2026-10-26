using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/tratamentos-anteriores")]
[ApiController]
public class TratamentoAnteriorController : MainController
{
    /// <summary>
    /// Listar tratamentos anteriores permitidos
    /// </summary>
     [Authorize(Policy="CLINICO")]
    [HttpGet]
    public IActionResult GetTratamentosAnteriores()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar tratamento anterior
    /// </summary>
    [Authorize(Policy="CLINICO")]
    [HttpGet("{id}")]
    public IActionResult GetTratamentoAnteriorById(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar registro
    /// </summary>
      [Authorize(Policy="CLINICO")]
    [HttpPost]
    public IActionResult CreateTratamentoAnterior()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar registro
    /// </summary>
      [Authorize(Policy="CLINICO")]
    [HttpPut("{id}")]
    public IActionResult UpdateTratamentoAnterior(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar registro
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveTratamentoAnterior(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar registro
    /// </summary>
  [Authorize(Roles="Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreTratamentoAnterior(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
        /// <summary>
    /// Consultar registros arquivados
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedTratamentosAnteriores()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

}