using Microsoft.EntityFrameworkCore;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly MyTaskAppDbContext _context;

        public MenuRepository(MyTaskAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetAllAsync()
        {
            var menus = await _context.Menus
                .Where(m => m.IdFatherMenu == null) // root menus
                .Include(m => m.SubMenu)
                .ToListAsync();

            return menus;
        }
    }
}
