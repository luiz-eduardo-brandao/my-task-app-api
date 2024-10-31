using MyTaskApp.Application.InputModels;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Core.Repositories;

namespace MyTaskApp.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateAsync(UpdateTaskInputModel inputModel)
        {
            var task = await _repository.GetByIdAsync(inputModel.Id);

            task.Update(inputModel.Title, inputModel.Description);

            await _repository.SaveChangesAsync();
        }

        public async Task StartAsync(int idTask)
        {
            var task = await _repository.GetByIdAsync(idTask);

            task.Start();

            await _repository.SaveChangesAsync();
        }

        public async Task FinishAsync(int idTask)
        {
            var task = await _repository.GetByIdAsync(idTask);

            task.Finish();

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idTask)
        {
            var task = await _repository.GetByIdAsync(idTask);

            task.Delete();

            await _repository.SaveChangesAsync();
        }
    }
}
