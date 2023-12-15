using Gnexx.Services.DTOs.Account;
using Gnexx.Services.Interfaces.Repository;
using Gnexx.Services.Interfaces.Services;
using Gnexx.Services.Services;
using Gnexx.Services.ViewModels.NewsViewModel;
using Gnexx.Services.ViewModels.PostulationViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostulationViewModel post)
        {
            if (ModelState.IsValid)
            {
                await _postService.Add(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public async Task<IActionResult> Edit(int id)
        {
            PostulationViewModel post = await _postService.GetByIdSaveViewModel(id);
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostulationViewModel post)
        {
            if (ModelState.IsValid)
            {
                await _postService.Update(post, post.Id_post);
                return RedirectToAction("GetAll");
            }
            return View(post);
        }

        public async Task<IActionResult> Delete(int id)
        {
            PostulationViewModel post = await _postService.GetByIdSaveViewModel(id);
            return View(post);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _postService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
