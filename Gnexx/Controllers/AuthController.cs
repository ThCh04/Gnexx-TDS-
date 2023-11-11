using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        public ActionResult forgot_password()
        {
            return View();
        }
    }
}
