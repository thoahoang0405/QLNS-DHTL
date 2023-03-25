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

namespace QLNS.BL
{
    public class BonusBL : BaseBL<khenthuong>, IBonusBL
    {
        private IBonusDL _bonusDL;
        public BonusBL(IBonusDL baseDL) : base(baseDL)
        {
            _bonusDL = baseDL;
        }
      
    }
}
