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
    public class partsController : Controller
    {
        private AutopartsShopEntities db = new AutopartsShopEntities();

        // GET: parts
        public ActionResult Index()
        {
            return View(db.parts.ToList());
        }

        // GET: parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parts parts = db.parts.Find(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // GET: parts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: parts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,part_name,country,firm,quantity,price")] parts parts)
        {
            if (ModelState.IsValid)
            {
                db.parts.Add(parts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parts);
        }

        // GET: parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parts parts = db.parts.Find(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // POST: parts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,part_name,country,firm,quantity,price")] parts parts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parts);
        }

        // GET: parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parts parts = db.parts.Find(id);
            if (parts == null)
            {
                return HttpNotFound();
            }
            return View(parts);
        }

        // POST: parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parts parts = db.parts.Find(id);
            db.parts.Remove(parts);
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
