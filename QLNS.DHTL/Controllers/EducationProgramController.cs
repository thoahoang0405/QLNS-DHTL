using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.Common.entities;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationProgramController : BasesController<EducationProgram>
    {
        private IEducationProgramBL _employeeBL;
        public EducationProgramController(IEducationProgramBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

    }
}
