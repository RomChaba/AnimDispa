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


        public ActionResult Add()
        {


            var model = new ViewModelAnimauxEdit()
            {
                lesRaces = db.Races.ToList(),
                lesTypes = db.Types.ToList(),
                lesDepartements = db.Departements.ToList()
            };



            return View(model);
        }

        public ActionResult AddConfirm(string nom, string poids, string couleur, string tatouage, string puce, int race, int departement, string rue, string cp, string ville, HttpPostedFileBase upload)
        {

            Animaux animal = new Animaux();
            animal.Nom = nom;
            animal.Poids = poids;
            animal.Couleur = couleur;
            animal.Tatouage = tatouage;
            animal.Puce = puce;
            animal.Race = db.Races.Find(race);
            animal.PhotoPrincipale = upload.FileName;
            animal.Departement = db.Departements.Find(departement);
            animal.Rue = rue;
            animal.CodePostal = cp;
            animal.Ville = ville;
            animal.StatutAnimal = db.StatutAnimal.Find(1);

            if (Session["idConnecte"] != null)
            {
                animal.Compte = db.Comptes.Find(Session["idConnecte"]);
            }
            else {
                animal.Compte = db.Comptes.Find(7);
            }

            db.Animaux.Add(animal);
            db.SaveChanges();


            if (upload != null && upload.ContentLength > 0)
            {

                string RootFolder = @Server.MapPath("~/content/img");
                string path = Path.Combine(RootFolder, upload.FileName);
                upload.SaveAs(path);
            }


            return RedirectToAction("Index", "Animaux", new { id = animal.Id });
        }



        public ActionResult Edit(int id)
        {

            var model = new ViewModelAnimauxEdit()
            {
                lesRaces = db.Races.ToList(),
                lesTypes = db.Types.ToList(),
                lesDepartements = db.Departements.ToList(),
                animal = db.Animaux.Find(id),
                LesStatutsAnimaux = db.StatutAnimal.ToList()
            };

            return View(model);
        }

        public ActionResult EditConfirm(int id, int statutAnimal, string nom, string poids, string couleur, string tatouage, string puce, int race, int departement, string rue, string cp, string ville) {

            Animaux animal = db.Animaux.Find(id);
            animal.Nom = nom;
            animal.Poids = poids;
            animal.Couleur = couleur;
            animal.Tatouage = tatouage;
            animal.Puce = puce;
            animal.Race = db.Races.Find(race);
            animal.Departement = db.Departements.Find(departement);
            animal.Rue = rue;
            animal.CodePostal = cp;
            animal.Ville = ville;
            animal.StatutAnimal = db.StatutAnimal.Find(statutAnimal);


            if (Session["idConnecte"] != null) {
                animal.Compte = db.Comptes.Find(Session["idConnecte"]);
            }
            else {
                animal.Compte = db.Comptes.Find(7);
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Animaux", new { id = animal.Id });
        }
    }
}