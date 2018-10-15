using BlogezyApplication.Models;
using BlogezyApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController:Controller
    {

        private BlogezyDbContext BlogezyDbContext { get; set; }
        
        public HomeController(BlogezyDbContext dbContext)
        {
            BlogezyDbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddArticle(AppUserViewModel appUser)
        {
            ViewBag.AppUserViewModelEmail = appUser.Email;
            
            return View(new Article());
        }

        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            article.PublicDate = DateTime.Now;
            article.Visibility = true;
            if (ModelState.IsValid)
            {
                BlogezyDbContext.Articles.Add(article);
                BlogezyDbContext.SaveChanges();
            }

            ViewBag.ArticleState = "Article is Added !";

            return Redirect("../../Home/AdminPanel");
        }


        [HttpPost]
        public async Task<IActionResult >Remove(AppUser user)
        {
            //AppUser userToDeleteFinded = BlogezyDbContext.AppUsers.Find(user.Id);

            var findedToDelete = BlogezyDbContext.AppUsers.Where(x => x.Email == user.Email).FirstOrDefault();
            BlogezyDbContext.AppUsers.Remove(findedToDelete);
          await  BlogezyDbContext.SaveChangesAsync();



            return Redirect("../../Home/AdminPanel");
        }


        [HttpPost]
        public async Task<IActionResult> RemoveArticle( Article article)
        {
            var findedArticleToDelete = BlogezyDbContext.Articles.Where(x => x.Id == article.Id).FirstOrDefault();
            BlogezyDbContext.Articles.Remove(findedArticleToDelete);

            await BlogezyDbContext.SaveChangesAsync();
            return Redirect("../../Home/AdminPanel");

        }

    }
}
