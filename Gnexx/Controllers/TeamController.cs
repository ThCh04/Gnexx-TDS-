using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.CoachViewModel;
using Gnexx.Services.ViewModels.PlayerViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class TeamController : Controller
    {
        private readonly ICoachService _coachService;
        private readonly IPlayerService _playerService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public TeamController(ICoachService coach, IPlayerService player, IHttpContextAccessor httpContextAccessor)
        {
            _coachService = coach;
            _playerService = player;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: TeamController
        public ActionResult Index()
        {

            string rol = "";
            foreach (var r in _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").Roles)
            {
                rol = r;
            }
            ViewBag.Rol = rol;
            return View();
        }

        // GET: TeamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeamController/Create
        public ActionResult Create()
        {
            return View("Request/Create");
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Coach()
        {
            return View(new CoachViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CoachAsync(CoachViewModel coach)
        {
            if (!ModelState.IsValid)
            {
                return View(coach);
            }

            await _coachService.Add(coach);
            return View("/Index");
        }

        public ActionResult Player()
        {
            return View(new PlayerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlayerAsync(PlayerViewModel player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            await _playerService.Add(player);
            return View("/Index");
        }
    }
}
