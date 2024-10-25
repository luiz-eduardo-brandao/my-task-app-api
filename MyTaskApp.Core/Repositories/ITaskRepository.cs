using MyTaskApp.Core.Entities;

namespace MyTaskApp.Core.Repositories
{
    public interface ITaskRepository
    {
        Task<List<ProjectTask>> GetAllAsync();
        Task<ProjectTask> GetByIdAsync(int id);
        Task<int> AddAsync(ProjectTask task);
        Task SaveChangesAsync();
    }
}
