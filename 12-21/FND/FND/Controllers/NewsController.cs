using FND.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FND.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly Entity context;
        private readonly ILogger<NewsController> _logger;
        private readonly UserManager<ApplicationUser> userManager;

        public NewsController(UserManager<ApplicationUser> userManager, Entity context, ILogger<NewsController> logger)
        {
            this.userManager = userManager;
            this.context = context;
            this._logger = logger;
        }

        //...............................................................................................................new
        [Authorize(Roles = "Admin , Publisher")]
        public IActionResult New()
        {
            ViewBag.cats = context.Categories.ToList();
            ViewBag.images = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"))
                                      .Select(Path.GetFileName)
                                      .ToList();
            return View(new News());
        }

        [Authorize]
        [HttpPost]
        public IActionResult New(News model)
        {
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.IsFake = false;
            //model.AuthId = model.Author.Id;


            context.News.Add(model);
            context.SaveChanges();

            return RedirectToAction("New");
        }

        //...............................................................................................................AllNews
        public IActionResult AllNews()
              {
                var cateModel = context.News.ToList();
                return View(cateModel);
              }

            //.................................................................................................................Search
            public IActionResult SearchResult(string searchTerm)
            {
            var newsItem = context.News.Where(n => n.Title.Contains(searchTerm)).ToList();

            if (!newsItem.Any())
            {
                return View("NoResults");
            }

            return View(newsItem);
            }
            //..................................................................................................................Edit
            [Authorize(Roles = "Admin , Publisher")]
            public IActionResult Edit(int id)
            {
                ViewBag.cats = context.Categories.ToList();
                var nes = context.News.FirstOrDefault(n => n.Id == id);
                return View(nes);
            }

            [HttpPost]
            public IActionResult SaveEdit(int id, News newNews)
            {
                var nes = context.News.FirstOrDefault(c => c.Id == id);

                if (nes != null)
                {
                    nes.Title = newNews.Title;
                    nes.Content = newNews.Content;
                    nes.Category_Id = newNews.Category_Id;
                    nes.IsFake = newNews.IsFake;
                    nes.Translation = newNews.Translation;
                    nes.image = newNews.image;
                context.SaveChanges();
                }
                return RedirectToAction("NewsAdmin", "News");
            }
            //................................................................................................................Delete
            [Authorize(Roles = "Admin , Publisher")]
            public IActionResult Delete(int id)
            {
                var ne = context.News.FirstOrDefault(s => s.Id == id);
                if (ne != null)
                {
                    context.News.Remove(ne);
                    context.SaveChanges();
                }
                return RedirectToAction("NewsAdmin");
            }
            //................................................................................................................NewsAdmin
            public IActionResult NewsAdmin()
            {
                var cateModel = context.News.ToList();
                return View(cateModel);
            }

            //................................................................................................................



    }
}

