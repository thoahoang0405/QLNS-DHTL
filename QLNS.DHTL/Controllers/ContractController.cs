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
    public class ContractController : BasesController<Contract>
    {
        private IContractBL _employeeBL;
        public ContractController(IContractBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Student>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterContract([FromQuery] string? keyword, [FromQuery] int pageSize,  [FromQuery] int pageNumber = 1)
        {

            var multipleResults = _employeeBL.FilterContract(keyword, pageSize, pageNumber);
            if (multipleResults != null)
            {
                return StatusCode(StatusCodes.Status200OK, multipleResults);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "lỗi giá trị đầu vào");
            }
        }

    }
}
