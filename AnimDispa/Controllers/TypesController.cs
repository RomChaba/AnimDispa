using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class TypesController : Controller {

        private AnimDispaContext db = new AnimDispaContext();


        // Index
        public ActionResult Index() {
            return View(db.Types.ToList());
        }

        // ####################################################################
        // Edit
        public ActionResult Edit(int id) {

            return View(db.Types.Find(id));
        }


        // EditConfirm
        public ActionResult EditConfirm(int id, String libelle) {

            Types type = db.Types.Find(id);
            type.Libelle = libelle;

            db.SaveChanges();

            return RedirectToAction("Index", "Types");
        }

        // ####################################################################
        // Add
        public ActionResult Add()
        {

            return View();
        }


        // AddConfirm
        public ActionResult AddConfirm(String libelle) {

            Types type = new Types();
            type.Libelle = libelle;

            db.Types.Add(type);
            db.SaveChanges();

            return RedirectToAction("Index", "Types");
        }

    }
}