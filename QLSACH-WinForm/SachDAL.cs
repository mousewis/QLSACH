using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace QLSACH_WinForm
{
    class SachDAL
    {
        protected static QLSACHEntities db = new QLSACHEntities();
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
    }
}
