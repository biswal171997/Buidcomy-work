using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.Entities.Proposal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
    public interface IProposalRepository
    {
        Task<int> SaveProposal(Proposal obj);
        Task<ProposalDetails> GetProposal(string searchtype);
        Task<Proposal> GetProposalByID(int Id);
        Task<int> SaveProposalSite(ProposalSite obj);
        Task<int> DeleteProposalSite(ProposalSite obj);
        Task<ProposalSite> GetProposalSiteByID(int Id);
        Task<int> SaveFDRDetails(ProposalFdr obj);
        Task<ProposalFdr> GetProposalFDRByID(int Id);
        Task<ProposalInformation> GetProposalInformationByID(int Id);
        Task<int> SubmitProposal(Proposal obj);
        Task<int> CancelProposal(Proposal obj);
    }
}
