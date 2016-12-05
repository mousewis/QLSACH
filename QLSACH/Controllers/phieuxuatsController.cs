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
    public class phieuxuatsController : Controller
    {
        private QLSACHEntities db = new QLSACHEntities();

        // GET: phieuxuats
        public ActionResult Index()
        {
            var phieuxuats = db.phieuxuats.Include(p => p.daily);
            return View(phieuxuats.ToList());
        }

        // GET: phieuxuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phieuxuat phieuxuat = db.phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            phieuxuatVM phieuxuatVM = new phieuxuatVM();
            phieuxuatVM.phieuxuat = phieuxuat;
            var ctphieuxuats = db.ctphieuxuats.Include(p => p.phieuxuat).Where(s => s.maso == id);
            phieuxuatVM.ctphieuxuat = ctphieuxuats.ToList();
            phieuxuatVM.daily = db.dailies.Find(phieuxuatVM.phieuxuat.madl);
            return View(phieuxuatVM);
        }

        // GET: phieuxuats/Create
        
        // POST: phieuxuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        // GET: phieuxuats/Edit/5
        
    }
}
