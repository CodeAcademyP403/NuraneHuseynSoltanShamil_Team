using BlogezyApplication.Models;
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
        public IActionResult AddArticle(AppUser appUser)
        {
            ViewBag.AppUserID = appUser.Id;
            ViewBag.AppUserName = appUser.UserName;

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

            return View();
        }



    }
}
