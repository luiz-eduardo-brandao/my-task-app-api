﻿namespace MyTaskApp.Core.DTOs
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdUser  { get; set; }
        public int IdProject { get; set; }
        public string ProjectTitle { get; set; }
        public string TimeConsumed { get; set; }
        public string CreatedAt { get; set; }
        public string? StartedAt { get; set; }
        public string? FinishedAt { get; set; }
    }
}
