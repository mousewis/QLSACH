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
    public class phieunhapsController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: phieunhaps
        public ActionResult Index()
        {
            var phieunhaps = db.phieunhaps.Include(p => p.nxb);
            return View(phieunhaps.ToList());
        }

        // GET: phieunhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieunhap phieunhap = db.phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // GET: phieunhaps/Create
        public ActionResult Create()
        {
            ViewBag.maso = DateTime.Now.ToString("yyyyMMddhhmm");
            ViewBag.manxb = new SelectList(db.nxbs, "manxb", "tennxb");
            return View();
        }

        // POST: phieunhaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maso,manxb,nguoigiao,tgian,tongtien")] phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                
                db.phieunhaps.Add(phieunhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.manxb = new SelectList(db.nxbs, "manxb", "tennxb", phieunhap.manxb);
            return View(phieunhap);
        }

        // GET: phieunhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieunhap phieunhap = db.phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.manxb = new SelectList(db.nxbs, "manxb", "tennxb", phieunhap.manxb);
            return View(phieunhap);
        }

        // POST: phieunhaps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maso,manxb,nguoigiao,tgian,tongtien")] phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.manxb = new SelectList(db.nxbs, "manxb", "tennxb", phieunhap.manxb);
            return View(phieunhap);
        }

        // GET: phieunhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieunhap phieunhap = db.phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // POST: phieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            phieunhap phieunhap = db.phieunhaps.Find(id);
            db.phieunhaps.Remove(phieunhap);
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
