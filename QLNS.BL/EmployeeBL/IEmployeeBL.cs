using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        public PagingData<Employee> FilterEmployee(string? keyword, int? pageSize, Guid? departmentID, Guid? positionID, int? pageNumber = 1);
    }
}
