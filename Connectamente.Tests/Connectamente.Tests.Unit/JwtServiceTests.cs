
using Connectamente.API.Models;
using Connectamente.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Connectamente.Tests.Unit;

public class JwtServiceTests
{
    private static JwtService CriarService()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["JwtSettings:Key"] = "chave-de-teste-com-pelo-menos-32-caracteres",
                ["JwtSettings:Issuer"] = "Connectamente.API",
                ["JwtSettings:Audience"] = "Connectamente.API",
                ["JwtSettings:ExpirationInMinutes"] = "60"
            })
            .Build();
var store = new Mock<IUserStore<ApplicationUserModel>>();

    var userManager = new Mock<UserManager<ApplicationUserModel>>(
        store.Object,
        null, null, null, null, null, null, null, null);

    userManager
        .Setup(x => x.GetRolesAsync(
            It.IsAny<ApplicationUserModel>()))
        .ReturnsAsync(new List<string>());

    return new JwtService(
        configuration,
        userManager.Object);
}

    private static ApplicationUserModel CriarUsuario()
    {
        return new ApplicationUserModel
        {
            Id = "usuario-123",
            Email = "teste@email.com"
        };
    }

    [Fact] public async Task GenerateToken_DeveGerarToken_ParaUsuarioValido()
    {
           // Arrange
        var service = CriarService();
        var user = CriarUsuario();

        // Act
        var result = await service.GenerateToken(user);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(string.IsNullOrWhiteSpace(result.Value));

    }
    
    [Fact] public async Task GenerateToken_DeveConterClaimsDoUsuario()
    {
           // Arrange
        var service = CriarService();
        var user = CriarUsuario();

        // Act
        var result = await service.GenerateToken(user);

        // Assert
        Assert.True(result.IsSuccess);
       var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    var token = handler.ReadJwtToken(result.Value);

    Assert.Equal(user.Id, token.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value);
    Assert.Equal(user.Email, token.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.Email).Value);
   // Assert.Equal(user.TipoUsuario.ToString(), token.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.Role).Value);

    }

    [Fact] public async Task GenerateToken_DeveConterIssuerCorreto()
{
    // Arrange
    var service = CriarService();
    var user = CriarUsuario();

    // Act
    var result = await service.GenerateToken(user);

    // Assert
    Assert.True(result.IsSuccess);

    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    var token = handler.ReadJwtToken(result.Value);

    Assert.Equal("Connectamente.API", token.Issuer);
}
   
    [Fact] public async Task GenerateToken_DeveConterAudienceCorreto()
{
    // Arrange
    var service = CriarService();
    var user = CriarUsuario();

    // Act
    var result = await service.GenerateToken(user);

    // Assert
    Assert.True(result.IsSuccess);

    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    var token = handler.ReadJwtToken(result.Value);

    Assert.Contains("Connectamente.API", token.Audiences); 
}

    [Fact] public async Task GenerateToken_DevePossuirAssinaturaValida()
{
    // Arrange
    var service = CriarService();
    var user = CriarUsuario();

    // Act
    var result = await service.GenerateToken(user);

    // Assert
    Assert.True(result.IsSuccess);

    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

    var validationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "Connectamente.API",

        ValidateAudience = true,
        ValidAudience = "Connectamente.API",

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,

        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(
                "chave-de-teste-com-pelo-menos-32-caracteres"))
    };

    var principal = handler.ValidateToken(
        result.Value,
        validationParameters,
        out _);

    Assert.NotNull(principal);
}

    [Fact] public async Task GenerateToken_DeveFalhar_SemChave()
{
    // Arrange
    var configuration = new ConfigurationBuilder()
        .AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["JwtSettings:Key"] = "",
            ["JwtSettings:Issuer"] = "Connectamente.API",
            ["JwtSettings:Audience"] = "Connectamente.API",
            ["JwtSettings:ExpirationInMinutes"] = "60"
        })
        .Build();

  var store = new Mock<IUserStore<ApplicationUserModel>>();

    var userManager = new Mock<UserManager<ApplicationUserModel>>(
        store.Object,
        null, null, null, null, null, null, null, null);

    userManager
        .Setup(x => x.GetRolesAsync(
            It.IsAny<ApplicationUserModel>()))
        .ReturnsAsync(new List<string>());

    var service = new JwtService(configuration, userManager.Object);
    var user = CriarUsuario();

    // Act
    var result = await service.GenerateToken(user);

    // Assert
    Assert.True(result.IsFailed);
}
}