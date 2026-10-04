using AutoMapper;
using Connectamente.API.DTOs.AuthDto;
using Connectamente.API.Models;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Connectamente.API.Services;

public class AuthService(
    UserManager<ApplicationUserModel> userManager,
    IMapper mapper,
    ILogger<AuthService> logger, IJwtService jwtService) : IAuthService
{
      public async Task Logout(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        await Task.CompletedTask;
        logger.LogInformation("Solicitação de logout registrada.");
    }

    public async Task<Result<AuthUserDto>> ValidateUserAsync(LoginDto loginDto)
    {
        if (loginDto == null) return Result.Fail<AuthUserDto>("Dados inválidos.");
        
        if (string.IsNullOrWhiteSpace(loginDto.Email) || string.IsNullOrWhiteSpace(loginDto.Senha))
        {
            return Result.Fail<AuthUserDto>("Senha ou e-mail incorretos.");
        }

        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
        {
            logger.LogWarning("Tentativa de login com e-mail inexistente: {Email}", loginDto.Email);
            return Result.Fail<AuthUserDto>("Senha ou e-mail incorretos.");
        }

        // 🧠 Verificação de bloqueio preventiva
        if (await userManager.IsLockedOutAsync(user))
        {
            logger.LogWarning("Tentativa de login em conta bloqueada: {Email}", loginDto.Email);
            return Result.Fail<AuthUserDto>("Conta bloqueada temporariamente.");
        }

        // Validação matemática pura do Hash da Senha contra o banco
        var senhaValida = await userManager.CheckPasswordAsync(user, loginDto.Senha);

        if (!senhaValida)
        {
            // Incrementa o contador de falhas para o sistema de lockout funcionar corretamente
            await userManager.AccessFailedAsync(user);
            
            logger.LogWarning("Falha de autenticação (senha incorreta) para o usuário: {Email}", loginDto.Email);
            return Result.Fail<AuthUserDto>("Senha ou e-mail incorretos.");
        }

        // Se a senha estiver correta, limpa o contador de tentativas falhas
        await userManager.ResetAccessFailedCountAsync(user);


        var authDto = mapper.Map<AuthUserDto>(user);        
        var tokenResult = jwtService.GenerateToken(user);

        if (tokenResult.IsFailed)
{
    return Result.Fail<AuthUserDto>(tokenResult.Errors);
}

authDto.Token = tokenResult.Value;        
        
        logger.LogInformation("Usuário {Email} autenticado com sucesso via validação de hash.", loginDto.Email);
        return Result.Ok(authDto);
    }
}