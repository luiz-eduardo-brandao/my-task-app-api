using MyTaskApp.Core.Enums;

namespace MyTaskApp.Application.InputModels
{
    public class UpdateProjectInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectLevelEnum Level { get; set; }
    }
}
