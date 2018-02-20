using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnimDispa.Models;
using System.Web.Mvc;

namespace AnimDispa.Controllers
{
    public class AdminController : Controller {

        private AnimDispaContext db = new AnimDispaContext();
        
        public ActionResult Index() {
            return View();
        }
    }
}