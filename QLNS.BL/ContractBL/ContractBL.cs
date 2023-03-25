﻿using QLNS.BL.BaseBL;
using QLNS.BL;
using QLNS.Common.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.COMMON.Entities;
using QLNS.DL;
using QLNS.DL.ContractDL;
using QLNS.Common.Entities;

namespace QLNS.BL
{
    public class ContractBL : BaseBL<hopdong>, IContractBL
    {
        private IContractDL _contractDL;
        public ContractBL(IContractDL contractDL) : base(contractDL)
        {
          
            _contractDL = contractDL;
            
        }
        
    }
}
