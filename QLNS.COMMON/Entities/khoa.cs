using QLNS.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLNS.Common.entities

{
    [Table("khoa")]

    public class khoa {

        [Key]
       public Guid IDkhoa { get; set; }

        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; } 
       

    }
}
