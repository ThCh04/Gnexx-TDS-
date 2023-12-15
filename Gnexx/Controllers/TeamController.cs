using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Helpers;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.Services.Interfaces;
using Gnexx.Services.UserIdentity;
using Gnexx.Services.ViewModels.CoachViewModel;
using Gnexx.Services.ViewModels.PlayerViewModel;
using Gnexx.Services.ViewModels.UserEntitie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class TeamController : Controller
    {
        private readonly ICoachService _coachService;
        private readonly IPlayerService _playerService;
        private readonly ITeamsService _teamsService;
        private readonly IUserEntityService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TeamController(ITeamsService teamsService, ICoachService coach, IPlayerService player, IUserEntityService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _teamsService = teamsService;
            _coachService = coach;
            _playerService = player;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: TeamController
        public async Task<ActionResult> Index()
        {
            await _teamsService.SeedAsync();
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
            coach.TeamID = 1;
            if (!ModelState.IsValid)
            {
                return View(coach);
            }

            await _coachService.Add(coach);
            return View("/Teams");
        }

        public ActionResult Player()
        {
            return View(new PlayerViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlayerAsync(PlayerViewModel player)
        {
            player.TeamID = 1;

            string email = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").Email;

            List<UserEntitieViewModel> users = await _userService.GetAllViewModel();

            int idUser = 0;
            foreach(var user in users)
            {
                if(user.Email == email)
                {
                    idUser = user.Id;
                }
            }
            player.UserID = idUser;
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            await _playerService.Add(player);
            return View("/Teams");
        }
    }
}
