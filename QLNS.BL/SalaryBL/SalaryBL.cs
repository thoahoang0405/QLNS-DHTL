using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using QLNS.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.Common.Entities;
using QLNS.DHTL.Controllers;

namespace QLNS.BL
{
    public class SalaryBL : BaseBL<luong>, ISalaryBL
    {
        private ISalaryDL _classificationDL;
        public SalaryBL(ISalaryDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
        public PagingData<view_luong> FilterSalary(string? keyword, int pageSize, int? nam, int? thang, int pageNumber = 1)
        {
            return _classificationDL.FilterSalary(keyword, pageSize, nam, thang, pageNumber);
        }
    }
}
