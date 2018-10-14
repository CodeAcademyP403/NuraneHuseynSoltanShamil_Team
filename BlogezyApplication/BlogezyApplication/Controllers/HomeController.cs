using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogezyApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogezyApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogezyDbContext context;
        public HomeController(BlogezyDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var menuElements = await context.Menus
                                        .Where(x => x.Visibility == true)
                                            .ToListAsync();

            var articles = await context.Articles
                                    .Where(x => x.Visibility == true)
                                        .ToListAsync();
            Common common = new Common()
            {
                Menus = menuElements,
                Articles=articles
            };

            return View(common);
        }
    }
}