﻿using QLNS.BL.BaseBL;
using QLNS.Common.entities;
using QLNS.Common.Entities;
using QLNS.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BL
{
    public interface IBonusBL : IBaseBL<Bonus>
    {
        public PagingData<Bonus> FilterBonus(string? keyword, int? pageSize, int? pageNumber = 1);
    }
}
