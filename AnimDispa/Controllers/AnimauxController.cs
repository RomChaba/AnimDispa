using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;
using System.Web.Helpers;
using System.IO;

namespace AnimDispa.Controllers
{
    public class AnimauxController : Controller
    {

        private AnimDispaContext db = new AnimDispaContext();

        // GET: Animal
        public ActionResult Index(int id)
        {
            var model = new ViewModelAnimaux()
            {
                animal = db.Animaux.Find(id),
                lesMessages = db.Messages.Where(x => x.Animal.Id == id).ToList(),
                conf = db.Config.Find(1),
                ListeMarker = db.Signalements.Where(x => x.IdAnimaux == id).ToList()
            };

            return View(model);
        }


        public ActionResult Add() {


            var model = new ViewModelAnimauxAdd() {
                lesRaces = db.Races.ToList(),
                lesTypes = db.Types.ToList(),
                lesDepartements = db.Departements.ToList()
                
            };



            return View(model);
        }

        public ActionResult AddConfirm(string nom, decimal poids, string couleur, string tatouage, string puce, int race, string img, int departement, string rue, string cp, string ville, HttpPostedFileBase upload) {

            if (upload != null && upload.ContentLength > 0) {
                
                var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName);
                string RootFolder = @Server.MapPath("~/content/img");
                string path = Path.Combine(RootFolder, fileName);
                upload.SaveAs(path);
                //db.SubmidtChanges();
            }

            Animaux animal = new Animaux();
            animal.Nom = nom;
            animal.Poids = poids;
            animal.Couleur = couleur;
            animal.Tatouage = tatouage;
            animal.Puce = puce;
            animal.Race = db.Races.Find(race);
            animal.PhotoPrincipale = img;
            animal.Departement = db.Departements.Find(departement);
            animal.Rue = rue;
            animal.CodePostal = cp;
            animal.Ville = ville;
            animal.StatutAnimal = db.StatutAnimal.Find(1);
            animal.Compte = db.Comptes.Find(Session["idConnecte"]);

            db.Animaux.Add(animal);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}