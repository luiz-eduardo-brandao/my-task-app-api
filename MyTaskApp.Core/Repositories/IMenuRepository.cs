using MyTaskApp.Core.Entities;

namespace MyTaskApp.Core.Repositories
{
    public interface IMenuRepository
    {
        public Task<List<Menu>> GetAllAsync();
    }
}
