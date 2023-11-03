using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Gnexx.Models;
using Gnexx.Repository.Context;
using Gnexx.Models.Entities;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Gnexx.Controllers
{
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

        
        public ActionResult Insert()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Insert(News news)
        {
            if (ModelState.IsValid)
            {
                _db.News.Add(news);
                _db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View(news);
        }

      
        public ActionResult Update(int id)
        {
            News news = _db.News.Find(id);
            return View(news);
        }

        
        [HttpPost]
        public ActionResult Update(News news)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(news).State = EntityState.Modified;
               _db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View(news);
        }

        
        public ActionResult Delete(int id)
        {
            News news = _db.News.Find(id);
            return View(news);
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
