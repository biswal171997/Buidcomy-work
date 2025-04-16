using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
    public interface IPreBidQueries
    {
        Task<List<PreBidQueriesModelEF>> ViewPreBidQueriesDetails(PreBidQueriesModelEF model);
        Task<int> Save_Tender_PreBidQueries(PreBidQueriesModelEF model);
        Task<PreBidQueriesModelEF> GetPreBidQueriesDetailsById(int Id);
        Task<int> DeletePreBidQueries(PreBidQueriesModelEF model);
    }
}
