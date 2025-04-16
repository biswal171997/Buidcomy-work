namespace BUIDCO.Domain.AdminConsole.Location_Admin
{
    
    public class LocAdmin
    {
        
        public string ActionCode { get; set; }
        
        public int AssigniD { get; set; }
        
        public int intHierarchyID { get; set; }
        
        public int Levelid { get; set; }
        public int intLevelDetailId { get; set; }

        public int LocationID { get; set; }
        
        public string LocationName { get; set; }
        
        public int DepartmentId { get; set; }
        
        public string DepartMentName { get; set; }
        
        int DivisionId { get; set; }
        
        public string DivisionName { get; set; }
        
        public string UserID { get; set; }
        
        public string UserName { get; set; }
        
        public int CreatedBy { get; set; }
    }
}