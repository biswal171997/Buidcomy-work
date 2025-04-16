using BUIDCO.Domain.AdminConsole.CommonFunction;
using System.Collections.Generic;
namespace BUIDCO.Repository.Contract.Contract.AdminConsole.CommonFunction
{
    public interface ICommonFunServiceProvider
    {
         //IList<CommonFun> GetPoId(int intLvlDtlId);
         //IList<CommonFun> GetPrntId(int intLvlDtlId);
         //IList<CommonFun> fillDropdown(int intparentId);
         //IList<CommonFun> GetLevelNames(int intDepartmentId);
         //IList<CommonFun> FillControls(int intDepartmentId);
         //IList<CommonFun> popuplocation(CommonFun ObjComnFun);
         //IList<CommonFun> intHierachyLevel(int intUserId);
         //IList<CommonFun> GetUserLocation(int userId);
         //IList<CommonFun> GetUserLogFlag(int intUserId);
         //IList<CommonFun> CreateHierarchyXml(CommonFun ObjComnFun);
         IList<CommonFun> GetLocationAdminiStrator(int intLvlDtlId);
         string GetUserAccess(int intUserId);
    }
}