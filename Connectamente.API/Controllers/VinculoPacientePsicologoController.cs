using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/vinculos")]
[ApiController]
public class VinculoPacientePsicologoController : MainController
{
    /// <summary>
    /// Listar vínculos permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetVinculos()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar vínculo
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetVinculoById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Criar vínculo
    /// </summary>
    [HttpPost]
    public IActionResult CreateVinculo()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar vínculo
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateVinculo(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Encerrar vínculo normalmente
    /// </summary>
    [HttpPatch("{id}/encerrar")]
    public IActionResult EncerrarVinculo(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Revogar vínculo, conforme regra de negócio
    /// </summary>
    [HttpPatch("{id}/revogar")]
    public IActionResult RevogarVinculo(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}