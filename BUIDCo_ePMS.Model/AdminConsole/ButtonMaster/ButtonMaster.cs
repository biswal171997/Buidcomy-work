using BUIDCO.Domain.AdminConsole.Function_Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Domain.AdminConsole.ButtonMaster
{
    public class Button_Master
    {
        public string? ActionCode { get; set; }
        public int? INTBUTTONID { get; set; }
        public int? MAxid { get; set; }
        public int? INTFUNCTIONID { get; set; }

        public string? VCHFUNCTION { get; set; }
        public string? NVCHBUTTON { get; set; }
        public string? VCHURL { get; set; }

        public string? NVCHDESCRIPTION { get; set; }
        public string? FView { get; set; }

        public string? FAdd { get; set; }

        public string? FManage { get; set; }
        public string? VCHBUTTON1 { get; set; }

        public string? VCHBUTTON2 { get; set; }

        public string? VCHBUTTON3 { get; set; }


        public int? INTCREATEDBY { get; set; }
        public int? INTUPDATEDBY { get; set; }
        public string? intSortNum { get; set; }
        public int? BintSortNum { get; set; }
        public int? BMAxid { get; set; }
    }
    public class CreateButtonMaster
    {
        public string? ActionCode { get; set; }
        public int? INTBUTTONID { get; set; }

        public int? INTFUNCTIONID { get; set; }
       
        public string? NVCHBUTTON { get; set; }
        public string? VCHURL { get; set; }

        public string? NVCHDESCRIPTION { get; set; }
        public string? FView { get; set; }

        public string? FAdd { get; set; }

        public string? FManage { get; set; }
        public int? INTCREATEDBY { get; set; }
        public int? INTUPDATEDBY { get; set; }
        public string? intSortNum { get; set; }
        public string? VCHBUTTON1 { get; set; }

        public string? VCHBUTTON2 { get; set; }

        public string? VCHBUTTON3 { get; set; }

        public int? BintSortNum { get; set; }
        public int? BMAxid { get; set; }
        public List<FunctionMaster>? FunctionList { get; set; }
        public List<Button_Master>? ButtonList { get; set; }
        public List<CreateButtonMaster>? ButtonModelList { get; set; }
    }

    public class ViewButtonLink
    {
        public List<CreateButtonMaster>? ViewButtonLinkDetails { get; set; }
    }
   
    public class ButtonMasterModel
    {

        public List<FunctionMaster>? FunctionList { get; set; }
        public List<Button_Master>? ButtonList { get; set; }

        public CreateButtonMaster? ButtonModelIdwise { get; set; }
        public List<CreateButtonMaster>?  ButtonModelList { get; set; }

        public int? FunctionId { get; set; }
        
        public int? INTFUNCTIONID { get; set; }
      
        public int? INTBUTTONID { get; set; }
        public int? INTUPDATEDBY { get; set; }
    }
}
