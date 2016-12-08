using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Text.RegularExpressions;
using System.Data.Entity;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;

namespace QLSACH_WinForm
{
    class SachDAL
    {
        protected static QLSACHEntities db = new QLSACHEntities();
        public static string TenSach(string id)
        {
            return db.linhvucs.Find(id).tenlv;
        }
        public static BindingList<sach> LoadAll()
        {
            BindingList<sach> sach = new BindingList<Models.sach>(db.saches.OrderBy(s=>s.masach).ToList());
            return sach;
        }
        public static BindingList<sach> LoadAll(QLSACHEntities db)
        {
            db = new QLSACHEntities();
            db.saches.Load();
            BindingList<sach> sach = new BindingList<Models.sach>(db.saches.OrderBy(s => s.masach).ToList());
            return sach;
        }
        public static List<nxb> LoadNXB()
        {
            db.nxbs.Load();
            return db.nxbs.Local.ToList();
        }
        public static List<daily> LoadDL()
        {
            db.dailies.Load();
            return db.dailies.Local.ToList();
        }
        public static BindingList<sach> Search_Sach(string searchstring)
        {
            BindingList<sach> sach = new BindingList<Models.sach>(db.saches.Where(s => s.tensach.Contains(searchstring)).OrderBy(s=>s.masach).ToList());
            return sach;
        }
        public static BindingList<sach> Search_Sach(string searchstring,QLSACHEntities db)
        {
            db = new QLSACHEntities();
            db.saches.Load();
            BindingList<sach> sach = new BindingList<Models.sach>(db.saches.Where(s => s.tensach.Contains(searchstring)).OrderBy(s => s.masach).ToList());
            return sach;
        }
        public static sach SearchID(string id)
        { return db.saches.Find(id); }
        public static void ADD_Sach(string masach,string tensach,string malinhvuc)
        {
            sach addsach = new sach();
            addsach.masach = masach;
            addsach.tensach = tensach;
            addsach.linhvuc = malinhvuc;
            addsach.sluong = 0;
            db.saches.Add(addsach);
            db.SaveChanges();
        }
        public static void DEL_Sach(string masach)
        {
            sach delsach = db.saches.Find(masach);
            db.saches.Remove(delsach);
            db.SaveChanges();
        }
        public static void Edit_Sach(string masach, string tensach, string malinhvuc)
        {
            var original = db.saches.Find(masach);
            if (original != null)
            {
                original.tensach = tensach;
                original.linhvuc = malinhvuc;
                db.SaveChanges();
            }
        }
        public static List<Thongke> Thongkekhoangthoigian(string id,DateTime from,DateTime to)
        {
            List<Thongke> thongke = new List<Thongke>();
            int[] soluongnhap = new int[100];
            DateTime[] datenhap = new DateTime[100];
            int a = 0;int sum = 0;
            foreach(var nhap in db.phieunhaps.Where(s=>s.tgian.Day >= from.Day).OrderBy(c=>c.tgian))
            {
                foreach (var ctn in db.ctphieunhaps.Where(c=>c.maso.Equals(nhap.maso)))
                {
                    if (ctn.masach.Equals(id))
                    {
                        sum += ctn.soluong;
                        if (datenhap.Contains(nhap.tgian))
                            soluongnhap[a] += ctn.soluong;
                        else
                        {
                            soluongnhap[a] = ctn.soluong;
                            datenhap[a] = nhap.tgian;
                            a++;
                        }
                    }
                }
            }
            int b = 0;
            int[] soluongxuat = new int[100];
            DateTime[] datexuat = new DateTime[100];
            foreach (var xuat in db.phieuxuats.Where(s => s.tgian.Day >= from.Day).OrderBy(c => c.tgian))
            {
                foreach (var ctx in db.ctphieuxuats.Where(c => c.maso.Equals(xuat.maso)))
                {
                    if (ctx.masach.Equals(id))
                    {
                        sum -= ctx.soluong;
                        if (datexuat.Contains(xuat.tgian))
                            soluongxuat[b] += ctx.soluong;
                        else
                        {
                            soluongxuat[b] = ctx.soluong;
                            datexuat[b] = xuat.tgian;
                            b++;
                        }
                    }
                }
            }
            int i = 0;
            int j = 0;
            int solg = db.saches.Find(id).sluong - sum;
            while (i<a || j<b)
            {
                if (datenhap[i] > to || datexuat[j] > to && !to.Equals(""))
                    break;
                Thongke t = new Thongke();
                    if(datenhap[i] > datexuat[j])
                    {
                        t.ngnhap = datenhap[i];
                        t.ctphieunhap = soluongnhap[i];
                        t.sluong = solg + soluongnhap[i];
                        solg += soluongnhap[i];
                        i++;
                    }
                    else
                    {
                    if (datenhap[i] < datexuat[j])
                    {
                        t.ngxuat = datexuat[j];
                        t.ctphieuxuat = soluongxuat[j];
                        t.sluong = solg - soluongxuat[j];
                        solg -= soluongxuat[j];
                        j++;
                    }
                    else
                    {
                        t.ngnhap = datenhap[i];
                        t.ctphieunhap = soluongnhap[i];
                        t.ngxuat = datexuat[j];
                        t.ctphieuxuat = soluongxuat[j];
                        t.sluong = solg + soluongnhap[i] - soluongxuat[j];
                        i++; j++;
                    }
                }
                thongke.Add(t);
              
            }
            return thongke;
        }
        public static List<Thongke> Thongketaithoidiem(string id, DateTime at)
        {
            List<Thongke> thongke = new List<Thongke>();
            int soluongnhap = 0;
            int sum = 0;
             foreach (var nhap in db.phieunhaps.Where(s => s.tgian.Day >= at.Day))
            {
                foreach (var ctn in db.ctphieunhaps.Where(c => c.maso.Equals(nhap.maso)))
                {
                    if (ctn.masach.Equals(id))
                    {
                        sum += ctn.soluong;
                        if (nhap.tgian.Day == at.Day)
                        {
                            soluongnhap += ctn.soluong;
                        }
                    }
                }
            }
            int b = 0;
            int soluongxuat = 0;
            foreach (var xuat in db.phieuxuats.Where(s => s.tgian.Day >= at.Day))
            {
                foreach (var ctx in db.ctphieuxuats.Where(c => c.maso.Equals(xuat.maso)))
                {
                    if (ctx.masach.Equals(id))
                    {
                        sum -= ctx.soluong;
                        if (xuat.tgian == at)
                        {
                            soluongxuat += ctx.soluong;
                        }
                    }
                }
            }
                Thongke t = new Thongke();
                    t.ctphieunhap = soluongnhap;
                    t.ngnhap = at;
                    t.ctphieuxuat = soluongxuat;
                    t.ngxuat = at;
                    t.sluong = db.saches.Find(id).sluong - sum + soluongnhap - soluongxuat;
                thongke.Add(t);
            
            return thongke;
        }
        public static List<ctphieuxuat> LoadNo(string id, int Year, int month)
        {
            db.ctphieuxuats.Load();
            List<ctphieuxuat> phieuxuat = new List<ctphieuxuat>();
                phieuxuat = db.ctphieuxuats.Where(s => s.phieuxuat.tgian.Year == Year && s.phieuxuat.tgian.Month == month && s.phieuxuat.madl.Equals(id)).ToList();
            return phieuxuat;
        }
        public static void UpdateNo(string id,string masach,int soluong)
        {
            ctphieuxuat original = db.ctphieuxuats.Where(s=>s.maso.Equals(id) && s.masach.Equals(masach)).Single();
            if(original != null)
            {
                original.tienno -= (soluong * original.gia);
                ctphieunhap ctnhap = db.ctphieunhaps.Where(s => s.maso.Equals(original.maphieunhap) && s.masach.Equals(original.masach)).SingleOrDefault();
                ctnhap.tienno -= (soluong * ctnhap.gia);
                db.SaveChanges();
            }
        }

    }
}
