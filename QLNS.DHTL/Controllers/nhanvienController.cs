
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.BL.BaseBL;
using QLNS.DL;
using QLNS.Common.entities;
using QLNS.DHTL.BaseController;
using QLNS.Common.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class nhanvienController : BasesController<nhanvien>
    {
        private IEmployeeBL _employeeBL;
        public nhanvienController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<nhanvien>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterEmployees([FromQuery] string? keyword, [FromQuery] int? pageSize, [FromQuery] Guid? IDKhoa,  [FromQuery] int? pageNumber=1)
        {

            var multipleResults = _employeeBL.FilterEmployee(keyword, pageSize,IDKhoa, pageNumber);
            if (multipleResults != null)
            {
                return StatusCode(StatusCodes.Status200OK, multipleResults);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
        }
    }
}
