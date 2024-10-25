namespace MyTaskApp.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
