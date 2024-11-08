namespace MyTaskApp.Core.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string CreatedAt { get; set; }
        public string Image { get; set; }
        public int Level { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
}
