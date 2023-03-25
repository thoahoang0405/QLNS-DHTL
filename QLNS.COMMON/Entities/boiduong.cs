using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("boiduong")]
    public class boiduong
    {
        public Guid IDBoiDuong { get; set; }
        public Guid IDNhanVien { get; set; }
        public  string NoiDungBoiDuong { get; set; }
         public string DiaDiem { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime  ThoiGianKetThuc { get;set; }
         public string CoSo { get; set; }
          public  string  VanBangChungChi { get; set; }
    }
}
