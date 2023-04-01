using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.DL;
using QLNS.Common.Entities;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http;
using QLNS.Common.Enums;
using QLNS.COMMON.Entities.DTO;
using System.ComponentModel;

namespace QLNS.BL
{
    public class EmployeeBL : BaseBL<nhanvien>, IEmployeeBL
    {
        private IEmployeeDL _employeeDL;
        public EmployeeBL(IEmployeeDL baseDL) : base(baseDL)
        {
            _employeeDL = baseDL;
           
        }
        public PagingData<nhanvien> FilterEmployee(string? keyword, int pageSize, Guid? IDKhoa, int pageNumber)
        {
            return _employeeDL.FilterEmployee(keyword, pageSize,IDKhoa, pageNumber);
        }
        public ImportResult<Guid> ImportFileExcel(IFormFile file)
        {
            // lưu lại danh sách Id được import
            List<Guid> listIdInsert = new List<Guid>();

            // đếm số bản ghi lỗi 
            var countEror = 0;

            // mở file 
            var stream = file.OpenReadStream();

            using (ExcelPackage package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.First(); // chọn wordsheet đầu tiên
                var rowCount = worksheet.Dimension.Rows; // đếm số dòng trong file

                // đọc danh sách property
                for (var row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        // đọc từng dòng trong file
                        var nhanvien = new nhanvien()
                        {
                            IDNhanVien = Guid.NewGuid(),
                            MaNV = worksheet.Cells[row, 2].Value?.ToString(),
                            TenNV = worksheet.Cells[row, 3].Value?.ToString(),
                            //NgaySinh=DateTime.Now,
                            ////NgaySinh = DateTime.(float.Parse(worksheet.Cells[row, 4].Value?.ToString())),
                            //GioiTinh = Int32.Parse(worksheet.Cells[row, 5].Value?.ToString()),
                            //TonGiao = worksheet.Cells[row, 6].Value?.ToString(),
                            //DanToc = worksheet.Cells[row, 7].Value?.ToString(),
                            //CCCD = worksheet.Cells[row, 8].Value?.ToString(),
                            //NgayCap = DateTime.FromOADate(float.Parse(worksheet.Cells[row, 9].Value?.ToString())),
                            NoiCap = worksheet.Cells[row, 10].Value?.ToString(),
                            Email = worksheet.Cells[row, 11].Value?.ToString(),
                            DiaChi = worksheet.Cells[row, 12].Value?.ToString(),
                            SDT = worksheet.Cells[row, 13].Value?.ToString(),
                            IDKhoa = Guid.Parse(worksheet.Cells[row, 14].Value?.ToString()),
                            MaKhoa = worksheet.Cells[row, 15].Value?.ToString(),
                            TenKhoa = worksheet.Cells[row, 16].Value?.ToString(),
                            //NgaySua = DateTime.Now,
                        };

                        // import property
                        var idResult =_employeeDL.InsertRecord(nhanvien);

                        if (idResult != null)
                        {
                            listIdInsert.Add(idResult);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        countEror++;
                    }
                }

                // trả về số bản ghi lỗi và danh sách Id đã import thành công 
                return new ImportResult<Guid>()
                {
                    listId = listIdInsert,
                    totalCountError = countEror,
                };
            }

        }
        public int DeleteMultiple(List<Guid> listId)
        {
            return _employeeDL.DeleteMultiple(listId);
        }
    }
}
