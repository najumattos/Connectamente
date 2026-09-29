using System.Security.Claims;
using Connectamente.API.Services.Interfaces;

namespace Connectamente.API.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
   // Busca o e-mail de dentro dos Claims do Token JWT ou do Cookie de Autenticação

    public string? UserEmail => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email) 
                                 ?? httpContextAccessor.HttpContext?.User?.Identity?.Name 
                                 ?? "Sistema/Anônimo";
}