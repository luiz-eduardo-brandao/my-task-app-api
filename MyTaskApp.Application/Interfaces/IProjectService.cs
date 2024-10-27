using MyTaskApp.Application.InputModels;

namespace MyTaskApp.Application.Interfaces
{
    public interface IProjectService
    {
        public Task UpdateAsync(UpdateProjectInputModel inputModel);
        public Task DeleteAsync(int idProject);
    }
}
