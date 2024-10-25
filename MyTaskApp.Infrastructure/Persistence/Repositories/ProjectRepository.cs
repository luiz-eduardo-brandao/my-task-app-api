using Microsoft.EntityFrameworkCore;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyTaskAppDbContext _context;

        public ProjectRepository(MyTaskAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Project project)
        {
            var result = await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context
                .Projects
                .Where(p => p.Active)
                .Include(p => p.Tasks)
                .ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = await _context
                .Projects
                .Where(p => p.Active)
                .Include(p => p.Tasks)
               .SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
