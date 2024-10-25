using Microsoft.EntityFrameworkCore;
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
                .SingleOrDefaultAsync(u => u.Id == id);

            return task;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
