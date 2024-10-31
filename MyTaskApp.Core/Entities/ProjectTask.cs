using MyTaskApp.Core.Enums;
using System.Text.Json.Serialization;

namespace MyTaskApp.Core.Entities
{
    public class ProjectTask : BaseEntity
    {
        public ProjectTask(string title, string description, int idUser, int idProject)
            : base()
        {
            Title = title;
            Description = description;
            IdUser = idUser;
            IdProject = idProject;

            Active = true;
            Status = TaskStatusEnum.Created;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int IdUser { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }
        
        public int IdProject { get; set; }

        [JsonIgnore]
        public Project Project { get; set; }
        public TaskStatusEnum Status { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public bool Active { get; set; }

        public void Update(string title, string descrption)
        {
            Title = title;
            Description = descrption;
        }

        public void Delete() => Active = false;

        public void Start()
        {
            if (Status == TaskStatusEnum.Created && StartedAt is null)
            {
                Status = TaskStatusEnum.InProgress;
                StartedAt = DateTime.UtcNow;
            }
        }

        public void Finish()
        {
            if (Status == TaskStatusEnum.InProgress && FinishedAt is null)
            {
                Status = TaskStatusEnum.Finished;
                FinishedAt = DateTime.UtcNow;
            }
        }
    }
}
