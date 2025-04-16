using BUIDCO.Domain.AdminConsole.HierarchyMaster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.HierarchyMaster
{
    public interface IHierarchyServiceProvider
    {
        string AddHierarchy(Hierarchy objhierarchy);
        Task<HierarchyModel> GetAllHierarchy(int id);
        Task<IEnumerable<Hierarchy>> GetHierarchyById(int id);
        string EditHierarchy(Hierarchy objhierarchy);
        string MarkActive(Hierarchy objhierarchy);
        string MarkInactive(Hierarchy objhierarchy);
        Task<HierarchyModel> GetById(int id);
    }
}
