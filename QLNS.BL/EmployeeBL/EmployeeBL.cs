using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL.EmployeeBL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        public EmployeeBL(IBaseDL<Employee> baseDL) : base(baseDL)
        {
        }
    }
}
