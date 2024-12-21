using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FND.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key
        [Required]
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? image { get; set; }
        public bool? IsFake { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public string? Translation { get; set; }

        [ForeignKey("ApplicationUser")]
        public int? AuthId { get; set; }
        public ApplicationUser? Author { get; set; }

        // Foreign Key to Category
        [ForeignKey("Category")]
        public int? Category_Id { get; set; }  // Clear foreign key indication
        public virtual Category? Category { get; set; }
        

        // Navigation properties
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Interaction>? Interactions { get; set; }

    }
}