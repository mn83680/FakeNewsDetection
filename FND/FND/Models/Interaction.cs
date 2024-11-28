namespace FND.Models
{
    public class Interaction
    {
        public int id { get; set; } // Primary Key
        public string Type { get; set; } // e.g., Like, Share

        // Foreign Key to User
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign Key to News
        public int NewsId { get; set; }
        public News News { get; set; }
    }
}