using System;
namespace BUIDCO.Domain.AdminConsole.Login
{
   
    public class Login
    {
       
        public string ActionCode { get; set; }
        
        public int GetID { get; set; }
       
        public int HID { get; set; }
       
        public int LevelId { get; set; }
       
        public string UserID { get; set; }
       
        public string UserName { get; set; }
       
        public string Password { get; set; }
       
        public string Type { get; set; }
       
        public string AdminPrev { get; set; }
       
        public string Security { get; set; }
       
        public string AccessLev { get; set; }
       
        public string SubAdminPrev { get; set; }
       
        public string FullName { get; set; }
       
        public string email { get; set; }
       
        public int DesigID { get; set; }
       
        public string DepartmentID { get; set; }
       
        public int Locid { get; set; }
       
        public string Locdiff { get; set; }
       
        public string Location { get; set; }
       
        public DateTime dtStartTime { get; set; }
       
        public DateTime dtEndTime { get; set; }
       
        public DateTime dtRecessFrom { get; set; }
       
        public DateTime dtRecessTo { get; set; }
       
        public int dtTimeZone { get; set; }
       
        public string DeptName { get; set; }
       
        public string DivName { get; set; }
       
        public string SecName { get; set; }
       
        public string DepttName { get; set; }
       
        public string DivvName { get; set; }
       
        public string DivisionName { get; set; }
       
        public string strDepartment { get; set; }
       
        public string strPID { get; set; }
       
        public int maxVal { get; set; }
       
        public string InTime { get; set; }
       
        public string IpAddress { get; set; }
    }
   
    public class IPTrack
    {
       
        public string ActionCode { get; set; }
       
        public int Id { get; set; }
       
        public int UserId { get; set; }
       
        public string UserName { get; set; }
       
        public string IpAddress { get; set; }
       
        public string LoginDatetime { get; set; }
       
        public string LogoutDatetime { get; set; }
       
        public int CreatedBy { get; set; }
    }
}