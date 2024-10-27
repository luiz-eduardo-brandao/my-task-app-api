using MyTaskApp.Application.InputModels;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Core.Entities;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int idProject)
        {
            var project = await _repository.GetByIdAsync(idProject);

            project.Delete();

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateProjectInputModel inputModel)
        {
            var project = await _repository.GetByIdAsync(inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.Level);

            await _repository.SaveChangesAsync();
        }
    }
}
