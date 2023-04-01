using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using QLNS.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Dapper;
using QLNS.Common.Entities;
using QLNS.DHTL.Controllers;

namespace QLNS.BL
{
    public class SalaryDL : BaseDL<luong>, ISalaryDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns; User Id = root;Password=123456 ";
        public PagingData<view_luong> FilterSalary(string? keyword, int pageSize, int? nam, int? thang, int pageNumber = 1)
        {

            string storedProcedureName = "Proc_luong_GetPaging";
            var parameters = new DynamicParameters();
            parameters.Add("v_Sort", "NgayNhan DESC");

            parameters.Add("v_Limit", pageSize);
            parameters.Add("v_Offset", (pageNumber - 1) * pageSize);
            var orConditions = new List<string>();

            var andConditions = new List<string>();
            string whereClause = "";
            if (keyword != null)
            {
                orConditions.Add($"MaNV LIKE '%{keyword}%'");
                orConditions.Add($"TenNV LIKE '%{keyword}%'");


            }
            if (nam != null)
            {
                andConditions.Add($"Nam = '{nam}'");
            }
            if (thang != null)
            {
                andConditions.Add($"Thang = '{thang}'");
            }

            if (orConditions.Count > 0)
            {
                whereClause = $"({string.Join(" OR ", orConditions)})";
                if (andConditions.Count() > 0)
                {
                    whereClause = "(" + whereClause + ") AND " + string.Join(" AND ", andConditions);
                }

            }
            else if (andConditions.Count() > 0)
            {
                whereClause = $"({string.Join(" AND ", andConditions)})";
            }
            //else if (andConditions.Count() > 0 && orConditions.Count() > 0)
            //{
            //    whereClause = "(" + whereClause + ") AND " + string.Join(" AND ", andConditions);
            //}
            else
            {
                whereClause = "";
            }

            parameters.Add("v_Where", whereClause);
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = sqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var nhanviens = multipleResults.Read<view_luong>().ToList();
                    var TotalRecords = multipleResults.Read<long>().Single();

                    int TotalPagesAll = 1;

                    if (TotalRecords >= 0 && pageSize > 0)
                    {

                        TotalPagesAll = (int)(decimal)(TotalRecords / pageSize);
                        if (TotalRecords % pageSize != 0)
                        {
                            TotalPagesAll = TotalPagesAll + 1;
                        }

                    }



                    return new PagingData<view_luong>()
                    {
                        Data = nhanviens,
                        TotalRecords = TotalRecords,

                        TotalPages = TotalPagesAll
                    };
                }
            }
            return null;

        }
    }
}
