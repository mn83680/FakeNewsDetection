namespace FND.Models
{
    public class Comment
    {
        public int id { get; set; } // Primary Key
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Key to User
        public int AuthorId { get; set; }
        public User Author { get; set; }

        // Foreign Key to News
        public int NewsId { get; set; }
        public News News { get; set; }

        // Self-referencing for replies
        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; }
    }
}