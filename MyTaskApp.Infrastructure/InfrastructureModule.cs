using Microsoft.Extensions.DependencyInjection;
using MyTaskApp.Core.Repositories;
using MyTaskApp.Core.Services;
using MyTaskApp.Infrastructure.Auth;
using MyTaskApp.Infrastructure.Persistence.Repositories;

namespace MyTaskApp.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
