using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class khenthuongController : BasesController<khenthuong>
    {
        private IBonusBL _employeeBL;
        public khenthuongController(IBonusBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
       
    }
}
