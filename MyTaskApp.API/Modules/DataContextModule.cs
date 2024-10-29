using Microsoft.EntityFrameworkCore;
using MyTaskApp.Infrastructure.Persistence;

namespace MyTaskApp.API.Modules
{
    public static class DataContextModule
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyTaskAppDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("MyTaskApp"))
                 //options.UseInMemoryDatabase("MyTaskApp")
            );

            return services;
        }
    }
}
