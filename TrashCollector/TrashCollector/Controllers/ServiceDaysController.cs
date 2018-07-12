using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class ServiceDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceDays
        public async Task<ActionResult> Index()
        {
            var serviceDays = db.ServiceDays.Include(s => s.ServiceAddress);
            return View(await serviceDays.ToListAsync());
        }

        // GET: ServiceDays/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDay serviceDay = await db.ServiceDays.FindAsync(id);
            if (serviceDay == null)
            {
                return HttpNotFound();
            }
            return View(serviceDay);
        }

        // GET: ServiceDays/Create
        public ActionResult Create()
        {
            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1");
            return View();
        }

        // POST: ServiceDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServiceDayID,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Frequency,BeginDate,EndDate,ServiceAddressID")] ServiceDay serviceDay)
        {
            if (ModelState.IsValid)
            {
                db.ServiceDays.Add(serviceDay);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1", serviceDay.ServiceAddressID);
            return View(serviceDay);
        }

        // GET: ServiceDays/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDay serviceDay = await db.ServiceDays.FindAsync(id);
            if (serviceDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1", serviceDay.ServiceAddressID);
            return View(serviceDay);
        }

        // POST: ServiceDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServiceDayID,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Frequency,BeginDate,EndDate,ServiceAddressID")] ServiceDay serviceDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceDay).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceAddressID = new SelectList(db.ServiceAddresses, "ServiceAddressID", "Address1", serviceDay.ServiceAddressID);
            return View(serviceDay);
        }

        // GET: ServiceDays/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceDay serviceDay = await db.ServiceDays.FindAsync(id);
            if (serviceDay == null)
            {
                return HttpNotFound();
            }
            return View(serviceDay);
        }

        // POST: ServiceDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiceDay serviceDay = await db.ServiceDays.FindAsync(id);
            db.ServiceDays.Remove(serviceDay);
            await db.SaveChangesAsync();
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
