using Microsoft.AspNetCore.Mvc;
using Gnexx.Repository.Context;
using Gnexx.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.ViewModels.NewsViewModel;

namespace Gnexx.Controllers
{
    [Authorize(Roles = "Player")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;

        }
        public ActionResult Index()
        {
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

        public ActionResult Details(int id)
        {
            return View("Publish/Details");
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
