using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Thongke
    {
        [System.ComponentModel.DisplayName("Ngày Nhập")]
        public DateTime? ngnhap { get; set; }
        [System.ComponentModel.DisplayName("Số Lượng Nhập")]
        public int? ctphieunhap { get; set; }
        [System.ComponentModel.DisplayName("Ngày Xuất")]
        public DateTime? ngxuat { get; set; }
        [System.ComponentModel.DisplayName("Số Lượng Xuất")]
        public int? ctphieuxuat { get; set; }
        [System.ComponentModel.DisplayName("Tồn kho trong ngày")]
        public int sluong { get; set; }
    }
}
