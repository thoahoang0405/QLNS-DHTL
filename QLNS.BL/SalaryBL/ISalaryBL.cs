using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;
using QLNS.DHTL.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL
{
    public interface ISalaryBL : IBaseBL<luong>
    {
        public PagingData<view_luong> FilterSalary(string? keyword, int pageSize, int? nam, int? thang, int pageNumber = 1);
    }
}
