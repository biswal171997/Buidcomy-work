using BUIDCo_ePMS.Model.Entities.ProjectTender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.TechnicalBid
{
    public interface ITechnicalBid
    {
        Task<List<ViewProject_and_Bidders>> GetProject_and_Bidders(int Id);
        Task<int> Save_TechnicalBid(TechnicalBidModelEF model);
        Task<List<ViewTechnicalBidModelEF>> ViewtechnicalBid(ViewTechnicalBidModelEF model);
        Task<List<ViewTechnicalBidModelEF>> GettechnicalBidDetailsById(int Id);
        Task<int> DeleteTechnicalBid(TechnicalBidModelEF model);
        Task<List<ViewTechnicalBidModelEF>> EditTechnicalBidder(int Id);
    }
}
