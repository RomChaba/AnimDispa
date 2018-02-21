using AnimDispa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class AjaxController : Controller
    {
        private AnimDispaContext db = new AnimDispaContext();
        public JsonResult MarkerAdd(string lat, string lgt, int? idAnim)
        {
            Signalements Sign = new Signalements();
            Sign.Date = DateTime.Now;
            Sign.Latitude = lat;
            Sign.Longitude = lgt;
            Sign.IdAnimaux = (int)idAnim;
            Sign.Animaux = db.Animaux.Find(idAnim);
            db.Signalements.Add(Sign);
            db.SaveChanges();
            var Sort = Json(Sign);
            return Sort;
        }
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ajax/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ajax/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ajax/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Ajax/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ajax/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ajax/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ajax/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
