
using Connectamente.API.Enums;
using Connectamente.API.Models;
using Connectamente.API.Services;
using Microsoft.Extensions.Configuration;

namespace Connectamente.Tests.Unit;

public class JwtServiceTests
{
[Fact]
public void GenerateToken_DeveGerarToken_ParaUsuarioValido()
    {
          // Arrange
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JwtSettings:Key"] = "chave-de-teste-com-pelo-menos-32-caracteres",
                ["JwtSettings:Issuer"] = "Connectamente.API",
                ["JwtSettings:Audience"] = "Connectamente.API",
                ["JwtSettings:ExpirationInMinutes"] = "60"
            })
            .Build();
var service = new JwtService(configuration);
 var user = new ApplicationUserModel
        {
            Id = "usuario-123",
            Email = "teste@email.com",
            TipoUsuario = TipoUsuarioEnum.Professor
        };
        // Act
        var result = service.GenerateToken(user);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(string.IsNullOrWhiteSpace(result.Value));

    }
}