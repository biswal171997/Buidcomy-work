using System.Collections.Generic;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Set_Permission
{
    public interface ISetPermission
    {
         int AddPermission(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetPermission);
          IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> GetPermissionOfPerticularUser(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetPermission);
          string UpdateGroupPermission(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetGrpPermission);
       // public abstract int UpdatePermission(Set_Permission objSetPermission);
        //public abstract string GetUserID(string searchText);
        //IList<Set_Permission> GetUserList(string strUserName);
        //public abstract IList<Set_Permission> GetPermissionUsers(Set_Permission objSetPermission);
       // public abstract List<string> getAllUserList(string strUserName);
       // public abstract IList<Set_Permission> GetAllusers_Assignlink(string strGrUID,string strGrDeptID);
    }
}