using MyTaskApp.Core.DTOs;
using MyTaskApp.Core.Entities;

namespace MyTaskApp.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
        Task<int> AddAsync(User user);
        Task SaveChangesAsync();
    }
}
