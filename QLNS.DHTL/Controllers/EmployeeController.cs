using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.DHTL.BaseController;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BasesController<Employee>
    {
        public EmployeeController(IBaseBL<Employee> baseBL) : base(baseBL)
        {
        }
    }
}
