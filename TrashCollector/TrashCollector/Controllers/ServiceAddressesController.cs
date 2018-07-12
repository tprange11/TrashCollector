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
    public class ServiceAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ServiceAddresses
        public async Task<ActionResult> Index()
        {
            var serviceAddresses = db.ServiceAddresses.Include(s => s.Customer).Include(s => s.State);
            return View(await serviceAddresses.ToListAsync());
        }

        // GET: ServiceAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceAddress serviceAddress = await db.ServiceAddresses.FindAsync(id);
            if (serviceAddress == null)
            {
                return HttpNotFound();
            }
            return View(serviceAddress);
        }

        // GET: ServiceAddresses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name");
            return View();
        }

        // POST: ServiceAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ServiceAddressID,Address1,Address2,City,StateID,ZipCode,CustomerID")] ServiceAddress serviceAddress)
        {
            if (ModelState.IsValid)
            {
                db.ServiceAddresses.Add(serviceAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", serviceAddress.CustomerID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", serviceAddress.StateID);
            return View(serviceAddress);
        }

        // GET: ServiceAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceAddress serviceAddress = await db.ServiceAddresses.FindAsync(id);
            if (serviceAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", serviceAddress.CustomerID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", serviceAddress.StateID);
            return View(serviceAddress);
        }

        // POST: ServiceAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ServiceAddressID,Address1,Address2,City,StateID,ZipCode,CustomerID")] ServiceAddress serviceAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", serviceAddress.CustomerID);
            ViewBag.StateID = new SelectList(db.States, "StateID", "Name", serviceAddress.StateID);
            return View(serviceAddress);
        }

        // GET: ServiceAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceAddress serviceAddress = await db.ServiceAddresses.FindAsync(id);
            if (serviceAddress == null)
            {
                return HttpNotFound();
            }
            return View(serviceAddress);
        }

        // POST: ServiceAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ServiceAddress serviceAddress = await db.ServiceAddresses.FindAsync(id);
            db.ServiceAddresses.Remove(serviceAddress);
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
