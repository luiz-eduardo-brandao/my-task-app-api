using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTaskApp.Core.Entities;
using System.Data;

namespace MyTaskApp.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder.HasData(new User
            {
                Id = 1,
                FullName = "MyTaskApp",
                BirthDate = DateTime.UtcNow.AddYears(-2),
                PhoneNumber = "",
                Bio = "",
                ProfileImage = "",
                Email = "admin@gmail.com",
                Password = "admin123",
                Role = "admin",
                Active = true,
                Projects = new List<Project>(),
                Tasks = new List<ProjectTask>()
            });
        }
    }
}
