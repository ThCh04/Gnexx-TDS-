using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gnexx.Controllers
{
    public class CommunityController : Controller
    {
        // GET: CommunityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommunityController/Details/5
        public ActionResult Details(int id)
        {
            return View("Publish/Details");
        }

        // GET: CommunityController/Create
        public ActionResult Create()
        {
            return View("Publish/Create");
        }

        // POST: CommunityController/Create
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
                return View("Publish/Create");
            }
        }

        // GET: CommunityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Publish/Edit");
        }

        // POST: CommunityController/Edit/5
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
                return View("Publish/Edit");
            }
        }

        // GET: CommunityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Publish/Delete");
        }

        // POST: CommunityController/Delete/5
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
                return View("Publish/Delete");
            }
        }
    }
}
