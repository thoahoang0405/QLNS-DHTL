using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("daotao")]
    public class daotao
    {
  public Guid IDDaoTao { get; set; }

  public Guid IDNhanVien { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
  public string NoiDaoTao { get; set; }
  public string ChuyenNganh { get; set; }
  public string HinhThucDaoTao { get; set; }
  public string BangCap { get; set; }
 
    }
}
