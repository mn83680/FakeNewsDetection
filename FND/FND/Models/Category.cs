namespace FND.Models
{
    public class Category
    {
        public int id { get; set; } // Primary Key
        public string CategoryName { get; set; }

        // Navigation property
        public ICollection<News> News { get; set; }
    }
}