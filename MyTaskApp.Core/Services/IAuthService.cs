using MyTaskApp.Core.DTOs;
using System.Security.Claims;

namespace MyTaskApp.Core.Services
{
    public interface IAuthService
    {
        ClaimsPrincipal? ValidateToken(string token);
        string GenerateJwtToken(string email, string role, bool refreshToken = false);
        string ComputeSha256Hash(string password);
    }
}
