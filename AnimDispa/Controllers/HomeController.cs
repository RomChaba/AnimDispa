using AnimDispa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class HomeController : Controller {

        private AnimDispaContext db = new AnimDispaContext();

        public ActionResult Index()
        {
            Animaux animaux = db.
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}