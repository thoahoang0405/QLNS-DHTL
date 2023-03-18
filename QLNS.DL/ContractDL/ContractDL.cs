using Dapper;
using MySqlConnector;
using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DL.ContractDL
{
    public class ContractDL:BaseDL<Contract>, IContractDL   
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns.V1; User Id = root;Password=123456 ";
        public PagingData<Contract> FilterContract(string? keyword, int? pageSize, int? pageNumber = 1)
        {

            string storedProcedureName = "Proc_Contract_GetPaging";
            var parameters = new DynamicParameters();
            parameters.Add("v_Sort", "EffectiveDate ASC");

            parameters.Add("v_Limit", pageSize);
            parameters.Add("v_Offset", (pageNumber - 1) * pageSize);            
           
            if (keyword != null)
            {
                parameters.Add("v_Where", $"ContractName LIKE '%{keyword}%'");

               
            
            }
            

           
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = sqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (multipleResults != null)
                {
                    var contract = multipleResults.Read<Contract>().ToList();
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



                    return new PagingData<Contract>()
                    {
                        Data = contract,
                        TotalRecords = TotalRecords,

                        TotalPages = TotalPagesAll
                    };
                }
            }
            return null;

        }
    }
}
