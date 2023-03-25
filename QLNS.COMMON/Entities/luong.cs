using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("luong")]
    public class luong
    {
        [Key]
        public Guid IDLuong { get; set; }
        public Guid? IDNhanVien { get; set; }
        public Guid? IDPhuCap { get; set; }
        public string NgachLuong { get; set; }
        public string HeSoLuong { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string MaNgachHuongLuong { get; set; }
        public string IDNgachLuong { get; set; }
        public string BHXH { get; set; }
        public string? BHYT { get; set; }
        public string PhanTramHuongLuong { get; set; }   
        public string? TenPhuCap { get; set; }
        public string? GiaTriPhuCap { get; set; }
    
    }
}
