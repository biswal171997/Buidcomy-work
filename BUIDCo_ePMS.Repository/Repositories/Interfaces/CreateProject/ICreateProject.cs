using BUIDCo_ePMS.Model.Entities.CreateProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.CreateProject
{
    public interface ICreateProject
    {
        Task<ProposalDetail> GetProposalDetails(int ProposalId);

        Task<List<ProposalList>> BindLetterNoAndSubject(ProposalList TBL);

        Task<int> SaveProjectDetails(ProjectDetail TBL);
        Task<int> DeleteProjectDetails(ProjectDetail TBL);

        Task<List<ProjectViewEF>> GetCreatedProjectRecord();
        Task<ProjectSavedDetail> GetSubmittedProjectDetails(int ProjectId);
    }
}
