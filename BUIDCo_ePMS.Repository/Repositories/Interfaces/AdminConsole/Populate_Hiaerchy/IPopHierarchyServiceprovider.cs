using BUIDCO.Domain.AdminConsole.Populate_Hiaerchy;
using System.Collections.Generic;
namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Populate_Hiaerchy
{
    public interface IPopHierarchyServiceprovider
    {
        //public abstract int GetPOSId(PopHierarchy objPopHier);
        //public abstract IList<PopHierarchy> FillLabel(PopHierarchy objPopHier);
       IList<PopHierarchy> FillLocation(PopHierarchy objPopHier);
        //public abstract IList<PopHierarchy> FillFirstHierchy1(int intCID, int HiracrcyId, int LID);
       IList<PopHierarchy> FillFirstHierchy2(int Parent);
        //public abstract IList<PopHierarchy> FillHierchy1(int intCID, int HiracrcyId);
       IList<PopHierarchy> FillHierchy2(int HiracrcyId,int Parent);
        //public abstract IList<PopHierarchy> FillUser(int DeptId);
        //public abstract string GetLevel(int Parent, int Levelid);
        //public abstract IList<PopHierarchy> FillLevelFromParent(int Parent);
        
        
    }
}