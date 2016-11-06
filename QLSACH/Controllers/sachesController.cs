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
    public class sachesController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: saches
        public ActionResult Index()
        {
            var saches = db.saches.Include(s => s.linhvuc1);
            return View(saches.ToList());
        }

        // GET: saches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = db.saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: saches/Create
        public ActionResult Create()
        {
            ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv");
            return View();
        }

        // POST: saches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masach,tensach,linhvuc,sluong,gia")] sach sach)
        {
            if (ModelState.IsValid)
            {
                db.saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv", sach.linhvuc);
            return View(sach);
        }

        // GET: saches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = db.saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv", sach.linhvuc);
            return View(sach);
        }

        // POST: saches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masach,tensach,linhvuc,sluong,gia")] sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv", sach.linhvuc);
            return View(sach);
        }

        // GET: saches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sach sach = db.saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sach sach = db.saches.Find(id);
            db.saches.Remove(sach);
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
