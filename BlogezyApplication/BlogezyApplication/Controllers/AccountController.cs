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
    public class AccountController : Controller
    {

        private BlogezyDbContext _blogezyDbContext { get; set; }

        public AccountController(BlogezyDbContext blogezyDbContext )
        {
            _blogezyDbContext = blogezyDbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new AppUser());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUser user)
        {
            if (ModelState.IsValid)
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
            return View(new AppUserViewModel());
        }

        [HttpPost]
        public  IActionResult Login(AppUserViewModel appUser)
        {
            bool IsRegistered = _blogezyDbContext.AppUsers.Any(x => x.Email.Equals(appUser.Email));

            if (IsRegistered)
            {
                return RedirectToPage("Account/Home/Index");
            }
            else
            {
                ViewBag.Info = "There is no such a User";
                return View();
            }
        }

    }
}