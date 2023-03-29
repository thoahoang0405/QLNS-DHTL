using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.COMMON.Entities.DTO
{
    public class ImportResult<T>
    {
        /// <summary>
        /// danh sách ID đã thêm thành công
        /// </summary>
        public List<T> listId { get; set; } = new List<T>();

        /// <summary>
        /// tổng số bản ghi bị trùng mã 
        /// </summary>
        public int totalCountError { get; set; }
    }
}
