using BUIDCo_ePMS.Model.Entities.ProjectTender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.FinancialBid
{
    public interface IFinancialBid
    {
        Task<List<ViewFinancialBidModelEF>> GetBidders(int Id);
        Task<int> SaveFinancialBid(FinancialBidModel model);
        Task<List<ViewProject_and_Bidders>> GetProjectDetails(int Id);
        Task<List<ViewFinancialBidModelEF>> ViewFinancialBid(ViewFinancialBidModelEF model);
        Task<List<ViewFinancialBidModelEF>> EditFinancialBid(int Id);
        Task<int> DeleteFinancialBid(FinancialBidModel model);
        Task<List<ViewFinancialBidModelEF>> ViewFinancialDetails(int Id);
     
    }
}
