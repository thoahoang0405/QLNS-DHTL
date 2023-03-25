using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("hoatdong")]
    public class hoatdong
    {
     public Guid  IDHoatDong { get; set; }
     public Guid IDNhanVien { get; set; }
    public string TinhTrangDoanVien { get; set; }
    public DateTime NgayVaoDoan { get; set; }
    public string TinhTrangDangVien { get; set; } 
    public DateTime NgayVaoDang { get; set; }
    public string TinhTrangNhapNgu { get; set; }
    public string CoCongCachMang { get; set; }
    }
}
