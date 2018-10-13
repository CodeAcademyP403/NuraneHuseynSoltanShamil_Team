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
    public class AccountController:Controller
    {

        public IActionResult Index(AppUserViewModel appUser)
        {
            appUser = null;
            return View();
        }


    }
}
