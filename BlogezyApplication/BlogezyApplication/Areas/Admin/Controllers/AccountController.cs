﻿using BlogezyApplication.Models;
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
        public IActionResult Index()
        {
            
            return View();
        }


    }
}
