using Gnexx.Services.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gnexx.Controllers
{
     
    [Authorize(Roles = "Player")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //https://localhost:7085/Home
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}