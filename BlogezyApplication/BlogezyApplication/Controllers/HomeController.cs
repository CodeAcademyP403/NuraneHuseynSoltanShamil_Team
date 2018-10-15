using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogezyApplication.Models;
using BlogezyApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogezyApplication.Controllers
{
    public class HomeController : Controller
    {
        private BlogezyDbContext _blogezyDbContext { get; set; }

        public HomeController(BlogezyDbContext blogezyDbContext)
        {
            _blogezyDbContext = blogezyDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserViewModel appUser)
        {
            AppUser FindedUser;

            bool IsRegistered = false;
            bool IsAdmin = false;

            bool EmailFinded = _blogezyDbContext.AppUsers.Any(x => x.Email.Equals(appUser.Email));

            if (EmailFinded)
            {
                FindedUser = _blogezyDbContext.AppUsers.Where(x => x.Email == appUser.Email).FirstOrDefault();
                if (FindedUser.Password.Equals(appUser.Password))
                {
                    switch (FindedUser.Role) { case Role.Admin: IsAdmin = true; break; }
                    
                    IsRegistered = true;
                }
            }

            if (IsRegistered)
            {

                //ARTICLE  VE MENUlarin INDEXPAGE-e CIXARIB GOSTERILMESI
                var menuElements = await _blogezyDbContext.Menus
                                          .Where(x => x.Visibility == true)
                                                                .ToListAsync();

                var articles = await _blogezyDbContext.Articles
                                        .Where(x => x.Visibility == true)
                                                                .ToListAsync();

                if (IsAdmin) {
                    menuElements.AddRange(await _blogezyDbContext.Menus
                                .Where(x => x.Visibility == false)
                                                      .ToListAsync());
                    articles.AddRange(await _blogezyDbContext.Articles
                                .Where(x => x.Visibility == false)
                                                      .ToListAsync());
                }


                Common common = new Common()
                {
                    Menus = menuElements,
                    Articles = articles
                };

                ViewBag.IsAdmin = IsAdmin;
                return View(common);
            }
            else
            {
                HttpContext.Items["ValidationInfo"] = "There is no such a User";
                return RedirectToAction(nameof(Login));
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View(new AppUser());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUser user)
        {
            bool IsAlreadyRegistered = _blogezyDbContext.AppUsers.Any(x => x.Email.Equals(user.Email));


            if (ModelState.IsValid && !IsAlreadyRegistered)
            {

                user.Role = Role.User;

                await _blogezyDbContext.AppUsers.AddAsync(user);

                await _blogezyDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }

            return View();

        }


        [HttpGet]
        public IActionResult Login()
        {
            //   ViewBag.ValidationInfo = HttpContext.Items["ValidationInfo"].ToString();
            return View(new AppUserViewModel());
        }

        [HttpGet]
        public async Task< IActionResult >AdminPanel()
        {

            ViewBag.UserList = await _blogezyDbContext.AppUsers.ToListAsync();
            ViewBag.ArticleList = await _blogezyDbContext.Articles.ToListAsync();
            

            return View(new AppUserViewModel());
        }
    }
}