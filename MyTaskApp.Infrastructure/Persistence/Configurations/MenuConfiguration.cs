using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTaskApp.Core.Entities;

namespace MyTaskApp.Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(m => m.FatherMenu)
                .WithMany(m => m.SubMenu)
                .HasForeignKey(m => m.IdFatherMenu)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new List<Menu>
            {
                new Menu(1, null, "Home", "/", "mdi-home"),
                new Menu(2, null, "Projetos", "/projects", "mdi-email"),
                new Menu(3, null, "Tarefas", "/tasks", "mdi-check-outline"),
                new Menu(4, null, "Overview (em breve)", null, "mdi-monitor-dashboard"),
                new Menu(5, 4, "Dashboard", null, "mdi-view-dashboard-edit-outline"),
                new Menu(6, 4, "Relatório", null, "mdi-chart-line"),
            });
        }
    }
}
