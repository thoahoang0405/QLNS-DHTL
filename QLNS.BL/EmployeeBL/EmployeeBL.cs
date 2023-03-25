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
    public class EmployeeBL : BaseBL<nhanvien>, IEmployeeBL
    {
        private IEmployeeDL _employeeDL;
        public EmployeeBL(IEmployeeDL baseDL) : base(baseDL)
        {
            _employeeDL = baseDL;
           
        }
        public PagingData<nhanvien> FilterEmployee(string? keyword, int? pageSize, Guid? IDKhoa, int? pageNumber)
        {
            return _employeeDL.FilterEmployee(keyword, pageSize,IDKhoa, pageNumber);
        }
    }
}
