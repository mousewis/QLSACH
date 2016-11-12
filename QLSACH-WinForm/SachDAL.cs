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

namespace QLSACH_WinForm
{
    class SachDAL
    {
        protected static QLSACHEntities db = new QLSACHEntities();
        //public static void LoadAll()
        //{
        //    db.saches.Load();
        //}
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
            while(i<a || j<b)
            {
                if (datenhap[i] > to || datexuat[j] > to && !to.Equals(""))
                    break;
                Thongke t = new Thongke();
                    if(datenhap[i] > datexuat[j])
                    {
                        t.ngnhap = datenhap[i];
                        t.ctphieunhap = soluongnhap[i];
                        i++;
                    }
                    else
                    {
                    if (datenhap[i] < datexuat[j])
                    {
                        t.ngxuat = datexuat[j];
                        t.ctphieuxuat = soluongxuat[j];
                        j++;
                    }
                    else
                    {
                        t.ngnhap = datenhap[i];
                        t.ctphieunhap = soluongnhap[i];
                        t.ngxuat = datexuat[j];
                        t.ctphieuxuat = soluongxuat[j];
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
                    t.sluong = db.saches.Find(id).sluong - sum;
                thongke.Add(t);
            
            return thongke;
        }
        public static void Search_Sach(string searchstring)
        {
            var sach = db.TimkiemSach(searchstring);
        }
       
    }
}
