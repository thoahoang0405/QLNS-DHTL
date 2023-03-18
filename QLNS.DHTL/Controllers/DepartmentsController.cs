using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : BasesController<Department>
    {
        private IDepartmentBL _departmentBL;
        public DepartmentsController(IDepartmentBL department): base(department)
        {
            _departmentBL = department;
        }
    }
}
