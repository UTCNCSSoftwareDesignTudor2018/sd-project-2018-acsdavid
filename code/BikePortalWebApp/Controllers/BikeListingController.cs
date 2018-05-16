using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikePortalWebApp.Controllers
{
    public class BikeListingController : Controller
    {
        // GET: BikeListing
        public ActionResult Index()
        {
            ViewBag.Title = "Bikes";

            return View();
        }

        public ActionResult AddBike()
        {
            return View();
        }

        // GET: BikeListing/5
        public ActionResult Details(int id)
        {
            ViewData.Model = id;
            return View();
        }
    }
}