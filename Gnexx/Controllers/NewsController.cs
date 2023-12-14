using Microsoft.AspNetCore.Mvc;
using Gnexx.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.NewsViewModel;
using Gnexx.Services.DTOs.Account;


namespace Gnexx.Controllers
{
    //[Authorize(Roles = "Player")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NewsController(INewsService newsService, IHttpContextAccessor httpContextAccessor)
        {
            _newsService = newsService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            string name = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").FirstName;
            string uname =_httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user").UserName;
            string uid = "1";

            ViewBag.name = name; ViewBag.uname = '@'+uname; ViewBag.uid = uid;
            var newsList = await _newsService.GetAllViewModel();
            List<Gnexx.Services.ViewModels.NewsViewModel.NewsViewModel> list = newsList.ToList();
            return View(newsList);
        }

      


        [HttpPost]
        public async Task <IActionResult> Create(NewsViewModel news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Add(news);
                return RedirectToAction("GetAll");
            }
            return View(news);
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
