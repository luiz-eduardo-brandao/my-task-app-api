using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTaskApp.Core.Entities;

namespace MyTaskApp.Infrastructure.Persistence.Configurations
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
