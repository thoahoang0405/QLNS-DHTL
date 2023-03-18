using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities
{
    [Table("contract")]
    public class Contract
    {
        [Key]
      public Guid  ContractID { get; set; }
        public string ContractName { get; set; }
       public DateTime SignDay { get; set; }
       public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
       public Guid EmployeeID { get; set; }
    }
}
