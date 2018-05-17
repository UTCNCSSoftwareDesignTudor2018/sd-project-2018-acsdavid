using System.Web.Mvc;

namespace BikePortalWebApp.Controllers
{
    public class OrderListController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewData.Model = id;
            return View();
        }
    }
}