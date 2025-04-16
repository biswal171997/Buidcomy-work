using System;
using System.Collections.Generic;
using System.Text;

namespace BUIDCO.Domain.AdminConsole.EmailMaster
{
    public class EmailMaster
    {
        public int CONFIGID { get; set; }
        public string emailcc { get; set; }
        public string emailbcc { get; set; }
        public string DATAENTRYCONTENT { get; set; }
        public string DATAAPPROVERCONTENT { get; set; }
    }
}
