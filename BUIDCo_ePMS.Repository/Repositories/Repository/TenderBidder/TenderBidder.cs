using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TenderBidder;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.TenderBidder
{
    public class TenderBidder: Db_BUIDCo_PMSRepositoryBase, ITenderBidder
    {
        public TenderBidder(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<List<ViewTenderBidderModelEF>> BidderDetailsById(int Id)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "B");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewTenderBidderModelEF>("USP_V_TENDER_BIDDER_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();

            }
            catch (Exception e) { throw; }
        }

        public async Task<int> DeleteBidders(TenderBidderModelEF model)
        {
            try
            {

               var P = new DynamicParameters();
                P.Add("P_Action", 'C');
                P.Add("P_tenderId", model.tenderId);
                P.Add("P_bidderID", 0);
                P.Add("P_projectId", 0);
                P.Add("P_BidderDetailsList", null);
                P.Add("p_createdBy", model.createdBy);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_BIDDER_DTLS", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);

            }
            catch (Exception e) { throw; }
        }

        public async Task<int> Save_Tender_Bidder_Dts(TenderBidderModelEF model)
        {
            try {
               
                var P = new DynamicParameters();
                if (model.bidderID > 0){
                    P.Add("P_Action", 'B');
                    P.Add("P_tenderId", model.tenderId);

                }
                else { 
                    P.Add("P_Action", 'A');
                    P.Add("P_tenderId", model.tenderId);
                }
                P.Add("P_bidderID", 0);
                P.Add("P_projectId", model.projectId);
                P.Add("P_BidderDetailsList", model.bidderDetailsList);
                P.Add("p_createdBy", model.createdBy);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_BIDDER_DTLS", P, commandType:CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);

            }
            catch(Exception e) { throw; }
        }

        public async Task<List<ViewTenderBidderModelEF>> ViewBidderDetails(ViewTenderBidderModelEF model)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "A");
                P.Add("INT_ID", 0);
                var result = await Connection.QueryAsync<ViewTenderBidderModelEF>("USP_V_TENDER_BIDDER_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            
            }catch(Exception e) { throw; }
        }
        public async Task<Projects> GetProjectDetailsById(int PId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                // p.Add("@P_PMT", null);
                p.Add("INT_ID", PId);
                var results = await Connection.QueryAsync<Projects>("USP_V_TENDER_BIDDER_DTLS", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
