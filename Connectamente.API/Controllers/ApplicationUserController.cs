using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/usuarios")]
[ApiController]
public class ApplicationUserController : MainController
{
    /// <summary>
    /// Listar usuários ativos
    /// </summary>
    [HttpGet]
    public IActionResult GetActiveUsers()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar usuário
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Listar usuários arquivados
    /// </summary>
    [HttpGet("arquivados")]
    public IActionResult GetArchivedUsers()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Cadastrar usuário
    /// </summary>
    [HttpPost]
    public IActionResult CreateUser()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar usuário
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Desativar/arquivar usuário
    /// </summary>
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveUser(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Reativar usuário arquivado
    /// </summary>
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreUser(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
} 