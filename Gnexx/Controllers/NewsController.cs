using Microsoft.AspNetCore.Mvc;
using Gnexx.Repository.Context;
using Gnexx.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Gnexx.Controllers
{
    [Authorize(Roles="Player")]
    public class NewsController : Controller
    {
        private readonly GnexxDbContext _db;
        public NewsController( GnexxDbContext db)
        {
            _db=db;
                
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            List<News> newsList = _db.News.ToList();
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
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                _db.News.Add(news);
                _db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Publish/Create", news);
        }

      
        public ActionResult Edit(int id)
        {
            News news = _db.News.Find(id);
            return View("Publish/Edit", news);
        }

        
        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(news).State = EntityState.Modified;
               _db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Publish/Edit", news);
        }

        
        public ActionResult Delete(int id)
        {
            News news = _db.News.Find(id);
            return View("Publish/Delete", news);
        }

       
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = _db.News.Find(id);
            _db.News.Remove(news);
            _db.SaveChanges();
            return RedirectToAction("GetAll");
        }
    }
}
