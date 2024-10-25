using MyTaskApp.Core.Enums;

namespace MyTaskApp.API.Models
{
    public class CreateProjectInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ProjectLevelEnum Level { get; set; }
        public int IdUser { get; set; }
    }
}
