using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

[Route("api/usuarios")]
[ApiController]
public class ApplicationUserController : MainController
{
    /// <summary>
    /// Listar usuários ativos
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpGet]
    public IActionResult GetActiveUsers()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Consultar usuário
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Cadastrar usuário
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpPost]
    public IActionResult CreateUser()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Atualizar usuário
    /// </summary>
    [Authorize(Policy="ADMIN")]
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    /// <summary>
    /// Desativar/arquivar usuário
    /// </summary>
    /// [Authorize(Policy="ADMIN")]
    [Authorize(Policy="ADMIN")]
    [HttpPatch("{id}/arquivar")]
    public IActionResult ArchiveUser(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

 /// <summary>
    /// Listar usuários arquivados
    /// </summary>
    [Authorize(Roles="Professor")]
    [HttpGet("arquivados")]
    public IActionResult GetArchivedUsers()
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
    
    /// <summary>
    /// Reativar usuário arquivado
    /// </summary>
     [Authorize(Roles="Professor")]
    [HttpPatch("{id}/restaurar")]
    public IActionResult RestoreUser(int id)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }
} 