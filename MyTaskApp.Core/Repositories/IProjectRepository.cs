using MyTaskApp.Core.DTOs;
using MyTaskApp.Core.Entities;

namespace MyTaskApp.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<List<ProjectDTO>> GetByUserIdAsync(int idUser);
        Task<int> AddAsync(Project project);
        Task SaveChangesAsync();
    }
}
