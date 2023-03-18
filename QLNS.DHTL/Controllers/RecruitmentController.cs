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
    public class RecruitmentController : BasesController<Recruitment>
    {
        private IRecruitmentBL _employeeBL;
        public RecruitmentController(IRecruitmentBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

    }
}
