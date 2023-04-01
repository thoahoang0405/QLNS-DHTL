using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("luong")]
    public class luong
    {
        [Key]
  //      IDLuong CHAR(36) NOT NULL DEFAULT '',
  //IDNhanVien CHAR(36) DEFAULT NULL,
  //IDPhuCap CHAR(36) DEFAULT NULL,
  //TenNgachLuong VARCHAR(255) DEFAULT NULL,
  //HeSoLuong FLOAT DEFAULT NULL,
  //NgayNhan DATETIME DEFAULT NULL,
  //MaNgachLuong VARCHAR(20) DEFAULT NULL,
  //BHXH FLOAT DEFAULT NULL,
  //BHYT FLOAT DEFAULT NULL,
  //PhanTramHuongLuong FLOAT DEFAULT NULL,
  //TenPhuCap VARCHAR(255) DEFAULT NULL,
  //GiaTriPhuCap VARCHAR(255) DEFAULT NULL,
  //IDNgachLuong CHAR(36) DEFAULT NULL,
  //Thang INT DEFAULT NULL,
  //Nam INT DEFAULT NULL,
  //IDCVHT CHAR(36) DEFAULT NULL,
  //TenCVHT VARCHAR(255) DEFAULT NULL,
  //PRIMARY KEY(IDLuong)
        public Guid IDLuong { get; set; }
        public Guid? IDNhanVien { get; set; }
        public Guid? IDPhuCap { get; set; }
        public string? TenNgachLuong { get; set; }
        public float? HeSoLuong { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string MaNgachLuong { get; set; }
        public float? BHXH { get; set; }
        public float? BHYT { get; set; }
        public float PhanTramHuongLuong { get; set; }
        public string? TenPhuCap { get; set; }
        public string? GiaTriPhuCap { get; set; }
        public Guid IDNgachLuong { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }
        public Guid? IDCVHT { get; set; }
        public string? TenCVHT { get; set; }
       
    }
}
