using BUIDCO.Domain.AdminConsole.ButtonMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Domain.AdminConsole.TabMaster
{
    public class Tab_Master
    {
        public string? ActionCode { get; set; }
        public int? INTTABID { get; set; }
        public int? MAxid { get; set; }
        public int? INTBUTTONID { get; set; }

        public string? NVCHBUTTON { get; set; }
        public string? NVCHTAB { get; set; }
        public string? VCHURL { get; set; }
        public string? FView { get; set; }

        public string? FAdd { get; set; }

        public string? FManage { get; set; }
        public string? NVCHDESCRIPTION { get; set; }
        public string? VCHBUTTON1 { get; set; }

        public string? VCHBUTTON2 { get; set; }

        public string? VCHBUTTON3 { get; set; }
        public int? INTCREATEDBY { get; set; }
        public int? INTUPDATEDBY { get; set; }
        public string? intSortNum { get; set; }
        public int TintSortNum { get; set; }
        public int TMAxid { get; set; }
    }
    public class CreateTabMaster
    {
        public string? ActionCode { get; set; }
        public int? INTTABID { get; set; }

        public int? INTBUTTONID { get; set; }
        
        public string? NVCHBUTTON { get; set; }
        public string? FView { get; set; }

        public string? FAdd { get; set; }

        public string? FManage { get; set; }
        public string? NVCHTAB { get; set; }
        public string? VCHURL { get; set; }
        public string? VCHBUTTON1 { get; set; }

        public string? VCHBUTTON2 { get; set; }

        public string? VCHBUTTON3 { get; set; }
        public string? NVCHDESCRIPTION { get; set; }

        public int? INTCREATEDBY { get; set; }
        public int? INTUPDATEDBY { get; set; }
        public string? intSortNum { get; set; }
        //public int BMAxid { get; set; }
        public int? TintSortNum { get; set; }
        public int? TMAxid { get; set; }
        public List<Button_Master>? ButtonList { get; set; }
        public List<Tab_Master>? TabList { get; set; }
        public List<CreateTabMaster>? TabModelList { get; set; }

    }
    public class ViewTabLink
    {
        public List<CreateTabMaster>?ViewTabLinkDetails { get; set; }
    }

    public class TabMasterModel
    {

        public List<Button_Master>? ButtonList { get; set; }
        public List<Tab_Master>? TabList { get; set; }

        public int? INTBUTTONID { get; set; }

        public CreateTabMaster ?TabModelIdwise { get; set; }
        public List<CreateTabMaster>? TabModelList { get; set; }

        public int? INTTABID { get; set; }
        public int? INTUPDATEDBY { get; set; }
    }
}
