namespace FND.Models
{
    public class Role
    {
        public int Id { get; set; } // Primary Key
        public string RoleName { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
    }
}