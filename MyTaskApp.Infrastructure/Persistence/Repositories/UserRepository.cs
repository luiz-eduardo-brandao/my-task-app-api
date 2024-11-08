using Microsoft.EntityFrameworkCore;
using MyTaskApp.Core.DTOs;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyTaskAppDbContext _context;

        public UserRepository(MyTaskAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            var user = await _context
                .Users
                //.Include(u => u.Projects)
                //    .ThenInclude(p => p.Tasks)
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    FullName = u.FullName,
                    ProfileImage = u.ProfileImage,
                    Email = u.Email,
                    Role = u.Role,
                    //Projects = u.Projects.Where(p => p.Active)
                    //    .Select(p => new ProjectDTO { 
                    //        Id = p.Id,
                    //        Title = p.Title,
                    //        Description = p.Description,
                    //        IdUser = u.Id,
                    //        UserName = u.FullName,
                    //        CreatedAt = p.CreatedAt,
                    //        Image = p.ImageUrl,
                    //        Level = (int)p.Level,
                    //        Tasks = p.Tasks
                    //            .Where(t => t.Active)
                    //            .Select(t => new TaskDTO
                    //            {
                    //                Id = t.Id,
                    //                Title = t.Title,
                    //                Description = t.Description,
                    //                IdUser = t.IdUser,
                    //                IdProject = t.IdProject,
                    //                ProjectTitle = p.Title,
                    //                TimeConsumed = ""
                    //            })
                    //            .ToList()
                    //    })
                    //    .ToList(),
                })
                .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var user = await _context.Users.Where(u => u.Id != 1).ToListAsync();

            return user;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            var user = await _context
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);

            return user;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
