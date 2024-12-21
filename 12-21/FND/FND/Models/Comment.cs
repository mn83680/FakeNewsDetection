using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FND.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign Key to User
        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; } = new ApplicationUser();

        // Foreign Key to News
        public int NewsId { get; set; }
        public News News { get; set; } = new News();

        
    }
}