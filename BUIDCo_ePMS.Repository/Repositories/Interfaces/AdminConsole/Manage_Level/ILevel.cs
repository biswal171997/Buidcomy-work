using BUIDCO.Domain.AdminConsole.Manage_Level;
using System.Collections.Generic;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Manage_Level
{
    public interface ILevel
    {
        //public abstract int AddLevelDetails(Level objLevelDetails);
        //public abstract int EditLevelDetails(Level objLevelDetails);
        //public abstract int DeleteLevelDetails(Level objLevelDetails);
        //public abstract IList<Level> GetAllLevelDetails(Level objLevelDetails);
        //public abstract IList<Level> GetLevelDetailsById(Level objLevelDetails);

        ////method created by subrat acharya for XML file generation
        //public abstract IList<Level> GetLocationDetails(Level objLevelDetails);
        //public abstract IList<Level> GetDivisionDetails(Level objLevelDetails, string LocID);
        //public abstract IList<Level> GetDepartmentDetails(Level objLevelDetails, string DivID);
        //public abstract IList<Level> GetSectionDetails(Level objLevelDetails, string DepID);
        //public abstract IList<Level> GetUserDetails(Level objLevelDetails, string SecID);
        //public abstract IList<Level> GetAdminUserFullName(Level objLevelDetails, string userid);
        //public abstract IList<Level> FillHierachyControl();
        //public abstract IList<Level> FillHierachyControl2(int Parent);
        //public abstract IList<Level> FillLevelGrid(Level objLevelDetails);
         IList<Level> GetAllHierarchyParents(Level objLevelDetails);
    }
}