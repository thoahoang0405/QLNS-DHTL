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
    public class BonusController : BasesController<Bonus>
    {
        private IBonusBL _employeeBL;
        public BonusController(IBonusBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Student>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterBonus([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] int pageNumber = 1)
        {

            var multipleResults = _employeeBL.FilterBonus(keyword, pageSize, pageNumber);
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
