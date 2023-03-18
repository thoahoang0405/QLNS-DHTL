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
    public class DisciplineBL : BaseBL<Discipline>, IDisciplineBL
    {
        private IDisciplineDL _classificationDL;
        public DisciplineBL(IDisciplineDL baseDL) : base(baseDL)
        {
            _classificationDL = baseDL;
        }
        public PagingData<Discipline> FilterDiscipline(string? keyword, int? pageSize, int? pageNumber = 1)
        {
            return _classificationDL.FilterDiscipline(keyword, pageSize, pageNumber);
        }
    }
}
