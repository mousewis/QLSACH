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
    public class linhvucsController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: linhvucs
        public ActionResult Index()
        {
            return View(db.linhvucs.ToList());
        }

        // GET: linhvucs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            linhvuc linhvuc = db.linhvucs.Find(id);
            if (linhvuc == null)
            {
                return HttpNotFound();
            }
            return View(linhvuc);
        }

        // GET: linhvucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: linhvucs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "malv,tenlv")] linhvuc linhvuc)
        {
            if (ModelState.IsValid)
            {
                db.linhvucs.Add(linhvuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(linhvuc);
        }

        // GET: linhvucs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            linhvuc linhvuc = db.linhvucs.Find(id);
            if (linhvuc == null)
            {
                return HttpNotFound();
            }
            return View(linhvuc);
        }

        // POST: linhvucs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "malv,tenlv")] linhvuc linhvuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhvuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(linhvuc);
        }

        // GET: linhvucs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            linhvuc linhvuc = db.linhvucs.Find(id);
            if (linhvuc == null)
            {
                return HttpNotFound();
            }
            return View(linhvuc);
        }

        // POST: linhvucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            linhvuc linhvuc = db.linhvucs.Find(id);
            db.linhvucs.Remove(linhvuc);
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
