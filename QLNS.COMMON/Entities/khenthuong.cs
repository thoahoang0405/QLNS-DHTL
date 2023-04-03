using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("khenthuong")]
    public class khenthuong
    {
        [Key]
        public Guid IDKT { get; set; }
        public Guid? IDNhanVien { get; set; }
        public string? TenKT { get; set; }
        public DateTime? NgayKT { get; set; }
        public string? HinhThucKT { get; set; }
        public string? DiaDiemKT { get; set; }
        public string? LyDoKT { get; set; }
     
       
    }
}
