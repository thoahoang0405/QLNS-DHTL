using Dapper;
using MySqlConnector;
using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DL
{
    public class StudentDL: BaseDL<Student>, IStudentDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns.V1; User Id = root;Password=18032001";
        public PagingData<Student> FilterStudent(string? keyword, int? pageSize, Guid? facultyID, Guid? classificationID, int? pageNumber = 1)
        {

            string storedProcedureName = "Proc_Student_GetPaging";
            var parameters = new DynamicParameters();
            parameters.Add("v_Sort", "StudentCode ASC");

            parameters.Add("v_Limit", pageSize);
            parameters.Add("v_Offset", (pageNumber - 1) * pageSize);
            var orConditions = new List<string>();

            var andConditions = new List<string>();
            string whereClause = "";
            if (keyword != null)
            {
                orConditions.Add($"StudentCode LIKE '%{keyword}%'");
                orConditions.Add($"StudentName LIKE '%{keyword}%'");

            }
            if (facultyID != Guid.Empty)
            {
                andConditions.Add($"FacultyID = '{facultyID}'");
            }
            if (classificationID != Guid.Empty)
            {
                andConditions.Add($"ClassificationID = '{classificationID}'");
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
                    var student = multipleResults.Read<Student>().ToList();
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



                    return new PagingData<Student>()
                    {
                        Data = student,
                        TotalRecords = TotalRecords,

                        TotalPages = TotalPagesAll
                    };
                }
            }
            return null;

        }
    }
}
