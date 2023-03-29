using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("hocvan")]
    public class hocvan
    {
        

       [Key]
        public Guid IDHocVan { get; set; }
        public Guid IDNhanVien { get; set; }
        public string? TrinhDoLLCT { get; set; }
        public string? TrinhDoQLGD { get; set; }
        public string? TrinhDoQLNN { get; set; }
        public string? TrinhDoTinHoc { get; set; }
        public string? ChungChiNgoaiNgu { get; set; }
        public string? TinhTrangHocVan { get; set; }


    }
}
