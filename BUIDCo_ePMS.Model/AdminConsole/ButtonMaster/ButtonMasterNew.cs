using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Domain.AdminConsole.ButtonMaster
{
    public class ButtonMasterNew
    {
        public string ActionCode { get; set; }
        public int INTBUTTONID { get; set; }

        public int INTFUNCTIONID { get; set; }
        //public int FunctionId { get; set; }
        //  public string VCHFUNCTION { get; set; }
        public string NVCHBUTTON { get; set; }
        public string VCHURL { get; set; }

        public string NVCHDESCRIPTION { get; set; }
        public string FView { get; set; }

        public string FAdd { get; set; }

        public string FManage { get; set; }
        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }
        public string intSortNum { get; set; }
        public string VCHBUTTON1 { get; set; }

        public string VCHBUTTON2 { get; set; }

        public string VCHBUTTON3 { get; set; }

    }
}
