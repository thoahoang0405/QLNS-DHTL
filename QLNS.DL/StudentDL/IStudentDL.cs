using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DL
{
    public interface IStudentDL:IBaseDL<Student>
    {
        
        public PagingData<Student> FilterStudent(string? keyword, int? pageSize, Guid? facultyID, Guid? classificationID, int? pageNumber = 1);
    }
}
