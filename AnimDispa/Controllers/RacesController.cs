using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class RacesController : Controller {

        private AnimDispaContext db = new AnimDispaContext();
        
        public ActionResult Index(int id) {

            return View(db.Types.Find(id));
        }


        // ####################################################################
        // Edit
        public ActionResult Edit(int id)
        {

            return View(db.Races.Find(id));
        }


        // EditConfirm
        public ActionResult EditConfirm(int id, String libelle)
        {

            Races race = db.Races.Find(id);
            race.Libelle = libelle;

            db.SaveChanges();

            return RedirectToAction("Index", "Races", new { id = race.IdType });
        }

        // ####################################################################
        // Add
        public ActionResult Add(int id) {

            return View(db.Types.Find(id));
        }


        // AddConfirm
        public ActionResult AddConfirm(String libelle, int idType) {

            Races race = new Races();
            race.Libelle = libelle;
            race.IdType = idType;
            race.Type = db.Types.Find(idType);

            db.Races.Add(race);
            db.SaveChanges();

            return RedirectToAction("Index", "Races", new { id = idType });
        }


        // ####################################################################
        // Delete
        public ActionResult Delete(int id) {

            Races race = db.Races.Find(id);
            db.Races.Remove(race);
            db.SaveChanges();

            return RedirectToAction("Index", "Races", new { id = race.IdType });
        }
    }
}