using QLNS.BL.BaseBL;
using QLNS.DL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;

namespace QLNS.BL
{
    public class StudentBL : BaseBL<hocvan>, IStudentBL
    {
        private IStudentDL _studentDL;
        public StudentBL(IStudentDL studentDL) : base(studentDL)
        {
            _studentDL = studentDL;
        }
       
    }
}
