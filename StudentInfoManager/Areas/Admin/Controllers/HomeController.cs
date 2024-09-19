﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentInfoManager.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
       // [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
