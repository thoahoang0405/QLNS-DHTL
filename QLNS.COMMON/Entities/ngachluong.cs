using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("ngachluong")]

    public class ngachluong
    {
      public Guid IDNgachLuong { get;set; }
     
     public string MaNgachLuong { get;set; }
      public string TenNgachLuong { get; set; }


      
    }
}
