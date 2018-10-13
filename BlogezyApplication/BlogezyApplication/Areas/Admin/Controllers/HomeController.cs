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
        
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddArticle(AppUser appUser)
        {
            ViewBag.AppUserID = appUser.Id;
            ViewBag.AppUserName = appUser.UserName;

            return View(new Article);
        }


    }
}
