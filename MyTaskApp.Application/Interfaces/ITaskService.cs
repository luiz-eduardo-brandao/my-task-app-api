namespace MyTaskApp.Application.Interfaces
{
    public interface ITaskService
    {
        Task StartAsync(int idTask);
        Task FinishAsync(int idTask);
    }
}
