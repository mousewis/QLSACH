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
        public static void Thong(string id,DateTime from,DateTime to)
        {
            List<Thongke> thongke = new List<Thongke>();
            int[] b = new int[100];
            DateTime[] date = new DateTime[100];
            int a = 0;
            foreach(var nhap in db.phieunhaps.Where(s=>s.tgian> from))
            {
                foreach (var ctn in db.ctphieunhaps.Where(c=>c.maso.Equals(nhap.maso)))
                {
                    if (ctn.masach.Equals("8934974135593"))
                    {
                        b[a] = ctn.soluong;
                        date[a] = nhap.tgian;
                        a++;
                    }
                }
            }
            //a = 0;
            //foreach (var nhap in db.phieuxuats.Where(s => s.tgian < from))
            //{
            //    foreach (var ctn in db.ctphieuxuats.Where(c => c.maso.Equals(nhap.maso)))
            //    {
            //        if (ctn.masach.Equals("8934974135593"))
            //        {
            //            thongke[a].ctphieuxuat = ctn.soluong;
            //            thongke[a].ngxuat = nhap.tgian;
            //            a++;
            //        }
            //    }
            //}
            for (int i = 0; i < a; i++)
            {
                Thongke t = new Thongke();
                t.ctphieunhap = b[i];
                t.ngnhap = date[i];
                thongke.Add(t);
            }
            foreach (var j in thongke)
                Debug.WriteLine(j.ngnhap + " " + j.ctphieunhap);
        }
    }
}
