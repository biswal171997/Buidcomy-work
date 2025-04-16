using BUIDCO.Domain.AdminConsole.LevelMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.LevelMaster
{
   public interface ILevelServiceProvider
    {
        string AddLevel(CreateLevelMaster objlevel);
        Task<CreateLevelMaster> GetAllLevelByHierarchyId(int id);
        Task<LevelMasterModel> GetAllLevel(int id);
        Task<IEnumerable<CreateLevelMaster>> GetLevelById(int id);
        string EditLevel(CreateLevelMaster objlevel);
        string MarkActive(LevelMasterModel objmodel);
        string MarkInactive(LevelMasterModel objmodel);
    }
}
