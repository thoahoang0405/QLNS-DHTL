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
    public class DisciplineBL : BaseBL<kiluat>, IDisciplineBL
    {
        private IDisciplineDL _classificationDL;
        public DisciplineBL(IDisciplineDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
      
    }
}
