using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class SpecialServiceDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpecialServiceDays
        public ActionResult Index()
        {
            var specialServiceDays = db.SpecialServiceDays.Include(s => s.ServiceAddress);
            return View(specialServiceDays.ToList());
        }

        // GET: SpecialServiceDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialServiceDay specialServiceDay = db.SpecialServiceDays.Find(id);
            if (specialServiceDay == null)
            {
                return HttpNotFound();
            }
            return View(specialServiceDay);
        }

        // GET: SpecialServiceDays/Create
        public ActionResult Create()
        {
            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1");
            return View();
        }

        // POST: SpecialServiceDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecialServiceDayID,Date,ServiceAddressID")] SpecialServiceDay specialServiceDay)
        {
            if (ModelState.IsValid)
            {
                db.SpecialServiceDays.Add(specialServiceDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1", specialServiceDay.ServiceAddressID);
            return View(specialServiceDay);
        }

        // GET: SpecialServiceDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialServiceDay specialServiceDay = db.SpecialServiceDays.Find(id);
            if (specialServiceDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1", specialServiceDay.ServiceAddressID);
            return View(specialServiceDay);
        }

        // POST: SpecialServiceDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecialServiceDayID,Date,ServiceAddressID")] SpecialServiceDay specialServiceDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialServiceDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1", specialServiceDay.ServiceAddressID);
            return View(specialServiceDay);
        }

        // GET: SpecialServiceDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialServiceDay specialServiceDay = db.SpecialServiceDays.Find(id);
            if (specialServiceDay == null)
            {
                return HttpNotFound();
            }
            return View(specialServiceDay);
        }

        // POST: SpecialServiceDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialServiceDay specialServiceDay = db.SpecialServiceDays.Find(id);
            db.SpecialServiceDays.Remove(specialServiceDay);
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
    }
}