using FND.Models;
using Microsoft.AspNetCore.Identity;

namespace NewsClassNet6.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
    }
}