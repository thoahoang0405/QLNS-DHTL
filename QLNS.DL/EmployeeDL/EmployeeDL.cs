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
using System.Data;

namespace QLNS.DL
{
    public class EmployeeDL : BaseDL<nhanvien>, IEmployeeDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns; User Id = root;Password=18032001 ";
        public PagingData<nhanvien> FilterEmployee(string? keyword, int? pageSize, Guid? IDKhoa,  int? pageNumber = 1)
        {

            string storedProcedureName = "Proc_nhanvien_GetPaging";
            var parameters = new DynamicParameters();
            parameters.Add("v_Sort", "NgaySua DESC");

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
            if (IDKhoa != null)
            {
                andConditions.Add($"IDKhoa = '{IDKhoa}'");
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
                    var nhanviens = multipleResults.Read<nhanvien>().ToList();
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



                    return new PagingData<nhanvien>()
                    {
                        Data = nhanviens,
                        TotalRecords = TotalRecords,

                        TotalPages = TotalPagesAll
                    };
                }
            }
            return null;

        }
        public int DeleteMultiple(List<Guid> listId)
        {
            // lấy procedure name
            string procedureNameCommand = "Proc_nhanvien_DeleteMultiple";


            // tạo param
            var parameters = new DynamicParameters();

            var listIdToString = "";

            if (listId == null || listId.Count == 0)
            {
                return 0;
            }
            listIdToString = $"('{string.Join("','", listId)}')";

            parameters.Add("@v_ListIdToString", listIdToString);


            // chạy câu lệnh 

            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
             
                    int result = sqlConnection.Execute(procedureNameCommand, parameters, commandType: System.Data.CommandType.StoredProcedure);

                   
                      
                        return result;

                    

                
            }
        }


    }
}
