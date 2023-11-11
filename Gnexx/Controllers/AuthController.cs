using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult Index()
        {
            ViewBag.EsPaginaDeInicioDeSesion = true;
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.EsPaginaDeInicioDeSesion = true;
            return View();
        }
        public ActionResult forgot_password()
        {
            ViewBag.EsPaginaDeInicioDeSesion = true;
            return View();
        }
    }
}
