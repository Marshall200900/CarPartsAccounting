using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarPartsAccounting.Models;

namespace CarPartsAccounting.Controllers
{
    public class workersController : Controller
    {
        private AutopartsShopEntities db = new AutopartsShopEntities();

        // GET: workers
        public ActionResult Index()
        {
            return View(db.workers.ToList());
        }

        // GET: workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workers workers = db.workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // GET: workers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: workers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,worker_name,position,phone_number")] workers workers)
        {
            if (ModelState.IsValid)
            {
                db.workers.Add(workers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workers);
        }

        // GET: workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workers workers = db.workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: workers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,worker_name,position,phone_number")] workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workers);
        }

        // GET: workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            workers workers = db.workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            workers workers = db.workers.Find(id);
            db.workers.Remove(workers);
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
