using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("phucap")]
    public class phucap
    {
        [Key]
        public Guid IDphucap { get; set; }
        public string?  TenPhuCap { get; set; }
        public string? GiaTriPhuCap { get; set; }
      
    }
}
