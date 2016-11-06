using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace QLSACH.Controllers
{
    public class dailiesController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: dailies
        public ActionResult Index()
        {
            return View(db.dailies.ToList());
        }

        // GET: dailies/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    daily daily = db.dailies.Find(id);
        //    if (daily == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(daily);
        //}

        //// GET: dailies/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: dailies/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "madl,tendl,dchi,sdt,tonkho")] daily daily)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.dailies.Add(daily);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(daily);
        //}

        //// GET: dailies/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    daily daily = db.dailies.Find(id);
        //    if (daily == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(daily);
        //}

        //// POST: dailies/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "madl,tendl,dchi,sdt,tonkho")] daily daily)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(daily).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(daily);
        //}

        //// GET: dailies/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    daily daily = db.dailies.Find(id);
        //    if (daily == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(daily);
        //}

        //// POST: dailies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    daily daily = db.dailies.Find(id);
        //    db.dailies.Remove(daily);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
