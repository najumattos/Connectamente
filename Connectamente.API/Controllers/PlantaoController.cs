using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/plantoes")]
[ApiController]
public class PlantaoController : MainController
{
    /// <summary>
    /// Listar plantões permitidos
    /// </summary>
    [HttpGet]
    public IActionResult GetPlantoes()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar dados do plantão
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetPlantaoById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar plantões arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedPlantoes()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Registrar plantão
    /// </summary>
    [HttpPost]
    public IActionResult CreatePlantao()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar dados permitidos do plantão
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdatePlantao(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Arquivar plantão
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchivePlantao(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Restaurar plantão
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestorePlantao(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
}