using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.Entities.Processflow;
using BUIDCo_ePMS.Model.M_Financial_Year;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.Processflow
{
    public interface IProcessflowRepository
    {
        Task<IEnumerable<ProcessflowModel>> GetAllPages();
        Task<List<ProcessflowModel>> GetallUser();
        Task<List<ProcessflowModel>> GetallDesignation();

        Task<IEnumerable<ProcessflowModel>> GetalldataviewPages();
        Task<List<ProcessflowModel>> GetProcessById(int INTPLINKID);
        Task<int> DeleteProcessById(int APCID);

        // Task<IEnumerable<ProcessflowModel>> GetProcessById(INTPLINKID); 
        Task<int> DeleteProcessAsync(ProcessflowModel process);
        Task<int> AddProcessAsync(ProcessflowModel process);
    }
}
