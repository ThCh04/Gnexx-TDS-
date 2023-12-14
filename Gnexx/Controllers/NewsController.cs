using Microsoft.AspNetCore.Mvc;
using Gnexx.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.NewsViewModel;
using Gnexx.Services.DTOs.Account;


namespace Gnexx.Controllers
{
    [Authorize(Roles = "Player")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NewsController(INewsService newsService, IHttpContextAccessor httpContextAccessor)
        {
            _newsService = newsService;
            _httpContextAccessor = httpContextAccessor;
        }
        public ActionResult Index()
        {
            string name = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").FirstName;
            string uname =_httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").UserName;

            ViewBag.name = name; ViewBag.uname = '@'+uname;
            return View(new NewsViewModel());
        }

        public async Task<IActionResult> GetAll()
        {
            List<NewsViewModel> newsList = await _newsService.GetAllViewModel();
            return View(newsList);
        }


        public ActionResult Create()
        {
            return View("Publish/Create");
        }

        [HttpPost]
        public async Task <IActionResult> Create(NewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Add(news);
                return RedirectToAction("GetAll");
            }
            return View("Publish/Create", news);
        }

        public ActionResult Details(int id)
        {
            return View("Publish/Details");
        }

        public async Task <IActionResult> Edit(int id)
        {
           NewsViewModel news = await _newsService.GetByIdSaveViewModel(id);
            return View("Publish/Edit", news);
        }

        
        [HttpPost]
        public async Task <IActionResult> Edit(NewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Update(news, news.ID); 
                return RedirectToAction("GetAll");
            }
            return View("Publish/Edit", news);
        }

        
        public async Task <IActionResult> Delete(int id)
        {
            NewsViewModel news = await _newsService.GetByIdSaveViewModel(id);
            return View("Publish/Delete", news);
        }

       
        [HttpPost]
        public async Task <IActionResult> DeleteConfirmed(int id)
        {
            await _newsService.Delete(id);
            return RedirectToAction("GetAll");
        }
    }
}
