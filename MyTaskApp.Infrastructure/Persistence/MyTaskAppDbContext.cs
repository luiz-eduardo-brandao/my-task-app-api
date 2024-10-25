using Microsoft.EntityFrameworkCore;
using MyTaskApp.Core.Entities;
using System.Reflection;

namespace MyTaskApp.Infrastructure.Persistence
{
    public class MyTaskAppDbContext : DbContext
    {
        public MyTaskAppDbContext(DbContextOptions<MyTaskAppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Menu> Menus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
