﻿using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.COMMON.Entities;

namespace QLNS.DL
{
    public class DepartmentDL : BaseDL<Department>, IDepartmentDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns.V1; User Id = root;Password=18032001";
       
    }
}
