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
    public class HomeController : Controller {


        private AnimDispaContext db = new AnimDispaContext();

        public ActionResult Index(string nom, string idStatut, string idType) {

            if (idStatut == null) { idStatut = "1"; }
            if (idType == null) { idType = ""; }
            if (nom == null) { nom = ""; }
            
            var model = new ViewModelListeAnimaux() {

                animaux = db.Animaux
                            .Where(x => x.StatutAnimal.Id.ToString().Contains(idStatut))
                            .Where(x => x.Race.Type.Id.ToString().Contains(idType))
                            .Where(x => x.Nom.Contains(nom))
                            .ToList(),
                LesTypes = db.Types.ToList(),
                LesStatuts = db.StatutAnimal.ToList(),
                Nom = nom,
                IdStatut = idStatut,
                IdType = idType
            };

            return View(model);
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