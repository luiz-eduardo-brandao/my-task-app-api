namespace MyTaskApp.Core.Entities
{
    public class User : BaseEntity
    {
        public User() : base()
        {
            
        }

        public User(string fullName, DateTime birthDate, string phoneNumber, string bio, string profileImage,
            string email, string password, string role)
            : base()
        {
            FullName = fullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Bio = bio;
            ProfileImage = profileImage;
            Email = email;
            Password = password;
            Role = role;

            Active = true;
            Projects = new List<Project>();
            Tasks = new List<ProjectTask>();
        }

        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
        public List<Project> Projects { get; set; }
        public List<ProjectTask> Tasks { get; set; }

        public void Update(string fullName, DateTime birthDate, string phoneNumber, string bio,
            string profileImage)
        {
            FullName = FullName;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Bio = bio;
            ProfileImage = profileImage;
        }
    }
}
