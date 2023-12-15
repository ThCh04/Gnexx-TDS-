using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            return View("User/Profile");
        }
    }
}
