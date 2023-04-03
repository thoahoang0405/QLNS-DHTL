using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DL
{
    public interface IEmployeeDL : IBaseDL<nhanvien>
    {
        public PagingData<nhanvien> FilterEmployee(string? keyword, int? pageSize, Guid? IDKhoa, int? pageNumber = 1);
        public int DeleteMultiple(List<Guid> listId);
    }
}
