using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTaskApp.Core.Entities;

namespace MyTaskApp.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(t => t.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
