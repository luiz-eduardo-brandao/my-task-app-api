using Microsoft.EntityFrameworkCore;
using MyTaskApp.Core.DTOs;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MyTaskAppDbContext _context;

        public TaskRepository(MyTaskAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(ProjectTask task)
        {
            var result = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<List<ProjectTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<ProjectTask> GetByIdAsync(int id)
        {
            var task = await _context
                .Tasks
                .Where(t => t.Active)
                .SingleOrDefaultAsync(u => u.Id == id);

            return task;
        }

        public async Task<List<TaskDTO>> GetByUserIdAsync(int idUser)
        {
            var task = await _context
                .Tasks
                .Include(t => t.Project)
                .Where(t => t.Active)
                .Select(t => new TaskDTO
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IdUser = t.IdUser,
                    IdProject = t.IdProject,
                    ProjectTitle = t.Project.Title,
                    TimeConsumed = "",
                    CreatedAt = t.CreatedAt,
                    StartedAt = t.StartedAt,
                    FinishedAt = t.FinishedAt
                })
                .Where(u => u.IdUser == idUser)
                .ToListAsync();

            return task;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
