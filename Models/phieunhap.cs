//------------------------------------------------------------------------------
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
    
    public partial class phieunhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phieunhap()
        {
            this.ctphieunhaps = new HashSet<ctphieunhap>();
        }
    
        public string maso { get; set; }
        public string manxb { get; set; }
        public string nguoigiao { get; set; }
        public System.DateTime tgian { get; set; }
        public int tongtien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctphieunhap> ctphieunhaps { get; set; }
        public virtual nxb nxb { get; set; }
    }
}
