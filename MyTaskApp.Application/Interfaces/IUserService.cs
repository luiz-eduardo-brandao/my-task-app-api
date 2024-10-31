using MyTaskApp.Application.InputModels;
using MyTaskApp.Core.DTOs;

namespace MyTaskApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<TokenDTO?> ValidateToken(VerifyTokenInputModel inputModel);
        Task<UserDTO> LoginUser(LoginUserInputModel inputModel);
    }
}
