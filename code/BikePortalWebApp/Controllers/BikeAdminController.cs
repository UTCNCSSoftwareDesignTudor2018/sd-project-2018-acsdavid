using System.Net;
using System.Web.Mvc;
using BikePortal.Business.Entity;
using BikePortal.Business.Process;
using Unity;

namespace BikePortalWebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class BikeAdminController : Controller
    {
        private readonly IBikeBll _bikeBll;

        public BikeAdminController(IBikeBll bikeBll)
        {
            _bikeBll = bikeBll;
        }

        // GET: Bikes
        public ActionResult Index()
        {
            return View(_bikeBll.GetAll());
        }

        // GET: Bikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bike = _bikeBll.Get(id.Value);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bike = _bikeBll.Get(id.Value);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Model")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                _bikeBll.Update(bike);
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bike = _bikeBll.Get(id.Value);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var bike = _bikeBll.Get(id);
            _bikeBll.Delete(bike);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
