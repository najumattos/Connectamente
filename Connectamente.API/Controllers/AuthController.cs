using Microsoft.AspNetCore.Mvc;
using FluentResults;
using Connectamente.API.Services.Interfaces;
using Connectamente.API.DTOs.AuthDto;

namespace Connectamente.API.Controllers;

[Route("api/auth")]
public class AuthController(
    IAuthService service,
    ILogger<AuthController> logger) : MainController
{
    /// <summary>
    /// Efetua a autenticação do usuário e retorna o token de acesso.
    /// </summary>
   [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        // O ASP.NET Core API já valida o [ApiController] automaticamente, 
        // mas o FluentResults captura a regra de negócio do serviço.
        Result<AuthUserDto> resposta = await service.ValidateUserAsync(loginDto);

        if (resposta.IsFailed)
        {
            logger.LogWarning("Falha na tentativa de login para o usuário: {User}", loginDto.Email);
            return TratarFalhas(resposta.ToResult());
        }

        return Ok(resposta.Value);
    }

    /// <summary>
    /// Encerra a sessão do usuário
    /// </summary>
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        //é importante invalidar o token?
       await service.Logout();      
       return NoContent();
    }        
}