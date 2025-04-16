using BUIDCO.Domain.AdminConsole.DesignationMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.DesignationMaster
{
    public interface IDesignationServiceProvider
    {
        string AddDesignation(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model);
        Task<DesignationMasterModel> GetAllDesgination(int id);
        //Task<IEnumerable<Hierarchy>> GetHierarchyById(int id);
        string EditDesignation(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model);
        string MarkActive(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model);
        string MarkInactive(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model);
        Task<DesignationMasterModel> GetById(int id);
    }
}
