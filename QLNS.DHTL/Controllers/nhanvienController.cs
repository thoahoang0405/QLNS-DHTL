
using Microsoft.AspNetCore.Mvc;
using QLNS.BL;
using QLNS.BL.BaseBL;
using QLNS.DL;
using QLNS.Common.entities;
using QLNS.DHTL.BaseController;
using QLNS.Common.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Drawing.Printing;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using Microsoft.Graph;

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
        public IActionResult FilterEmployees([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] Guid? IDKhoa,  [FromQuery] int pageNumber=1)
        {

            var multipleResults = _employeeBL.FilterEmployee(keyword, pageSize, IDKhoa, pageNumber);
            if (multipleResults != null)
            {
                return StatusCode(StatusCodes.Status200OK, multipleResults);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
        }
        [SwaggerResponse(statusCode: StatusCodes.Status200OK)]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest)]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpPost("import-excel")]
        public IActionResult ImportFileExcel(IFormFile file)
        {

            try
            {
                var result = _employeeBL.ImportFileExcel(file);

                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "import lỗi");
            }
        }
        

        [HttpGet("ExportExcel")]
        public IActionResult ExportExcel([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] Guid? IDKhoa, [FromQuery] int pageNumber = 1)
        {
            try
            {

                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {


                    var nhanvien = _employeeBL.FilterEmployee(keyword, pageSize, IDKhoa, pageNumber);


                    var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");
                    workSheet.TabColor = System.Drawing.Color.Black;

                    workSheet.DefaultRowHeight = 12;

                    workSheet.Row(1).Height = 20;
                    workSheet.Cells["A1:P1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;
                    workSheet.Cells["A1:P1"].Merge = true;
                    workSheet.Cells["A1:P1"].Value = "DANH SÁCH NHÂN VIÊN";
                    workSheet.Cells["A1:P1"].Style.Font.Size = 16;


                    workSheet.Row(3).Height = 15;
                    workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(3).Style.Font.Bold = true;
                    workSheet.Cells["A3:P3"].Style.Font.Size = 13;
                    workSheet.Cells["A3:P3"].Style.Fill.SetBackground(System.Drawing.Color.LightGray);
                    workSheet.Cells[3, 1].Value = "STT";
                    workSheet.Cells[3, 2].Value = " ID nhân viên ";
                    workSheet.Cells[3, 3].Value = " Mã nhân viên ";
                    workSheet.Cells[3, 4].Value = " Tên nhân viên ";
                    workSheet.Cells[3, 5].Value = " Ngày sinh ";
                    workSheet.Cells[3, 6].Value = " Giới tính ";
                    workSheet.Cells[3, 7].Value = " Tôn Giáo ";
                    workSheet.Cells[3, 8].Value = " Dân tộc ";
                    workSheet.Cells[3, 9].Value = " CCCD ";
                    workSheet.Cells[3, 10].Value = " Ngày Cấp ";
                    workSheet.Cells[3, 11].Value = " Nơi Cấp ";
                    workSheet.Cells[3, 12].Value = " Email ";
                    workSheet.Cells[3, 13].Value = " Địa chỉ ";
                    workSheet.Cells[3, 14].Value = " Số Điện Thoại ";
                    workSheet.Cells[3, 15].Value = " Mã Khoa ";
                    workSheet.Cells[3, 16].Value = " Tên Khoa ";



                    int index = 4;

                    foreach (var employee  in nhanvien.Data)
                    {
                        workSheet.Cells[index, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[index, 1].Value = (index - 3).ToString();
                        workSheet.Cells[index, 2].Value = employee.IDNhanVien;
                        workSheet.Cells[index, 3].Value = employee.MaNV;
                        workSheet.Cells[index, 4].Value = employee.TenNV;
                        workSheet.Cells[index, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[index, 5].Style.Numberformat.Format = "dd/mm/yyyy";
                        workSheet.Cells[index, 5].Value = employee.NgaySinh;

                        if (employee.GioiTinh == 0)
                        {
                            workSheet.Cells[index, 6].Value = "Nam";
                        }
                       if (employee.GioiTinh == 1)
                        {
                            workSheet.Cells[index, 6].Value = "Nữ";
                        }
                       


                        workSheet.Cells[index, 7].Value = employee.DanToc;
                        workSheet.Cells[index, 8].Value = employee.TonGiao;
                      
                        workSheet.Cells[index, 9].Value = employee.CCCD;
                        workSheet.Cells[index, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[index, 10].Style.Numberformat.Format = "dd/mm/yyyy";
                        workSheet.Cells[index, 10].Value = employee.NgayCap;
                        workSheet.Cells[index, 11].Value = employee.NoiCap;
                        workSheet.Cells[index, 12].Value = employee.Email;
                        workSheet.Cells[index, 13].Value = employee.DiaChi;
                        workSheet.Cells[index, 14].Value = employee.SDT;
                        workSheet.Cells[index, 15].Value = employee.MaKhoa;
                        workSheet.Cells[index, 16].Value = employee.TenKhoa;
                      
                        for (var i = 1; i < 17; i++)
                        {
                            workSheet.Cells[index, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                            workSheet.Cells[3, i].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        }

                        index++;

                    }

                    for (var i = 1; i < 17; i++)
                    {
                        workSheet.Column(i).AutoFit();
                    }


                    package.Save();
                }
                stream.Position = 0;
                string excelName = "Danh_sach_nhan_vien.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi");
            }
        }
        [SwaggerResponse(statusCode: StatusCodes.Status200OK)]
        [SwaggerResponse(statusCode: StatusCodes.Status400BadRequest)]
        [SwaggerResponse(statusCode: StatusCodes.Status500InternalServerError)]
        [HttpDelete("delete-multiple")]
        public IActionResult DeleteMultiple(List<Guid> listId)
        {
            try
            {
                int result = _employeeBL.DeleteMultiple(listId);
              
                    return StatusCode(StatusCodes.Status200OK, result);
              
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "lỗi hệ thống");
            }
        }

    }
}
