﻿using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using QLNS.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL
{
    public class PositionDL : BaseDL<chucvu>, IPositionDL
    {
        readonly string connectionDB = "Server= localhost; Port=3306; Database=qlns; User Id = root;Password=18032001 ";
       
    }
}
