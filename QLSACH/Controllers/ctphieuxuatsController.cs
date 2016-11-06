using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSACH.Models;

namespace QLSACH.Controllers
{
    public class ctphieuxuatsController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: ctphieuxuats
        public ActionResult Index()
        {
            var ctphieuxuats = db.ctphieuxuats.Include(c => c.phieuxuat).Include(c => c.sach);
            return View(ctphieuxuats.ToList());
        }

        // GET: ctphieuxuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctphieuxuat ctphieuxuat = db.ctphieuxuats.Find(id);
            if (ctphieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(ctphieuxuat);
        }

        // GET: ctphieuxuats/Create
        public ActionResult Create()
        {
            ViewBag.maso = new SelectList(db.phieuxuats, "maso", "madl");
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach");
            return View();
        }

        // POST: ctphieuxuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maso,masach,soluong,gia,thanhtien")] ctphieuxuat ctphieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.ctphieuxuats.Add(ctphieuxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maso = new SelectList(db.phieuxuats, "maso", "madl", ctphieuxuat.maso);
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach", ctphieuxuat.masach);
            return View(ctphieuxuat);
        }

        // GET: ctphieuxuats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctphieuxuat ctphieuxuat = db.ctphieuxuats.Find(id);
            if (ctphieuxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.maso = new SelectList(db.phieuxuats, "maso", "madl", ctphieuxuat.maso);
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach", ctphieuxuat.masach);
            return View(ctphieuxuat);
        }

        // POST: ctphieuxuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maso,masach,soluong,gia,thanhtien")] ctphieuxuat ctphieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctphieuxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maso = new SelectList(db.phieuxuats, "maso", "madl", ctphieuxuat.maso);
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach", ctphieuxuat.masach);
            return View(ctphieuxuat);
        }

        // GET: ctphieuxuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctphieuxuat ctphieuxuat = db.ctphieuxuats.Find(id);
            if (ctphieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(ctphieuxuat);
        }

        // POST: ctphieuxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ctphieuxuat ctphieuxuat = db.ctphieuxuats.Find(id);
            db.ctphieuxuats.Remove(ctphieuxuat);
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
