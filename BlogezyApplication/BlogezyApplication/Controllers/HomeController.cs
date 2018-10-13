using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogezyApplication.Models;
using BlogezyApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(AppUserViewModel appUser)
        {

            bool IsRegistered = false;

            bool EmailFinded = _blogezyDbContext.AppUsers.Any(x => x.Email.Equals(appUser.Email));

            if (EmailFinded)
            {
                AppUser FindedUser = _blogezyDbContext.AppUsers.Where(x => x.Email == appUser.Email).FirstOrDefault();
                if (FindedUser.Password == appUser.Password)
                {
                    IsRegistered = true;
                }
            }

            if (IsRegistered)
            {
                return View();
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
            ViewBag.ValidationInfo = HttpContext.Items["ValidationInfo"].ToString();
            return View(new AppUserViewModel());
        }
    }
}