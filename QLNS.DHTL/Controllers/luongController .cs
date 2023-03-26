using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using QLNS.BL;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;
using QLNS.DHTL.BaseController;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.Graph.Ediscovery;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLNS.DHTL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class luongController : BasesController<luong>
    {
        private ISalaryBL _employeeBL;
        public luongController(ISalaryBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        [HttpGet("Filter")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<view_luong>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterSalary([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] int? nam, [FromQuery] int? thang, [FromQuery] int pageNumber = 1)
        {

            var multipleResults = _employeeBL.FilterSalary(keyword, pageSize, nam,thang, pageNumber);
            if (multipleResults != null)
            {
                return StatusCode(StatusCodes.Status200OK, multipleResults);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "e002");
            }
        }

        [HttpGet("ExportExcel")]
        public IActionResult ExportExcel([FromQuery] string? keyword, [FromQuery] int pageSize, [FromQuery] int? nam, [FromQuery] int? thang, [FromQuery] int pageNumber = 1)
        {
            try
            {

                var stream = new MemoryStream();
                using (var package = new ExcelPackage(stream))
                {


                    var luong = _employeeBL.FilterSalary(keyword, pageSize, nam, thang, pageNumber);


                    var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH LƯƠNG NHÂN VIÊN");
                    workSheet.TabColor = System.Drawing.Color.Black;

                    workSheet.DefaultRowHeight = 12;

                    workSheet.Row(1).Height = 20;
                    workSheet.Cells["A1:O1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;
                    workSheet.Cells["A1:O1"].Merge = true;
                    workSheet.Cells["A1:O1"].Value = "DANH SÁCH LƯƠNG NHÂN VIÊN";
                    workSheet.Cells["A1:O1"].Style.Font.Size = 16;


                    workSheet.Row(3).Height = 15;
                    workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(3).Style.Font.Bold = true;
                    workSheet.Cells["A3:O3"].Style.Font.Size = 13;
                    workSheet.Cells["A3:O3"].Style.Fill.SetBackground(System.Drawing.Color.LightGray);
                    workSheet.Cells[3, 1].Value = "STT";
                    workSheet.Cells[3, 2].Value = " Mã nhân viên ";
                    workSheet.Cells[3, 3].Value = " Tên nhân viên ";
                    workSheet.Cells[3, 4].Value = " Tên khoa ";
                    workSheet.Cells[3, 5].Value = " Ngày sinh ";
                    workSheet.Cells[3, 6].Value = " CCCD ";
                    workSheet.Cells[3, 7].Value = " Hệ số lương ";
                    workSheet.Cells[3, 8].Value = " Ngạch lương ";
                    workSheet.Cells[3, 9].Value = " Tên phụ cấp ";
                    workSheet.Cells[3, 10].Value = " Giá trị phụ cấp ";
                    workSheet.Cells[3, 11].Value = " BHXH ";
                    workSheet.Cells[3, 12].Value = " BHYT ";
                    workSheet.Cells[3, 13].Value = " Phần trăm hưởng lương ";
                    workSheet.Cells[3, 14].Value = " Tháng ";
                    workSheet.Cells[3, 15].Value = " Năm ";



                    int index = 4;

                    foreach (var luongnv in luong.Data)
                    {
                        workSheet.Cells[index, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[index, 1].Value = (index - 3).ToString();
                        workSheet.Cells[index, 2].Value = luongnv.MaNV;
                        workSheet.Cells[index, 3].Value = luongnv.TenNV;
                        workSheet.Cells[index, 4].Value = luongnv.TenKhoa;
                        workSheet.Cells[index, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Cells[index, 5].Style.Numberformat.Format = "dd/mm/yyyy";
                        workSheet.Cells[index, 5].Value = luongnv.NgaySinh;
                      
                        workSheet.Cells[index, 6].Value = luongnv.CCCD;
                      

                        workSheet.Cells[index, 7].Value = luongnv.HeSoLuong;
                        workSheet.Cells[index, 8].Value = luongnv.MaNgachLuong;

                     
                      
                        workSheet.Cells[index, 9].Value = luongnv.TenPhuCap;
                        workSheet.Cells[index, 10].Value = luongnv.GiaTriPhuCap;
                        workSheet.Cells[index, 11].Value = luongnv.BHXH;
                        workSheet.Cells[index, 12].Value = luongnv.BHYT;
                        workSheet.Cells[index, 13].Value = luongnv.PhanTramHuongLuong;
                        workSheet.Cells[index, 14].Value = luongnv.Thang;
                        workSheet.Cells[index, 15].Value = luongnv.Nam;
                      
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
                string excelName = "Danh_luong_nhan_vien.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi");
            }
        }

    }
}
