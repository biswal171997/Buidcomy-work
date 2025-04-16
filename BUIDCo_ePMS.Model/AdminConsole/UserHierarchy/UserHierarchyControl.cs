
namespace BUIDCO.Domain.AdminConsole.UserHierarchy
{
    
    public class UserHierarchyControl
    {
      
        public int UserId { get; set; }
      
        public int HierarchyId { get; set; }
      
        public int LevelDetailId { get; set; }
      
        public string LevelDetailName { get; set; }
      
        public int ParentId { get; set; }
      
        public string ActionCode { get; set; }
      
        public int StatusFlag { get; set; } 
      
        public string UserName { get; set; }
      
        public string LevelName { get; set; }
      
        public string Symbol { get; set; }
      
        public int GradeId { get; set; }
      
        public string GradeName { get; set; }
      
        public int DesigId { get; set; }
      
        public string DesigName { get; set; }
    }
}