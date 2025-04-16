using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Domain.AdminConsole.TabMaster
{
    public class TabMasterNew
    {
        public string ActionCode { get; set; }
        public int INTTABID { get; set; }

        public int INTBUTTONID { get; set; }

        public string NVCHBUTTON { get; set; }
        public string FView { get; set; }

        public string FAdd { get; set; }

        public string FManage { get; set; }
        public string NVCHTAB { get; set; }
        public string VCHURL { get; set; }
        public string VCHBUTTON1 { get; set; }

        public string VCHBUTTON2 { get; set; }

        public string VCHBUTTON3 { get; set; }
        public string NVCHDESCRIPTION { get; set; }

        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }
        public string intSortNum { get; set; }
    }
}
