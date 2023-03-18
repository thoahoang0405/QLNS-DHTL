using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using QLNS.Common.Entities;

namespace QLNS.DL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns.V1; User Id = root;Password=123456 ";
        public PagingData<Employee> FilterEmployee(string? keyword, int? pageSize, Guid? departmentID, Guid? positionID, int? pageNumber = 1)
        {

            string storedProcedureName = "Proc_Employee_GetPaging";
            var parameters = new DynamicParameters();
            parameters.Add("v_Sort", "EmployeeCode ASC");

            parameters.Add("v_Limit", pageSize);
            parameters.Add("v_Offset", (pageNumber - 1) * pageSize);
            var orConditions = new List<string>();

            var andConditions = new List<string>();
            string whereClause = "";
            if (keyword != null)
            {
                orConditions.Add($"EmployeeCode LIKE '%{keyword}%'");
                orConditions.Add($"EmployeeName LIKE '%{keyword}%'");

            }
           if(departmentID != Guid.Empty)
            {
                andConditions.Add($"DepartmentID = '{departmentID}'");
            }
            if(positionID != Guid.Empty)
            {
                andConditions.Add($"PositionsID = '{positionID}'");
            }
            if (orConditions.Count > 0)
            {
                whereClause = $"({string.Join(" OR ", orConditions)})";
                
            }



            else if (andConditions.Count() > 0)
            {
                whereClause = $"({string.Join(" AND ", andConditions)})";
            }
            else if (andConditions.Count() > 0 && orConditions.Count() > 0)
            {
                whereClause = "(" + whereClause + ") AND " + string.Join(" AND ", andConditions);
            }
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
                    var employees = multipleResults.Read<Employee>().ToList();
                    var TotalRecords = multipleResults.Read<long>().Single();

                    int TotalPagesAll = 1;

                    if (TotalRecords >= 0 && pageSize > 0)
                    {
                       
                            TotalPagesAll = (int)(decimal)(TotalRecords / pageSize);
                            if (TotalPagesAll % pageSize != 0)
                            {
                                TotalPagesAll = TotalPagesAll + 1;
                            }
                       
                    }



                    return new PagingData<Employee>()
                    {
                        Data = employees,
                        TotalRecords = TotalRecords,

                        TotalPages = TotalPagesAll
                    };
                }
            }
            return null;

        }
    }
}
