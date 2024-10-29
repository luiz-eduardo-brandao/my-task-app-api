using Microsoft.Extensions.DependencyInjection;
using MyTaskApp.Application.Interfaces;
using MyTaskApp.Application.Services;

namespace MyTaskApp.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
