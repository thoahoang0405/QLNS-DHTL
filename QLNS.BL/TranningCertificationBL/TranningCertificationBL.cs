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
    public class TranningCertificationBL : BaseBL<phucap>, ITranningCertificationBL
    {
        private ITranningCertificationDL _classificationDL;
        public TranningCertificationBL(ITranningCertificationDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
    }
}
