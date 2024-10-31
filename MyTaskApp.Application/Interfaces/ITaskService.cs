using MyTaskApp.Application.InputModels;

namespace MyTaskApp.Application.Interfaces
{
    public interface ITaskService
    {
        Task UpdateAsync(UpdateTaskInputModel inputModel);
        Task DeleteAsync(int idTask);
        Task StartAsync(int idTask);
        Task FinishAsync(int idTask);
    }
}
