using MyTaskApp.Application.InputModels;
using MyTaskApp.Core.DTOs;

namespace MyTaskApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> LoginUser(LoginUserInputModel inputModel);
    }
}
