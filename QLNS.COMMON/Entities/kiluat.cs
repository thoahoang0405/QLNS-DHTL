using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("kyluat")]
    public class kiluat
    {
        public Guid IDKyLuat { get; set; }
        public Guid IDNhanVien { get; set; }
        public string? TenKL { get; set; }
        public string? HinhThucKL { get; set; }
        public string? LyDoKL { get; set; }
    
        public string? DiaDiemKL { get; set; }
        public DateTime? NgayKL { get; set; }


      
    }
}
