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
    }
}
