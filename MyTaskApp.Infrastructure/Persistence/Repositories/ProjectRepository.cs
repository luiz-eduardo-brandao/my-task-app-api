using Microsoft.EntityFrameworkCore;
using MyTaskApp.Core.DTOs;
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

        public async Task<List<ProjectDTO>> GetByUserIdAsync(int idUser)
        {
            var projects = await _context
                .Projects
                .Include(p => p.User)
                .Where(p => p.Active)
                .Select(p => new ProjectDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    IdUser = p.User.Id,
                    UserName = p.User.FullName,
                    CreatedAt = p.CreatedAt,
                    Image = p.ImageUrl,
                    Level = (int)p.Level,
                    Tasks = p.Tasks
                        .Where(t => t.Active)
                        .Select(t => new TaskDTO
                        {
                            Id = t.Id,
                            Title = t.Title,
                            Description = t.Description,
                            IdUser = t.IdUser,
                            IdProject = t.IdProject,
                            ProjectTitle = p.Title,
                            TimeConsumed = "",
                            StartedAt = t.StartedAt,
                            FinishedAt = t.FinishedAt,
                        })
                        .ToList()
                })
                .Where(u => u.IdUser == idUser)
                .ToListAsync();

            return projects;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
