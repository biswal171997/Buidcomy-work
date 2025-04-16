using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.LevelDetailsMaster
{
    public interface ILevelDetailsServiceProvider
    {
        string AddLevelDetails(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster objlevel);
        Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetAllLevelDetailsByHierarchyId(int id);
        Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetAllLevelParentDetailsByHierarchyId(int id, int hid);
        Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetLevelByParentId(int id);
        Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetAllLevelDetailsForEdit();
        Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMasterModel> GetAllLevelDetails(int id);
        Task<IEnumerable<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster>> GetLevelDetailsById(int id);
        string EditLevelDetails(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster objlevel);
        string MarkActive(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMasterModel objmodel);
        string MarkInactive(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMasterModel objmodel);
        Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetHierarchy();
    }
}
