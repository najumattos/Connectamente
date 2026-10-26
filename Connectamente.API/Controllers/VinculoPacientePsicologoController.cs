using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/vinculos")]
[ApiController]
public class VinculoPacientePsicologoController : MainController
{
    /// <summary>
    /// Listar vínculos permitidos
    /// </summary>
    [Authorize]
    [HttpGet]
    public IActionResult GetVinculos()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar vínculo
    /// </summary>
   [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetVinculoById(int id)
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar vínculo
    /// </summary>
        [Authorize(Policy="ADMIN")]
    [HttpPost]
    public IActionResult CreateVinculo()
    {
         var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (usuarioId is null) return Unauthorized();
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar vínculo
    /// </summary>
       [Authorize(Policy="ADMIN")]
    [HttpPut("{id}")]
    public IActionResult UpdateVinculo(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Encerrar vínculo normalmente
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpPatch("{id}/encerrar")]
    public IActionResult EncerrarVinculo(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Revogar vínculo, conforme regra de negócio
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpPatch("{id}/revogar")]
    public IActionResult RevogarVinculo(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}