using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class ConfigController : Controller {

        private AnimDispaContext db = new AnimDispaContext();

        public ActionResult Index()
        {
            return View(db.Config.ToList());
        }

        public ActionResult Edit(int id){

            Config conf = db.Config.Find(id);

            if (conf.Value == true) {
                conf.Value = false;
            } else {
                conf.Value = true;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Config");
        }
    }
}