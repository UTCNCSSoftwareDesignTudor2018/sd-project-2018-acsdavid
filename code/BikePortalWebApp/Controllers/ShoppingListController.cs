using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikePortalWebApp.Controllers
{
    public class ShoppingListController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}