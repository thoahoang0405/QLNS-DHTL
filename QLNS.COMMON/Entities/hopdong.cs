using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    public class hopdong
    {
         public Guid IDHopDong { get; set; }
         public Guid IDNhanVien { get; set; }
        public string TenHD { get; set; } 
         public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        public DateTime NgayKi { get;set; }
        public string MoTa { get; set; }
    }
}
