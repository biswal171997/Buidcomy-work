using BUIDCO.Domain.AdminConsole.UserHierarchy;
using System.Collections.Generic;
namespace BUIDCO.Repository.Contract.Contract.AdminConsole.UserHierarchy
{
    public interface IUserHierarchyServiceProvider
    {

        int GetHierarchyId(int intUserId);
        //List<UserHierarchyControl> BindLocation(UserHierarchyControl objUhier);
        //List<UserHierarchyControl> BindDropdownHierarchy();
        //int GetParentId(int intLvldtlId);
        //List<UserHierarchyControl> FillFirstHirarchy(UserHierarchyControl objUhier);
        //List<UserHierarchyControl> FillHierarchy(UserHierarchyControl objUhier);
        //string GetLevelName(UserHierarchyControl objUhier);
        //int GetHierLevelNo(int intLvldtlId);
        List<UserHierarchyControl> FillUser1(UserHierarchyControl objUhier);
        //List<UserHierarchyControl> FillUser2(UserHierarchyControl objUhier);
        //string FillLevelName(UserHierarchyControl objUhier);
        //string GetAdminUser(UserHierarchyControl objUhier);
        //List<UserHierarchyControl> TotalparentId(UserHierarchyControl objUhier);
        //List<UserHierarchyControl> LevelId(UserHierarchyControl objUhier);
        //List<UserHierarchyControl> FillFstHirarchy(UserHierarchyControl objUhier);
        //int GetPositionValue(int intLvlDtlId);
        //int GetParentIdForLvlDtls(int intLvlDtlId);
        List<UserHierarchyControl> BindGradeData(UserHierarchyControl objUhier);
        List<UserHierarchyControl> BindDesignationData(UserHierarchyControl objUhier);
        //int CountLevelid(int intLvlDtlId);
        //List<UserHierarchyControl> GetLevelNameUc2(int intLvlDtlId);
        List<UserHierarchyControl> FillLabelUser(int Parent, int Position);
        List<UserHierarchyControl> FillUserByDesig(int Loc, int Desig);
    }
}