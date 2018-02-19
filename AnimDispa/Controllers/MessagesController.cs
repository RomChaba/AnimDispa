using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class MessagesController : Controller {

        private AnimDispaContext db = new AnimDispaContext();
        
        public ActionResult Create(int id, String description) {

            Messages msg = new Messages();
            msg.Libelle = description;
            msg.IdAnimaux = id;
            msg.Animal = db.Animaux.Find(id);
            msg.Date = DateTime.Now;
            msg.IdComptes = 1;
            msg.Compte = db.Comptes.Find(1);

            db.Messages.Add(msg);
            db.SaveChanges();
            
            return RedirectToAction("Index", "Animaux", new { id = id });
        }
    }
}