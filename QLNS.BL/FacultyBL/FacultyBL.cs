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
    public class FacultyBL : BaseBL<Faculty>, IFacultyBL
    {
        private IFacultyDL _facultyDL;
        public FacultyBL(IFacultyDL facultyDL) : base(facultyDL)
        {
            _facultyDL = facultyDL;
        }
    }
}
