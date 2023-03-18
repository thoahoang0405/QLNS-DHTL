using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using QLNS.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL
{
    public class SalaryBL : BaseBL<Salary>, ISalaryBL
    {
        private ISalaryDL _classificationDL;
        public SalaryBL(ISalaryDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
    }
}
