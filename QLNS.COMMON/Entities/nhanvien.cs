

using QLNS.Common.Enums;
using QLNS.COMMON;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QLNS.Common.entities
{
    #region
    [Table("nhanvien")]
    public class nhanvien
    {

        [Key]
     
        public Guid IDNhanVien { get; set; }
        
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
       
        public string? TonGiao { get; set; }
        public string? DanToc { get; set; }
        public string? CCCD { get; set; }
        public DateTime? NgayCap { get; set; }
        public string? NoiCap { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? SDT { get; set; }
        public Guid IDKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string? MaKhoa { get; set; }
        public DateTime? NgaySua { get; set; }

#endregion



    }
}
