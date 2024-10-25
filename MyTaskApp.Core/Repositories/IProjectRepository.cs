using MyTaskApp.Core.Entities;

namespace MyTaskApp.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<int> AddAsync(Project project);
        Task SaveChangesAsync();
    }
}
