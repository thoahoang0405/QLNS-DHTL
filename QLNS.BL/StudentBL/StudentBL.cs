using QLNS.BL.BaseBL;
using QLNS.DL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.Common.Entities;

namespace QLNS.BL
{
    public class StudentBL : BaseBL<Student>, IStudentBL
    {
        private IStudentDL _studentDL;
        public StudentBL(IStudentDL studentDL) : base(studentDL)
        {
            _studentDL = studentDL;
        }
        public PagingData<Student> FilterStudent(string? keyword, int? pageSize, Guid? facultyID, Guid? classificationID, int? pageNumber = 1)
        {
            return _studentDL.FilterStudent(keyword, pageSize, facultyID, classificationID, pageNumber);
        }
    }
}
