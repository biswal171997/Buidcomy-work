using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TechnicalBid;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.TechnicalBid
{
    public class TechnicalBid : Db_BUIDCo_PMSRepositoryBase, ITechnicalBid
    {
        public TechnicalBid(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<int> DeleteTechnicalBid(TechnicalBidModelEF model)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "C");
                P.Add("P_ID", model.ID);
                P.Add("P_tenderId", 0);
                P.Add("P_projectId", 0);
                P.Add("P_technicalStatus", 0);
                P.Add("P_technicalDocPath", null);
                P.Add("P_financialDocPath", null);
                P.Add("P_finanicalDate", null);
                P.Add("P_technicalDate", null);
                P.Add("P_vchBidderID", null);
                P.Add("P_createdBy", model.createdBy);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_TECHNICAL", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch(Exception e) { throw; }
        }

        public async Task<List<ViewTechnicalBidModelEF>> EditTechnicalBidder(int Id)
        {

            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "D");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewTechnicalBidModelEF>("USP_V_PROJECT_TENDER_TECHNICAL", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception e) { throw; }
        }

        public async Task<List<ViewProject_and_Bidders>> GetProject_and_Bidders(int Id)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "A");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewProject_and_Bidders>("USP_V_PROJECT_TENDER_TECHNICAL", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }catch(Exception e) { throw; }
        }

        public async Task<List<ViewTechnicalBidModelEF>> GettechnicalBidDetailsById(int Id)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action","C");
                P.Add("INT_ID",Id);
                var result = await Connection.QueryAsync<ViewTechnicalBidModelEF>("USP_V_PROJECT_TENDER_TECHNICAL", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch(Exception e) { throw; }
        }

        public async Task<int> Save_TechnicalBid(TechnicalBidModelEF model)
        {
            try {
                var P = new DynamicParameters();
                if (model.ID > 0)
                {
                    P.Add("P_Action","B");
                    P.Add("P_ID", model.ID);
                }
                else
                {
                    P.Add("P_Action", "A");
                    P.Add("P_ID", 0);
                }
                P.Add("P_tenderId",model.tenderId);
                P.Add("P_projectId",model.projectId);
                P.Add("P_technicalStatus",model.technicalStatus);
                P.Add("P_technicalDocPath",model.technicalDocPath);
                P.Add("P_financialDocPath",model.financialDocPath);
                if (model.finanicalDate != "null")
                {
                    P.Add("P_finanicalDate", Convert.ToDateTime(model.finanicalDate));
                }
                else
                {
                    model.finanicalDate = null;
                    P.Add("P_finanicalDate", model.finanicalDate);
                }
                if (model.technicalDate != "null")
                {
                    P.Add("P_technicalDate", Convert.ToDateTime(model.technicalDate));
                }
                else
                {
                    model.technicalDate = null;
                    P.Add("P_technicalDate", model.technicalDate);
                }
                P.Add("P_vchBidderID",model.vchBidderID);
                P.Add("P_createdBy",model.createdBy);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_TECHNICAL", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch(Exception e) { throw; }
        }

        public async Task<List<ViewTechnicalBidModelEF>> ViewtechnicalBid(ViewTechnicalBidModelEF model)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", 'B');
                P.Add("INT_ID", 0); 
                var result = await Connection.QueryAsync<ViewTechnicalBidModelEF>("USP_V_PROJECT_TENDER_TECHNICAL", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }catch(Exception e) { throw; }
        }
    }
}
