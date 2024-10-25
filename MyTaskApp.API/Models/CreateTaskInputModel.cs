namespace MyTaskApp.API.Models
{
    public class CreateTaskInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}
