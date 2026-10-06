using AutoMapper;
using Connectamente.API.DTOs.AuthDto;
using Connectamente.API.Models;
using Connectamente.API.Services;
using Connectamente.API.Services.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

namespace Connectamente.Tests.Unit;

public class AuthServiceTests
{
    private readonly Mock<UserManager<ApplicationUserModel>> _userManagerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IJwtService> _jwtServiceMock;

    public AuthServiceTests()
    {
        var store = new Mock<IUserStore<ApplicationUserModel>>();

//Esse monte de null está aí porque o UserManager tem um construtor com várias dependências mas para criar o UserManager, é preciso satisfazer apenas o construtor dele
        _userManagerMock = new Mock<UserManager<ApplicationUserModel>>(
            store.Object,
            null!, null!, null!, null!, null!, null!, null!, null!);

        _mapperMock = new Mock<IMapper>();
        _jwtServiceMock = new Mock<IJwtService>();
    }

      private AuthService CriarService(LoginDto loginDto, ApplicationUserModel user, AuthUserDto authDto ){

     _userManagerMock
        .Setup(x => x.FindByEmailAsync(loginDto.Email))
        .ReturnsAsync(user);

    _userManagerMock
        .Setup(x => x.IsLockedOutAsync(user))
        .ReturnsAsync(false);

    _userManagerMock
        .Setup(x => x.CheckPasswordAsync(user, loginDto.Senha))
        .ReturnsAsync(true);

    _userManagerMock
        .Setup(x => x.ResetAccessFailedCountAsync(user))
        .ReturnsAsync(IdentityResult.Success);

    _mapperMock
        .Setup(x => x.Map<AuthUserDto>(user))
        .Returns(authDto);

    _jwtServiceMock
        .Setup(x => x.GenerateToken(user))
        .Returns(Result.Ok("token-de-teste"));

    return  new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);
}
      private static ApplicationUserModel CriarUser()
    {
        return  new ApplicationUserModel
    {
        Id = "usuario-123",
        Email = "teste@email.com"
    };
    }
      private static LoginDto CriarLogin()
    {
        return new LoginDto
    {
        Email = "teste@email.com",
        Senha = "SenhaValida123"
    };
    }
      private static AuthUserDto CriarAuthUser(ApplicationUserModel user)
    {
        return new AuthUserDto
    {
        Id = user.Id,
        Email = user.Email
    };
    }
  
    [Fact] public async Task ValidateUserAsync_DeveRetornarUsuarioAutenticado()
{
    // Arrange
    var user = CriarUser();
    var loginDto = CriarLogin();
    var authDto = CriarAuthUser(user); 

    var service = CriarService(loginDto, user, authDto);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsSuccess);
    Assert.Equal("token-de-teste", result.Value.Token);
    Assert.Equal(user.Email, result.Value.Email);
}

    [Fact] public async Task ValidateUserAsync_DeveFalhar_QuandoUsuarioNaoForEncontrado()
{
      // Arrange
    var loginDto = CriarLogin();

    _userManagerMock
        .Setup(x => x.FindByEmailAsync(loginDto.Email))
        .ReturnsAsync((ApplicationUserModel?)null);

    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal("Senha ou e-mail incorretos.", result.Errors[0].Message);
}

    [Fact] public async Task ValidateUserAsync_DeveFalhar_QuandoSenhaForIncorreta()
{
    // Arrange
    var user = CriarUser();
    var loginDto = CriarLogin();

    _userManagerMock
        .Setup(x => x.FindByEmailAsync(loginDto.Email))
        .ReturnsAsync(user);

    _userManagerMock
        .Setup(x => x.IsLockedOutAsync(user))
        .ReturnsAsync(false);

    _userManagerMock
        .Setup(x => x.CheckPasswordAsync(user, loginDto.Senha))
        .ReturnsAsync(false);

    _userManagerMock
        .Setup(x => x.AccessFailedAsync(user))
        .ReturnsAsync(IdentityResult.Success);

    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal("Senha ou e-mail incorretos.", result.Errors[0].Message);

    _userManagerMock.Verify(
        x => x.AccessFailedAsync(user),
        Times.Once);

    _jwtServiceMock.Verify(
        x => x.GenerateToken(user),
        Times.Never);
}
    [Fact] public async Task ValidateUserAsync_DeveFalhar_QuandoUsuarioEstiverBloqueado()
{
    // Arrange
    var user = CriarUser();
    var loginDto = CriarLogin();

    _userManagerMock
        .Setup(x => x.FindByEmailAsync(loginDto.Email))
        .ReturnsAsync(user);

    _userManagerMock
        .Setup(x => x.IsLockedOutAsync(user))
        .ReturnsAsync(true);

    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal(
        "Conta bloqueada temporariamente.",
        result.Errors[0].Message);

    _jwtServiceMock.Verify(
        x => x.GenerateToken(user),
        Times.Never);
}

    [Fact] public async Task ValidateUserAsync_DeveFalhar_QuandoLoginDtoForNulo()
{
    // Arrange
    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(null);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal("Dados inválidos.", result.Errors[0].Message);
}
    [Fact] public async Task ValidateUserAsync_DeveFalhar_QuandoEmailForVazio()
{
    // Arrange
    var loginDto = new LoginDto
    {
        Email = "",
        Senha = "SenhaValida123"
    };

    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal(
        "Senha ou e-mail incorretos.",
        result.Errors[0].Message);

    _userManagerMock.Verify(
        x => x.FindByEmailAsync(It.IsAny<string>()),
        Times.Never);
}

    [Fact] public async Task ValidateUserAsync_DeveFalhar_QuandoSenhaForVazia()
{
    // Arrange
    var loginDto = new LoginDto
    {
        Email = "teste@email.com",
        Senha = ""
    };

    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal(
        "Senha ou e-mail incorretos.",
        result.Errors[0].Message);

    _userManagerMock.Verify(
        x => x.FindByEmailAsync(It.IsAny<string>()),
        Times.Never);
}

    [Fact]public async Task ValidateUserAsync_DeveFalhar_QuandoGeracaoDoTokenFalhar()
{
    // Arrange
    var user = CriarUser();
    var loginDto = CriarLogin();
    var authDto = CriarAuthUser(user);

    _userManagerMock
        .Setup(x => x.FindByEmailAsync(loginDto.Email))
        .ReturnsAsync(user);

    _userManagerMock
        .Setup(x => x.IsLockedOutAsync(user))
        .ReturnsAsync(false);

    _userManagerMock
        .Setup(x => x.CheckPasswordAsync(user, loginDto.Senha))
        .ReturnsAsync(true);

    _userManagerMock
        .Setup(x => x.ResetAccessFailedCountAsync(user))
        .ReturnsAsync(IdentityResult.Success);

    _mapperMock
        .Setup(x => x.Map<AuthUserDto>(user))
        .Returns(authDto);

    _jwtServiceMock
        .Setup(x => x.GenerateToken(user))
        .Returns(Result.Fail<string>("Falha ao gerar token."));

    var service = new AuthService(
        _userManagerMock.Object,
        _mapperMock.Object,
        NullLogger<AuthService>.Instance,
        _jwtServiceMock.Object);

    // Act
    var result = await service.ValidateUserAsync(loginDto);

    // Assert
    Assert.True(result.IsFailed);
    Assert.Equal(
        "Falha ao gerar token.",
        result.Errors[0].Message);

    _jwtServiceMock.Verify(
        x => x.GenerateToken(user),
        Times.Once);
}
}