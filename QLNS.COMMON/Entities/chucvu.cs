using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("chucvu")]
    public class chucvu
    {
       public Guid IDChucVu { get; set; }
        public Guid IDNhanVien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string TenChucVu { get; set; }
      public string  DinhMucGiangDay { get; set; }
    }
}
