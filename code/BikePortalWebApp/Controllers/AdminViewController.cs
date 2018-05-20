using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikePortalWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminViewController : Controller
    {
        // GET: AdminView
        public ActionResult Index()
        {
            return View();
        }
    }
}