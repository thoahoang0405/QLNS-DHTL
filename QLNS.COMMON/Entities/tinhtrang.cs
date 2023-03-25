using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("tinhtrang")]
    public class tinhtrang
    {
        public Guid IDTinhTrang { get; set; }
        public Guid IDNhanVien { get; set; }
        public string TenTinhTrang { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT {get;set;}
    }
}
