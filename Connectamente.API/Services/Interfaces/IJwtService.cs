using Connectamente.API.Models;
using FluentResults;

namespace Connectamente.API.Services.Interfaces;

public interface IJwtService
{
Result<string> GenerateToken(ApplicationUserModel user);
}