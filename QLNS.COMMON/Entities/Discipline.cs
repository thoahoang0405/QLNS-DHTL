using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("discipline")]
    public class Discipline
    {
        [Key]
        public Guid DisciplineID { get; set; }

          public string?  Reason { get; set; }
        public string? Location { get; set; }
        public DateTime? DisciplineDate { get; set; }
        public string? Form { get; set; }
        public Guid? UserID { get; set; }
    }
}
