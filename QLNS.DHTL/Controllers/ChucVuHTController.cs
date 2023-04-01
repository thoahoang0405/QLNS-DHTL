using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.BL.BaseBL;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuHTController : BasesController<chucvuhientai>
    {
        private IBaseBL<chucvuhientai> _cvHT;
        public ChucVuHTController(IBaseBL<chucvuhientai> cv) : base(cv)
        {
            _cvHT = cv;
        }
    }
}
