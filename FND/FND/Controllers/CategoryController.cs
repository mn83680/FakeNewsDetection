using FND.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FND.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        Entity context = new Entity();  
        //................................................................................................Index
        public IActionResult Index()
        {
            List<Category> deptList = context.Categories.ToList();

            
            return View(deptList);
           
        }
        //................................................................................................New
        public IActionResult New()
        {
            //view="New",Model=null
            return View(new Category());
        }
        //<form method="post">
        [HttpPost]
        public IActionResult SaveNew(Category cat)//Brimitev Type -> if exist -> Storage -> else = Null .
        {
            if (cat.Name != null)
            {
                context.Categories.Add(cat);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();

        }
        //................................................................................................Details
        public IActionResult Details(int id)
        {
            Category cat = context.Categories.FirstOrDefault(d => d.Id == id);
            return View("Details", cat);
        }

        //................................................................................................Delete
        public IActionResult Delete(int id)
        {
            Category? cat = context.Categories.FirstOrDefault(s => s.Id == id);
            context.Categories.Remove(cat);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        //................................................................................................Categories
        public IActionResult Category()
        {
            List<Category> cateModel = context.Categories.ToList();

            return View(cateModel);
        }
        //................................................................................................Sport
        public IActionResult Sport()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
        //................................................................................................Political
        public IActionResult Political()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }

        //................................................................................................Economic
        public IActionResult Economic()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
        //................................................................................................Technology
        public IActionResult Technology()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
        //................................................................................................Food
        public IActionResult Food()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
        //................................................................................................StyleAndBeauty
        public IActionResult StyleAndBeauty()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
        //................................................................................................Education
        public IActionResult Education()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
        //................................................................................................Crime
        public IActionResult Crime()
        {
            
            List<News> cateModel = context.News.ToList();
            

            return View(cateModel);
        }
    }
}
