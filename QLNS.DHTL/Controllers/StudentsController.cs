using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;

using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.DHTL.BaseController;
using Swashbuckle.AspNetCore.Annotations;

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BasesController<Student>
    {
        private IStudentBL _studentBL;
        public StudentsController(IStudentBL studentBL): base(studentBL)
        {
            _studentBL = studentBL;
        }
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Student>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterStudent([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] Guid facultyID, [FromQuery] Guid classificationID , [FromQuery] int pageNumber=1)
        {

            var multipleResults = _studentBL.FilterStudent(keyword, pageSize, facultyID, classificationID, pageNumber);
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
