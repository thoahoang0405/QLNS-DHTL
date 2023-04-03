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

namespace QLNS.DL
{
    public class StudentDL: BaseDL<hocvan>, IStudentDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns; User Id = root;Password=123456 ";
       
    }
}
