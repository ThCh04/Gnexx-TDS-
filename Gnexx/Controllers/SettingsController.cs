﻿using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
