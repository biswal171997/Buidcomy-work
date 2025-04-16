using BUIDCo_ePMS.Model.Entities.TSApproval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.TSApproval
{
    public interface ITSApprovalRepository
    {
        Task<TSDetails> GetTSDetails(string searchtype);
        Task<int> UploadTSInformation(TSApprovalUpload obj);
        Task<TSApprovalUpload> GetTSApprovalByID(int Id);
        Task<int> GenerateTSLetter(TSApprovalUpload obj);
    }
}
