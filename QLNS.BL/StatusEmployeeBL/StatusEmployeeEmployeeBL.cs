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
    public class StatusEmployeeBL : BaseBL<tinhtrang>, IStatusEmployeeBL
    {
        private IStatusEmployeeDL _classificationDL;
        public StatusEmployeeBL(IStatusEmployeeDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
    }
}
