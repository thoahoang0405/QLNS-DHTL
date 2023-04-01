using Microsoft.AspNetCore.Http;
using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL
{
    public interface IEmployeeBL : IBaseBL<nhanvien>
    {
        public PagingData<nhanvien> FilterEmployee(string? keyword, int pageSize, Guid? IDKhoa, int pageNumber);
        public ImportResult<Guid> ImportFileExcel(IFormFile file);
        public int DeleteMultiple(List<Guid> listId);
    }
}
