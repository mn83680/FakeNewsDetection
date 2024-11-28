using Microsoft.EntityFrameworkCore;



namespace FND.Models
{
    public class Entity:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=. ; Initial Catalog=NewsSPU1 ; Integrated Security=True;Encrypt=True ; Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        // add-migration init
        // update-database   ......
        //dotnet ef migrations add InitialCreate
        //dotnet ef database update


    }
}

