using BUIDCo_ePMS.Model.Entities.AdministartiveApproval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.AdministartiveApproval
{
    public interface IAdministartiveApproval
    {
        Task<List<AdminApprovalViewEF>> GetAARecords();

        Task<int> SaveAADetails(AdminApprovalSaveEF TBL);

        Task<AdminApprovalSaveEF> GetSavedTADetails(int ProposalId);
        Task<List<DropdownList>> GetSchemeList();
    }
}
