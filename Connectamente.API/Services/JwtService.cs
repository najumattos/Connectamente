using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Connectamente.API.Models;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.IdentityModel.Tokens;

namespace Connectamente.API.Services;

public class JwtService(IConfiguration configuration) : IJwtService
{
    public Result<string> GenerateToken(ApplicationUserModel user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email!)
        };
         //pega a Key configurada no program.cs
          var jwtKey = configuration["JwtSettings:Key"];
        
        // transforma a chave em uma chave criptográfica
    var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(jwtKey!)
    );

// assina o jwt utilizando a chave criptográfica
    var credentials = new SigningCredentials(
        key,
        SecurityAlgorithms.HmacSha256
    );

    var expirationMinutesValue = configuration["JwtSettings:ExpirationInMinutes"]; //JWT_EXPIRATION_MINUTES é string
if (!int.TryParse(expirationMinutesValue, out var expirationMinutes))
{
   return Result.Fail("A duração do JWT não foi configurada corretamente.");
}
var expiration = DateTime.UtcNow.AddMinutes(expirationMinutes);

        // objeto que representa o token que estamos montando
var token = new JwtSecurityToken(
    issuer: "Connectamente.API",//remetente 
    audience: "Connectamente.API",//destinatario
    expires: expiration,
    claims: claims,  // informações do usuário que serão colocadas no JWT
    signingCredentials: credentials //assinatura JWT
); 
 // Transforma o objeto JWT em uma string no formato JWT
    var handler = new JwtSecurityTokenHandler();
//serializa para o formato de texto
    var tokenString = handler.WriteToken(token);

    return Result.Ok(tokenString);
       
    }
}

/*
Serializar: Transformar uma estrutura que existe dentro do programa em uma representação que possa ser transmitida ou armazenada.
*/