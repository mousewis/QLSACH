using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class phieuxuatVM
    {
        [Key]
        public phieuxuat phieuxuat { get; set; }
        public daily daily { get; set; }
        public List<ctphieuxuat> ctphieuxuat { get; set; }

    }
}