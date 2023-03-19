using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("recruitment")]
    public class Recruitment
    {
        
       [Key]
        public Guid RecruitmentID { get; set; }
        public string? Title { get; set; }
        public string? Skill { get; set; }
        public string? Benefit { get; set; }
        public string? Salary { get; set; }
        public string? Experience { get; set; }
        public string? DepartmentOfWork { get; set; }
    }
}
