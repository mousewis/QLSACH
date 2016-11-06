using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class phieunhapVM
    {
        [Key]
        public phieunhap phieunhap { get; set; }
        public nxb nxb { get; set; }
        public List<sach> sach { get; set; }
        public List<ctphieunhap> ctphieunhap { get; set; }

    }
}