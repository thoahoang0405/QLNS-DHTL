using Microsoft.AspNetCore.Http;
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
    public class kiluatController : BasesController<kiluat>
    {
        private IDisciplineBL _employeeBL;
        public kiluatController(IDisciplineBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        

    }
}
