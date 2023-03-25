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
    public class boiduongController : BasesController<boiduong>
    {
        private IClassificationBL _employeeBL;
        public boiduongController(IClassificationBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

    }
}
