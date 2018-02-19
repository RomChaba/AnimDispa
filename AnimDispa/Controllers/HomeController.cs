using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimDispa.Models;

namespace AnimDispa.Controllers
{
    public class HomeController : Controller
    {
        private AnimDispaContext db = new AnimDispaContext();

        public ActionResult Index()
        {
            return View (db.Animaux
                            .Where(x => x.StatutAnimal.Libelle.Contains("Perdu"))
                            .ToList());
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