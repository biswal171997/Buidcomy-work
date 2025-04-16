using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace BUIDCO.Domain.AdminConsole.Manage_Level
{
   
    public class Level
    {
       
        public int LeveldetailsID { get; set; }
       
        public int Parentid { get; set; }
       
        public int Levelid { get; set; }
       
        public string LevelName { get; set; }
       
        public int CreatedBy { get; set; }
       
        public string AdminUserID { get; set; }
       
        public string ActionCode { get; set; }
       
        public string Address { get; set; }
       
        public string TelNo { get; set; }
       
        public string FaxNo { get; set; }
       
        public string Strflag { get; set; }
       
        public string DISECode { get; set; }

        //variables created by Subrat Acharya
        //modified date-03-Aug-2010
        //Descripion these variables are required for xml file generation
       
        public string LocId { get; set; }
       
        public string LocName { get; set; }
       
        public string DivId { get; set; }
       
        public string DivName { get; set; }
       
        public string DeptId { get; set; }
       
        public string DeptName { get; set; }
       
        public string AdminUserName { get; set; }
       
        public string AdminUserFullName { get; set; }
       
        public string SecId { get; set; }
       
        public string SecName { get; set; }
       
        public string UserName { get; set; }
       
        public string UserId { get; set; }
       
        public string UserFullName { get; set; }
       
        public string LayerOne { get; set; }
       
        public string LayerTwo { get; set; }
    }
}