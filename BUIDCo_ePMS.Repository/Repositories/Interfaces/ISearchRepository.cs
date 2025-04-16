using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Model.Entities.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
    public interface ISearchRepository
    {
        Task<ProposalDetails> SearchProposal(Proposal obj);
    }
}
