namespace FND.Models
{
    public class User
    {
        public int UserId { get; set; } // Primary Key
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key to Role
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Navigation properties
        public ICollection<News> News { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Interaction> Interactions { get; set; }

    }
}
