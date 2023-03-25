using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL.BaseBL
{
    public interface IBaseDL<T>

    {
        /// <summary>
        /// API thêm mới bản ghi
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
       
        public Guid InsertRecord(T record);

        /// <summary>
        /// API sửa bản ghi
        /// </summary>
        /// <param name="entity, id"></param>
        /// <returns></returns>
      
        public int UpdateRecord(T entity, Guid id);

        /// <summary>
        /// API lấy tất cả bản ghi
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        
        public IEnumerable<dynamic> GetAllRecords();

        /// <summary>
        /// API lấy 1 bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      
        public IEnumerable<dynamic> GetRecordByID(Guid id);

        /// <summary>
        /// API lấy mã mới
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
     
        public string GetNewCode();

        /// <summary>
        /// API xóa bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
      
        public int DeleteRecordID(Guid id);
    }
}
