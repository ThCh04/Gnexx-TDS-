using Gnexx.Middleware;
using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Enums;
using Gnexx.Services.Helpers;
using Gnexx.Services.Services.Interfaces;
using Gnexx.Services.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gnexx.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;

        public AuthController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public ActionResult Index()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            AuthenticationResponse response = await _userService.LoginAsync(login);
            if (response != null && response.HasError != true)
            {
                HttpContext.Session.Set<AuthenticationResponse>("user", response);
                if (response.Roles[0] == Roles.Player.ToString())
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                return RedirectToRoute(new { controller = "Team", action = "Index" });
            }
            else
            {
                login.HasError = response.HasError;
                login.Error = response.Error;
                return View(login);
            }
        }
        [ServiceFilter(typeof(LoginFilter))]
        public ActionResult Register()
        {
            string[] rolesNames = Enum.GetNames(typeof(Roles));

            List<string> roles = new List<string>();
            foreach (var roleName in rolesNames)
            {
                if(roleName != Roles.SuperAdmin.ToString())
                {
                    roles.Add(roleName);
                }
            }
            ViewBag.Rol = new SelectList(roles);
            return View(new SaveUserVM());
        }

        [ServiceFilter(typeof(LoginFilter))]
        [HttpPost]
        public async Task<ActionResult> Register(SaveUserVM saveUser)
        {
            if (!ModelState.IsValid)
            {
                string[] rolesNames = Enum.GetNames(typeof(Roles));

                List<string> roles = new List<string>();
                foreach (var roleName in rolesNames)
                {
                    if (roleName != Roles.SuperAdmin.ToString())
                    {
                        roles.Add(roleName);
                    }
                }
                ViewBag.Rol = new SelectList(roles);
                return View(saveUser);
            }
            var origin = Request.Headers["origin"];
            RegisterResponse register = await _userService.RegisterAsync(saveUser, origin);
            if (register.HasError)
            {
                string[] rolesNames = Enum.GetNames(typeof(Roles));

                List<string> roles = new List<string>();
                foreach (var roleName in rolesNames)
                {
                    if (roleName != Roles.SuperAdmin.ToString())
                    {
                        roles.Add(roleName);
                    }
                }
                ViewBag.Rol = new SelectList(roles);
                saveUser.Error = register.Error;
                saveUser.HasError = register.HasError;
                return View(saveUser);
            }

            return RedirectToRoute(new { controller = "Auth", Action = "Index" });
        }

        

        [ServiceFilter(typeof(LoginFilter))]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await _userService.ConfirmEmailAsync(userId, token);

            return View("ConfirmEmail", response);
        }

        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordVM());
        }

        [ServiceFilter(typeof(LoginFilter))]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var origin = Request.Headers["origin"];
            ForgotPasswordResponse response = await _userService.ForgotPasswordAsync(vm, origin);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }

        public ActionResult SignOut()
        {
            _userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "Auth", Action = "Index" });
        }
    }
}
