using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;

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
            return View();
        }
    }
}