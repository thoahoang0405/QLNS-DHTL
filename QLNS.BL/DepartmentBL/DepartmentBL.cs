using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.COMMON.Entities;
using QLNS.DL;

namespace QLNS.BL
{
    public class DepartmentBL : BaseBL<ngachluong>, IDepartmentBL
    {
        private IDepartmentDL _departmentDL;
        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }
    }
}
