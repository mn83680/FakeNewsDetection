using FND.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FND.Controllers
{
    public class UsersController : Controller
    {
        Entity context = new Entity();
        public IActionResult Users()
        {
            
                List<ApplicationUser> AppModel = context.Users.ToList();

                return View(AppModel);
            
        }
        
    }
}
