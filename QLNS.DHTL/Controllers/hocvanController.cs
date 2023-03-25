
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;

using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;
using Swashbuckle.AspNetCore.Annotations;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hocvanController : BasesController<hocvan>
    {
        private IStudentBL _studentBL;
        public hocvanController(IStudentBL studentBL): base(studentBL)
        {
            _studentBL = studentBL;
        }
       
    }
}
