using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public abstract class MainController : ControllerBase
{
    /// <summary>
    /// Centralizador privado para tradução de falhas do FluentResults para o ecossistema HTTP.
    /// </summary>
    protected IActionResult TratarFalhas(Result resultado)
    {
        // Verifica se alguma mensagem de erro contém o gatilho de falta de permissão
        if (resultado.HasError(err => err.Message.Contains("permissao", StringComparison.OrdinalIgnoreCase)))
        {
            return StatusCode(StatusCodes.Status403Forbidden, resultado.Errors.Select(e => e.Message));
        }

        // Caso padrão para entidades não encontradas ou falhas genéricas de negócio
        return NotFound(resultado.Errors.Select(e => e.Message));
    }
}
