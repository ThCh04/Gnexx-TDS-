using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gnexx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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