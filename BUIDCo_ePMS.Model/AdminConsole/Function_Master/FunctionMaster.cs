
using System.Collections.Generic;

namespace BUIDCO.Domain.AdminConsole.Function_Master
{
    
    public class FunctionMaster
    {
        
        public string? ActionCode { get; set; }
        
        public string? Add { get; set; }
        
        public int? CreatedBy { get; set; }
        
        public string? Description { get; set; }
        
        public string? FileName { get; set; }
        
        public int? Flag { get; set; }
        
        public int? FreeBees { get; set; }
        
        public string? FunctionId { get; set; }
        
        public string? FunctionName { get; set; }
        public int? INTFUNCTIONID { get; set; }

        public string? VCHFUNCTION { get; set; }
        public int? MailR { get; set; }
        
        public string? Notification { get; set; }
        
        public string? Manage { get; set; }
        
        public string? PortletFile { get; set; }
        
        public string? View { get; set; }

        
        public string? FView { get; set; }
        
        public string? FAdd { get; set; }
        
        public string? FManage { get; set; }
        
        public int? RowNo { get; set; }
        public int? NewTab { get; set; }
        public string? FNtab { get; set; }

    }
    public class FunctionModel
    {
        public List<FunctionMaster> ? FunctionList { get; set; }
    }
}