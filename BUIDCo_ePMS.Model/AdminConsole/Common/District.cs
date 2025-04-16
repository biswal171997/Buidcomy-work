using System;
using System.Collections.Generic;
using System.Text;

namespace BUIDCO.Domain.Common
{
    public class District
    {
        public int DISTID { get; set; }
        public string DISTNAME { get; set; }
        public DateTime CREATEDON { get; set; }
        public DateTime UPDATEDON { get; set; }
        public int UPDATEDBY { get; set; }
        public int CREATEDBY { get; set; }
        public bool DELETEDFLAG { get; set; }
    }
}
