﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Domain.AdminConsole.DesignationMaster
{
    public class DesignationMaster
    {
        public int INTDESIGID { get; set; }
        public string NVCHDESIGNAME { get; set; }
        public string NVCHALIASNAME { get; set; }
       
        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }
    }
    public class CreateDesignationMaster
    {

      
        public string NVCHDESIGNAME { get; set; }
        public string NVCHALIASNAME { get; set; }

        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }

    }
    public class DesignationMasterModel
    {
        public List<DesignationMaster> DesignationMasterList { get; set; }
    }
}
