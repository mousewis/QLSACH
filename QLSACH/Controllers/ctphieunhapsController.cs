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
    public class ctphieunhapsController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: ctphieunhaps
        public ActionResult Index()
        {
            var ctphieunhaps = db.ctphieunhaps.Include(c => c.phieunhap).Include(c => c.sach);
            return View(ctphieunhaps.ToList());
        }

        // GET: ctphieunhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctphieunhap ctphieunhap = db.ctphieunhaps.Find(id);
            if (ctphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(ctphieunhap);
        }

        // GET: ctphieunhaps/Create
        public ActionResult Create()
        {
            ViewBag.maso = new SelectList(db.phieunhaps, "maso", "maso");
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach");
            return View();
        }

        // POST: ctphieunhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maso,masach,soluong,gia,thanhtien")] ctphieunhap ctphieunhap)
        {
            if (ModelState.IsValid)
            {
                db.ctphieunhaps.Add(ctphieunhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maso = new SelectList(db.phieunhaps, "maso", "manxb", ctphieunhap.maso);
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach", ctphieunhap.masach);
            return View(ctphieunhap);
        }

        // GET: ctphieunhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctphieunhap ctphieunhap = db.ctphieunhaps.Find(id);
            if (ctphieunhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.maso = new SelectList(db.phieunhaps, "maso", "manxb", ctphieunhap.maso);
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach", ctphieunhap.masach);
            return View(ctphieunhap);
        }

        // POST: ctphieunhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maso,masach,soluong,gia,thanhtien")] ctphieunhap ctphieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctphieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maso = new SelectList(db.phieunhaps, "maso", "manxb", ctphieunhap.maso);
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach", ctphieunhap.masach);
            return View(ctphieunhap);
        }

        // GET: ctphieunhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctphieunhap ctphieunhap = db.ctphieunhaps.Find(id);
            if (ctphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(ctphieunhap);
        }

        // POST: ctphieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ctphieunhap ctphieunhap = db.ctphieunhaps.Find(id);
            db.ctphieunhaps.Remove(ctphieunhap);
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
