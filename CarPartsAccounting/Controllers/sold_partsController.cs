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
    public class sold_partsController : Controller
    {
        private AutopartsShopEntities db = new AutopartsShopEntities();

        // GET: sold_parts
        public ActionResult Index(int? id)
        {
            var sold_parts = db.sold_parts.Where(sp => sp.selling_id == id);

            return View(sold_parts);
        }

        // GET: sold_parts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sold_parts sold_parts = db.sold_parts.Find(id);
            if (sold_parts == null)
            {
                return HttpNotFound();
            }
            return View(sold_parts);
        }

        // GET: sold_parts/Create
        public ActionResult Create()
        {
            ViewBag.selling_id = new SelectList(db.accounting, "id", "id");
            ViewBag.part_id = new SelectList(db.parts, "id", "part_name");

            return View();
        }

        // POST: sold_parts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "selling_id,part_id,id,quantity")] sold_parts sold_parts)
        {
            if (ModelState.IsValid)
            {
                db.sold_parts.Add(sold_parts);
                db.SaveChanges();
                return RedirectToAction("Index", "accountings");
            }

            ViewBag.selling_id = new SelectList(db.accounting, "id", "id", sold_parts.selling_id);
            ViewBag.part_id = new SelectList(db.parts, "id", "part_name", sold_parts.part_id);
            return View(sold_parts);
        }

        // GET: sold_parts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sold_parts sold_parts = db.sold_parts.Find(id);
            if (sold_parts == null)
            {
                return HttpNotFound();
            }
            ViewBag.selling_id = new SelectList(db.accounting, "id", "id", sold_parts.selling_id);
            ViewBag.part_id = new SelectList(db.parts, "id", "part_name", sold_parts.part_id);
            return View(sold_parts);
        }

        // POST: sold_parts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "selling_id,part_id,id,quantity")] sold_parts sold_parts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sold_parts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.selling_id = new SelectList(db.accounting, "id", "id", sold_parts.selling_id);
            ViewBag.part_id = new SelectList(db.parts, "id", "part_name", sold_parts.part_id);
            return View(sold_parts);
        }

        // GET: sold_parts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sold_parts sold_parts = db.sold_parts.Find(id);
            if (sold_parts == null)
            {
                return HttpNotFound();
            }
            return View(sold_parts);
        }

        // POST: sold_parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sold_parts sold_parts = db.sold_parts.Find(id);
            db.sold_parts.Remove(sold_parts);
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
