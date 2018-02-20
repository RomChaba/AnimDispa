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
    public class ComptesController : Controller
    {
        private AnimDispaContext db = new AnimDispaContext();

        // GET: Comptes
        public ActionResult Index()
        {
            return View(db.Comptes.ToList());
        }

        // GET: Comptes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comptes comptes = db.Comptes.Find(id);
            if (comptes == null)
            {
                return HttpNotFound();
            }
            return View(comptes);
        }

        // GET: Comptes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comptes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Login,Password,Mail,Tel,Adresse,CodePostal,Ville")] Comptes comptes)
        {
            if (ModelState.IsValid)
            {
                comptes.idRoles = 2;
                comptes.idStatutsComptes = 1;
                db.Comptes.Add(comptes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comptes);
        }

        // GET: Comptes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comptes comptes = db.Comptes.Find(id);

            List<SelectListItem> Stat = new List<SelectListItem>();
            foreach (var item in db.StatutsComptes.ToList())
            {
                Stat.Add(new SelectListItem() { Text = item.Libelle, Value = item.Id.ToString() });
            }
            ViewData["idStatutsComptes"] = Stat;

            List<SelectListItem> Rol = new List<SelectListItem>();
            foreach (var item in db.Roles.ToList())
            {
                Rol.Add(new SelectListItem() { Text = item.Libelle, Value = item.Id.ToString() });
            }
            ViewData["idRoles"] = Rol;

            if (comptes == null)
            {
                return HttpNotFound();
            }
            return View(comptes);
        }

        // POST: Comptes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Login,Password,Mail,Tel,Adresse,CodePostal,Ville,idStatutsComptes,idRoles")] Comptes comptes)
        {
            if (ModelState.IsValid)
            {
                comptes.Role = db.Roles.Where(x => x.Id == comptes.idRoles).First();

                comptes.StatutCompte = db.StatutsComptes.Where(x => x.Id == comptes.idStatutsComptes).First();


                db.Entry(comptes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comptes);
        }

        // GET: Comptes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comptes comptes = db.Comptes.Find(id);
            if (comptes == null)
            {
                return HttpNotFound();
            }
            return View(comptes);
        }

        // POST: Comptes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comptes comptes = db.Comptes.Find(id);
            db.Comptes.Remove(comptes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Comptes/Connexion
        public ActionResult Connexion()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Connexion(string login,string password)
        {
            if (ModelState.IsValid)
            {
                List<Comptes> comp = null;
                comp = db.Comptes.Where(x=>x.Login == login).Where(x=>x.Password == password).ToList();

                if (comp.Count == 0)
                {
                    return View();

                }
                else
                {

                    var compteId = db.Comptes.Where(x => x.Login == login).Where(x => x.Password == password).First();
                    Session["IdConnecte"] = compteId.Id;
                    Session["compteRole"] = compteId.idRoles;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }

            return View();
        }
        public ActionResult Deconnexion(string login, string password)
        {
            Session["IdConnecte"] = null;
            Session["compteRole"] = null;
            return RedirectToAction("Index", "Home", new { area = "" });

        }
    }
}
