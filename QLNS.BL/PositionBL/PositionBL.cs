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
    public class PositionBL : BaseBL<Position>, IPositionBL
    {
        private IPositionDL _classificationDL;
        public PositionBL(IPositionDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
    }
}
