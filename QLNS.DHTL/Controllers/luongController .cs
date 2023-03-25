using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class luongController : BasesController<luong>
    {
        private ISalaryBL _employeeBL;
        public luongController(ISalaryBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
    }
}
