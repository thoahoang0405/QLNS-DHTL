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
    public class FacultyController : BasesController<Faculty>
    {
        private IFacultyBL _facultyBL;
        public FacultyController(IFacultyBL facultyBL) : base(facultyBL)
        {
            _facultyBL = facultyBL;
        }

    }
}
