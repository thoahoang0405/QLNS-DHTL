using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("quanhegiadinh")]
    public class quanhegiadinh
    {
       public Guid IDGiaDinh { get; set; }
          public Guid IDNhanVien { get; set; }
       public string TinhTrang { get; set; } 
        public string GiaDinh { get; set; }
    }
}
