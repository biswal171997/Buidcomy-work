using BUIDCO.Domain.AdminConsole.Location_Admin;
using System.Collections.Generic;
namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Location_Admin
{
    public interface ILocAdmin
    {
       int AddLocationAdmin(LocAdmin objLocAdmin);
       IList<LocAdmin> FillLocationAssignAdmin(string UserId);
    }
}