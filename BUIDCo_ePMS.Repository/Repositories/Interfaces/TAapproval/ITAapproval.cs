using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Model.Entities.TAapproval;
using BUIDCo_ePMS.Model.M_Assembly_Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.TAapproval
{
    public interface ITAapproval
    {
        Task<List<TAViewEF>>  GetTAapplicationDetails(TASearchEF obj);
        Task<int> SaveTAdetails(TAApprovalSave TBL);
    }
}
