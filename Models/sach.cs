﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sach()
        {
            this.ctphieunhaps = new HashSet<ctphieunhap>();
            this.ctphieuxuats = new HashSet<ctphieuxuat>();
            this.cttkdls = new HashSet<cttkdl>();
        }
        [System.ComponentModel.DisplayName("Mã sách")]

        public string masach { get; set; }
        [System.ComponentModel.DisplayName("Tên Sách")]

        public string tensach { get; set; }
        [System.ComponentModel.DisplayName("Lĩnh Vực")]

        public string linhvuc { get; set; }
        [System.ComponentModel.DisplayName("Số lượng")]

        public int sluong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctphieunhap> ctphieunhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctphieuxuat> ctphieuxuats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cttkdl> cttkdls { get; set; }
        public virtual linhvuc linhvuc1 { get; set; }
    }
}
