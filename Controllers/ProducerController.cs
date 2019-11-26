using CinemaManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CinemaManager.Controllers
{
    public class ProducerController : Controller
    {
        CinemaEntities ce = new CinemaEntities();

        public ActionResult ProdsAndTheirMovies_UsingModel(int id)
        {
            var list = from p in ce.Producer
                       join m in  ce.Movie
                       on p.Id equals m.producerId
                       where p.Id == id
                       select new ProdMovie
                       {
                   
                           pName = p.name_,
                           pNat = p.nationality,
                            mTitle = m.title,
                           mGenre = m.genre
                       };
            return View(list);
        }
        public ActionResult ProdsAndTheirMovies()
        {
            var list = ce.Producer.ToList();

            return View(list);
        }
        // GET: Producer
        public ActionResult Index()
        {
          var list = ce.Producer.ToList();

            return View(list);
        }

        // GET: Producer/Details/5
        public ActionResult Details(int id)
        {
            var p = ce.Producer.Find(id);   
            return View(p);
        }

        // GET: Producer/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        public ActionResult Create(Producer p)
        {

            
            try
            {
                // TODO: Add insert logic here
                ce.Producer.Add(p);
                ce.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producer/Edit/5
        public ActionResult Edit(int id)
        {
            var p = ce.Producer.Find(id);

            return View(p);
        }

        // POST: Producer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producer p)
        {
            try
            {
                // TODO: Add update logic here
                ce.Entry(p).State =
                    EntityState.Modified;
                ce.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producer/Delete/5
        public ActionResult Delete(int id)
        {
            var p = ce.Producer.Find(id);
            return View(p);
        }

        // POST: Producer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Producer p)
        {
            try
            {
                // TODO: Add delete logic here
                ce.Entry(p).State =
                    EntityState.Deleted;
                ce.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
