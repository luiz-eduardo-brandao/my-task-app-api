using MyTaskApp.Application.InputModels;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Core.DTOs;
using MyTaskApp.Core.Repositories;
using MyTaskApp.Core.Services;

namespace MyTaskApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public UserService(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> LoginUser(LoginUserInputModel inputModel)
        {
            var passwordHash = _authService.ComputeSha256Hash(inputModel.Password);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(inputModel.Email, passwordHash);

            if (user == null) return null;

            var userDTO = await _userRepository.GetByIdAsync(user.Id);

            var token = _authService.GenerateJwtToken(inputModel.Email, user.Role);

            userDTO.Token = token;

            return userDTO;
        }
    }
}
