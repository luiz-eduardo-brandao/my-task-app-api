using MyTaskApp.Core.Enums;
using System;
using System.Text.Json.Serialization;

namespace MyTaskApp.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, string imageUrl, ProjectLevelEnum level, int idUser)
            : base()
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
            Level = level;
            IdUser = idUser;

            Active = true;
            Tasks = new List<ProjectTask>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ProjectLevelEnum Level { get; set; }
        public int IdUser { get; set; }
        public bool Active { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        
        public List<ProjectTask> Tasks { get; set; }

        public void Update(string title, string description, ProjectLevelEnum level)
        {
            Title = title;
            Description = description;
            Level = level;
        }

        public void Delete()
        {
            Active = false;
        }
    }
}
