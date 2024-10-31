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
            var refreshToken = _authService.GenerateJwtToken(inputModel.Email, user.Role, true);

            userDTO.Token = token;
            userDTO.RefreshToken = refreshToken;

            return userDTO;
        }

        public async Task<TokenDTO?> ValidateToken(VerifyTokenInputModel inputModel)
        {
            var accessTokenPrincipal = _authService.ValidateToken(inputModel.Token);

            if (accessTokenPrincipal != null)
                return null;
            
            var refreshTokenPrincipal = _authService.ValidateToken(inputModel.RefreshToken);

            if (refreshTokenPrincipal != null)
            {
                var user = await _userRepository.GetByIdAsync(inputModel.IdUser);

                var token = _authService.GenerateJwtToken(user.Email, user.Role);
                var refreshToken = _authService.GenerateJwtToken(user.Email, user.Role, true);

                return new TokenDTO(token, refreshToken);
            }

            throw new Exception("Token inválido ou expirado. Favor realizar login novamente");
        }
    }
}
