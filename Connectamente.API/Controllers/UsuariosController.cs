using Connectamente.API.DTOs;
using Connectamente.API.DTOs.UsersDTOs;
using Connectamente.API.Services.UsuarioService;
using Microsoft.AspNetCore.Mvc;

namespace Connectamente.API.Controllers;

public class UsuariosController(IUsuarioService usuarioService) : MainController
{

    /// <summary>
    /// Busca Todos Usuarios MOCK
    /// </summary>
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    [HttpGet("Buscar")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetTodosUsuarios()
    {
        var usuarios = await usuarioService.BuscarTodosUsuarios();

        if (usuarios == null)
        {
            return NotFound("Nenhum usuário encontrado");
        }
        return Ok(usuarios);

    }

    /// <summary>
    /// Exibe Dados Cadastrais do Usuario MOCK
    /// </summary>     
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUsuario(string id)
    {
        var usuario = await usuarioService.BuscarUsuarioPorId(id);
        return usuario switch
        {
            null => NotFound("Usuário não encontrado"),      //404 não encontrado
            _ => Ok(usuario) //200 sucesso com UserDto como parametro  
        };
    }
}
