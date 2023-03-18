using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.DL;
using QLNS.Common.Entities;

namespace QLNS.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        private IEmployeeDL _employeeDL;
        public EmployeeBL(IEmployeeDL baseDL) : base(baseDL)
        {
            _employeeDL = baseDL;
           
        }
        public PagingData<Employee> FilterEmployee(string? keyword, int? pageSize, Guid? departmentID, Guid? positionID, int? pageNumber = 1)
        {
            return _employeeDL.FilterEmployee(keyword, pageSize,departmentID,positionID, pageNumber);
        }
    }
}
