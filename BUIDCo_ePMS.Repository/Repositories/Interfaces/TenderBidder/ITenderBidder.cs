using BUIDCo_ePMS.Model.Entities.ProjectTender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.TenderBidder
{
    public interface ITenderBidder
    {
        Task<int> Save_Tender_Bidder_Dts(TenderBidderModelEF model);
        Task<List<ViewTenderBidderModelEF>> ViewBidderDetails(ViewTenderBidderModelEF model);
        Task<List<ViewTenderBidderModelEF>> BidderDetailsById(int Id);
        Task<int> DeleteBidders(TenderBidderModelEF model);
        Task<Projects> GetProjectDetailsById(int PId);

    }
}
