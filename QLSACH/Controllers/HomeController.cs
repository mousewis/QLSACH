using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
///using QLSACH.Models;
using Models;
using System.Data.SqlClient;

namespace QLSACH.Controllers
{
    public class HomeController : Controller
    {

        private QLSACHEntities db = new QLSACHEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Phieunhap()
        {
            ViewBag.maso = DateTime.Now.ToString("yyyMMddhhmm");
            ViewBag.tgian = DateTime.Now.ToShortDateString();
            ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv");
            ViewBag.masach = new SelectList(db.saches, "masach", "tensach");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Phieunhap(phieunhapVM p)
        {
            try
            {
                if (string.IsNullOrEmpty(p.phieunhap.nguoigiao.Trim()))
                    ModelState.AddModelError("phieunhap.nguoigiao", "Người giao không được để trống");
                if (string.IsNullOrEmpty(p.nxb.manxb.Trim()))
                    ModelState.AddModelError("nxb.manxb", "Mã nhà xuất bản không được để trống");
                if (string.IsNullOrEmpty(p.nxb.tennxb.Trim()))
                    ModelState.AddModelError("nxb.tennxb", "Tên nhà xuất bản không được để trống");
                if (string.IsNullOrEmpty(p.nxb.sdt.Trim()))
                    ModelState.AddModelError("nxb.sdt", "Số điện thoại không được để trống");
                if (string.IsNullOrEmpty(p.nxb.dchi.Trim()))
                    ModelState.AddModelError("nxb.dchi", "Địa chỉ không được để trống");
                if ((p.ctphieunhap == null))
                    ModelState.AddModelError("ctphieunhap", "Không có dữ liệu để nhập");
                if (ModelState.IsValid)
                {
                    ///nxb
                    nxb _nxb = db.nxbs.FirstOrDefault<nxb>(nxb => nxb.manxb == p.nxb.manxb.Trim());
                    if (_nxb == null)
                    {
                        _nxb = new nxb { manxb = p.nxb.manxb.Trim(), tennxb = p.nxb.tennxb.Trim(), sdt = p.nxb.sdt.Trim(), dchi = p.nxb.dchi.Trim(), tonkho = p.nxb.tonkho };
                        db.nxbs.Add(_nxb);
                    }
                    else
                    {
                        _nxb.tennxb = p.nxb.tennxb.Trim();
                        _nxb.sdt = p.nxb.sdt.Trim();
                        _nxb.dchi = p.nxb.dchi.Trim();
                        _nxb.tonkho = p.nxb.tonkho + _nxb.tonkho ;
                        db.Entry(_nxb).State = System.Data.Entity.EntityState.Modified;
                    }
                    ////sach
                    //foreach (var i in p.sach)
                    //    {
                    //        sach _sach = db.saches.Find(i.masach);
                    //        if (_sach != null)
                    //        //{
                    //            //_sach = new sach { masach = i.masach, tensach = i.tensach, linhvuc = i.linhvuc, sluong = i.sluong };
                    //            //db.saches.Add(_sach);
                    //        //}
                    //        //else
                    //        {
                    //            _sach = new sach { masach = i.masach, tensach = i.tensach, linhvuc = i.linhvuc, sluong = i.sluong + _sach.sluong };
                    //            db.Entry(_sach).State = System.Data.Entity.EntityState.Modified;
                    //        }
                    //    }
                    
                    ///phieunhap
                    phieunhap _phieunhap = new phieunhap { maso = p.phieunhap.maso.Trim(), manxb = p.phieunhap.manxb.Trim(), nguoigiao = p.phieunhap.nguoigiao.Trim(), tgian = p.phieunhap.tgian, tongtien = p.phieunhap.tongtien };
                    db.phieunhaps.Add(_phieunhap);
                        foreach (var j in p.ctphieunhap)
                        {
                            j.tienno = j.thanhtien;
                            db.ctphieunhaps.Add(j);
                            sach _sach = db.saches.FirstOrDefault<sach>(sach => sach.masach == j.masach.Trim());
                            _sach.sluong = j.soluong + _sach.sluong ;
                            db.Entry(_sach).State = System.Data.Entity.EntityState.Modified;
                        }
                    db.SaveChanges();
                    return RedirectToAction("Success");
                }
                ViewBag.maso = DateTime.Now.ToString("yyyMMddhhmm");
                ViewBag.tgian = DateTime.Now.ToShortDateString();
                ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv");
                ViewBag.masach = new SelectList(db.saches, "masach", "tensach");
                return View(p);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }
            
        }
        ////Phieu xuat
        public ActionResult Phieuxuat()
        {
            ViewBag.maso = DateTime.Now.ToString("yyyMMddhhmm");
            ViewBag.tgian = DateTime.Now.ToShortDateString();
            ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv");
            //ViewBag.masach = new SelectList(db.saches, "masach", "tensach");
            ViewBag.masach = from ct in db.ctphieunhaps
                             join s in db.saches on ct.masach equals s.masach
                             select new SelectListItem
                             {
                                 Text = s.tensach + "|" + ct.maso,
                                 Value = ct.masach + "|" + ct.maso + "|" + ct.gia
                             }; 
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Phieuxuat(phieuxuatVM p)
        {
            try
            {
                if (string.IsNullOrEmpty(p.phieuxuat.nguoinhan.Trim()))
                    ModelState.AddModelError("phieuxuat.nguoinhan", "Người nhận không được để trống");
                if (string.IsNullOrEmpty(p.daily.madl.Trim()))
                    ModelState.AddModelError("daily.madl", "Mã đại lý không được để trống");
                if (string.IsNullOrEmpty(p.daily.tendl.Trim()))
                    ModelState.AddModelError("daily.tendl", "Tên đại lý không được để trống");
                if (string.IsNullOrEmpty(p.daily.sdt.Trim()))
                    ModelState.AddModelError("daily.sdt", "Số điện thoại không được để trống");
                if (string.IsNullOrEmpty(p.daily.dchi.Trim()))
                    ModelState.AddModelError("daily.dchi", "Địa chỉ không được để trống");
                if (p.ctphieuxuat == null)
                    ModelState.AddModelError("ctphieuxuat", "Không có dữ liệu để nhập");
                if (ModelState.IsValid)
                {
                    ///daily
                    daily _daily = db.dailies.FirstOrDefault<daily>(daily => daily.madl == p.daily.madl.Trim());
                    if (_daily == null)
                    {
                        _daily = new daily { madl = p.daily.madl.Trim(), tendl = p.daily.tendl.Trim(), sdt = p.daily.sdt.Trim(), dchi = p.daily.dchi.Trim(), tonkho = p.daily.tonkho };
                        db.dailies.Add(_daily);
                    }
                    else
                    {
                        _daily.tendl = p.daily.tendl.Trim();
                        _daily.sdt = p.daily.sdt.Trim();
                        _daily.dchi = p.daily.dchi.Trim();
                        _daily.tonkho = p.daily.tonkho + _daily.tonkho;
                        db.Entry(_daily).State = System.Data.Entity.EntityState.Modified;
                    }
                    ///phieuxuat
                    phieuxuat _phieuxuat = new phieuxuat { maso = p.phieuxuat.maso.Trim(), madl = p.phieuxuat.madl.Trim(), nguoinhan = p.phieuxuat.nguoinhan.Trim(), tgian = p.phieuxuat.tgian, tongtien = p.phieuxuat.tongtien };
                    db.phieuxuats.Add(_phieuxuat);
                    foreach (var j in p.ctphieuxuat)
                    {
                        j.tienno = j.thanhtien;
                        db.ctphieuxuats.Add(j);
                        sach _sach = db.saches.FirstOrDefault<sach>(sach=>sach.masach==j.masach);
                        _sach.sluong = _sach.sluong - j.soluong; 
                         db.Entry(_sach).State = System.Data.Entity.EntityState.Modified;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Success");
                }
                ViewBag.maso = DateTime.Now.ToString("yyyMMddhhmm");
                ViewBag.tgian = DateTime.Now.ToShortDateString();
                ViewBag.linhvuc = new SelectList(db.linhvucs, "malv", "tenlv");
                ViewBag.masach = from ct in db.ctphieunhaps
                                 join s in db.saches on ct.masach equals s.masach
                                 select new SelectListItem
                                 {
                                     Text = s.tensach + "|" + ct.maso,
                                     Value = ct.masach + "|" + ct.maso + "|" + ct.gia
                                 };
                return View(p);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }

        }
        /// Autocomplete nxb
        public JsonResult Nxbs(string manxb)
        {
            List<TimkiemNXB_Result> _nxbs = db.TimkiemNXB(manxb).ToList();
            String[] array_nxbs = new String[_nxbs.Count];
            for (int i = 0; i < _nxbs.Count; i++)
            {
                array_nxbs[i] = _nxbs[i].manxb.ToString().Trim() + "|" + _nxbs[i].tennxb.ToString().Trim() + "|"
                    + _nxbs[i].sdt.ToString().Trim() + "|" + _nxbs[i].dchi.ToString().Trim();
            }
            return Json(array_nxbs,JsonRequestBehavior.AllowGet);
        }
        /// Autocomplete Daily
        public JsonResult Dailies(string madl)
        {
            List<TimkiemDaily_Result> _dailies = db.TimkiemDaily(madl).ToList();
            String[] array_dailies = new String[_dailies.Count];
            for (int i = 0; i < _dailies.Count; i++)
            {
                array_dailies[i] = _dailies[i].madl.ToString().Trim() + "|" + _dailies[i].tendl.ToString().Trim() + "|"
                    + _dailies[i].sdt.ToString().Trim() + "|" + _dailies[i].dchi.ToString().Trim();
            }
            return Json(array_dailies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Sachs(string masach)
        {
            List<TimkiemSach_Result> _sachs = db.TimkiemSach(masach).ToList();
            String[] array_sachs = new String[_sachs.Count];
            for (int i = 0; i < _sachs.Count; i++)
            {
                array_sachs[i] = _sachs[i].masach.ToString().Trim() + "|" + _sachs[i].tensach.ToString().Trim() + "|"
                    + _sachs[i].linhvuc.ToString().Trim() + "|" + _sachs[i].sluong.ToString().Trim();
            }
            return Json(array_sachs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Sach_Max(string masach)
        {

            sach _sach = db.saches.Find(masach);
            string _sachs =  _sach.sluong.ToString().Trim();
            
            return Json(_sachs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Gia_Min(string masach, string maphieunhap)
        {
            ctphieunhap _cts = db.ctphieunhaps.Where(ct => (ct.masach == masach.Trim())&&(ct.maso == maphieunhap.Trim())).FirstOrDefault();
            return Json(_cts.gia, JsonRequestBehavior.AllowGet);
        }
        //Post action for Save data to database
        //[HttpPost]
        //public JsonResult Themphieunhap(phieunhapVM p)
        //{
        //    bool status = false;
        //    if (ModelState.IsValid)
        //    {
        //        using (db)
        //        {
        //            phieunhap pn = new phieunhap {maso = p._phieunhap.maso, manxb = p._phieunhap.manxb, nguoigiao = p._phieunhap.nguoigiao, tgian = p._phieunhap.tgian, tongtien = p._phieunhap.tongtien };
        //            foreach (var i in p.ctphieunhap)
        //            {
        //                //
        //                // i.TotalAmount = 
        //                p.ctphieunhap.Add(i);
        //            }
        //            db.phieunhaps.Add(pn);
        //            db.SaveChanges();
        //            status = true;
        //        }
        //    }
        //    else
        //    {
        //        status = false;
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}
        public ActionResult Success()
        {
            return View();
        }
    }
}