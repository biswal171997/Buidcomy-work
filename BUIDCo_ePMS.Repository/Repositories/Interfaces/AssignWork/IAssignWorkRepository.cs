using BUIDCo_ePMS.Model.Entities.AssignProjectWork;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
    public interface IAssignWorkRepository
    {
        Task<int> SaveAssignProject(AssignProject TBL);

        Task<List<ViewAssignProject1>> GetAssignProjectById(int Id);
        Task<List<AssignProject>> GetassignprojectList(AssignProject TBL);
        Task<List<AssignProject>> GetallAssignProject(AssignProject TBL);

        Task<List<ViewAssignProject>> GetallAssignProjectView(ViewAssignProject TBL);
        //Task<AssignProject> DeleteAssignProject(AssignProject TBL);
        Task<AssignProject> EditAssignProjectById(int Id);
        Task<string> DeleteAssignProject(int Id);
        public Task<List<AssignProject>> ViewDetails(int Id);
        Task<List<ViewBidderDetails>> GetAssignToList(int PId);
        Task<List<ViewBankComponent>> GetBankComponents(ViewBankComponent model);

    }
}
