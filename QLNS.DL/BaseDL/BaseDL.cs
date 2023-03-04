﻿using Dapper;
using MySqlConnector;
using QLNS.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL.BaseBL
{
    public class BaseDL<T> : IBaseDL<T>
    {

        #region Field
        readonly string connectionDB = "Server= localhost; Port=3306; Database=misa; User Id = root;Password=123456 ";
        #endregion

        #region method
        /// <summary>
        /// Thêm bản ghi
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
      
        public Guid InsertRecord(T record)
        {
            GetBeforeSave(record);

            string tableName = EntityUtilities.GetTableName<T>();
            string storeProcedureName = $"Proc_{tableName}_Insert";
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                string propertyName = $"@{property.Name}";
                var propertyValue = property.GetValue(record);
                parameters.Add(propertyName, propertyValue);
            }
            int numberOfAffectedRows = 0;
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {

                numberOfAffectedRows = sqlConnection.Execute(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var result = Guid.Empty;
                if (numberOfAffectedRows > 0)
                {
                    var primaryKeyProperty = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
                    var newId = primaryKeyProperty?.GetValue(record);
                    if (newId != null)
                    {
                        result = (Guid)newId;
                    }
                }
                return result;

            }

        }

        /// <summary>
        /// set giá trị riêng cho bảng
        /// </summary>
        /// <param name="entity"></param>
       
        protected virtual void GetBeforeSave(T entity)
        {

        }

        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
      
        public int UpdateRecord(T entity, Guid id)
        {
            string tableName = EntityUtilities.GetTableName<T>();
            string storeProcedureName = $"Proc_{tableName}_Update";
            var properties = typeof(T).GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                string propertyName = $"@{property.Name}";
                var propertyValue = property.GetValue(entity);
                parameters.Add(propertyName, propertyValue);
            }
            int numberOfAffectedRows = 0;
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {

                numberOfAffectedRows = sqlConnection.Execute(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return numberOfAffectedRows;

            }
        }

        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
      
        public IEnumerable<dynamic> GetAllRecords()
        {
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
                string className = typeof(T).Name;
                var getAllRecords = $"SELECT * FROM {className}";
                var records = sqlConnection.Query(getAllRecords);

                return records;
            }


        }
        /// <summary>
        /// API xóa 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
      

        public int DeleteRecordID(Guid id)
        {

            using (var sqlConnection = new MySqlConnection(connectionDB))
            {

                var idName = typeof(T).GetProperties().First().Name;
                string className = typeof(T).Name;
                string sqlCommand = $"DELETE FROM {className} Where {idName}='{id}'";
                var parameters = new DynamicParameters();


                // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
                int numberOfAffectedRows = sqlConnection.Execute(sqlCommand, parameters);

                return numberOfAffectedRows;
            }


        }
        /// <summary>
        /// Lấy theo ID
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
      
        public T GetRecordByID(Guid id)
        {
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
                var idName = typeof(T).GetProperties().First().Name;
                string className = typeof(T).Name;
                string sqlCommand = $"SELECT * FROM {className} Where {idName}='{id}'";
                var parameters = new DynamicParameters();
                return sqlConnection.QueryFirstOrDefault<T>(sqlCommand, parameters);


            }
        }

        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
    

        public string GetNewCode()
        {
            using (var sqlConnection = new MySqlConnection(connectionDB))
            {
                string className = typeof(T).Name;
                string storedProcedureName = $"Proc_{className}_GetMaxCode";
                string maxCode = sqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý sinh mã nhân viên mới tự động tăng
                // Cắt chuỗi mã nhân viên lớn nhất trong hệ thống để lấy phần số
                string newCode = "NV" + (Int64.Parse(maxCode.Substring(2)) + 1).ToString();

                // Trả về dữ liệu cho client
                return newCode;
            }
        }

        #endregion

    }
}
