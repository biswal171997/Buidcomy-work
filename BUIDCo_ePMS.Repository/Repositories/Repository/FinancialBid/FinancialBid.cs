using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.FinancialBid;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.FinancialBid
{
    public class FinancialBid : Db_BUIDCo_PMSRepositoryBase, IFinancialBid
    {
        public FinancialBid(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<int> DeleteFinancialBid(FinancialBidModel model)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "C");
                P.Add("P_ID", model.ID);
                P.Add("P_financialID", 0);
                P.Add("P_technicalStatus", 0);
                P.Add("P_createdBy", 0);
                P.Add("P_tenderId", 0);
                P.Add("P_projectId", 0);
                P.Add("P_FinancialList", null);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception e) { throw; }
        }

        public async Task<List<ViewFinancialBidModelEF>> EditFinancialBid(int Id)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "D");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewFinancialBidModelEF>("USP_V_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception e) { throw; }
        }

        public async Task<List<ViewFinancialBidModelEF>> GetBidders(int Id)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action","A");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewFinancialBidModelEF>("USP_V_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch(Exception e) { throw; }
        }

        public async Task<List<ViewProject_and_Bidders>> GetProjectDetails(int Id)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "C");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewProject_and_Bidders>("USP_V_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception e) { throw; }
        }

        public async Task<int> SaveFinancialBid(FinancialBidModel model)
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
                P.Add("P_financialID", model.financialID);
                P.Add("P_technicalStatus", model.technicalStatus);
                P.Add("P_createdBy",model.createdBy);
                P.Add("P_tenderId", model.tenderId);
                P.Add("P_projectId", model.projectId);
                P.Add("P_FinancialList", model.JsonFinancialList);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch(Exception e) { throw; }
        }

        public async Task<List<ViewFinancialBidModelEF>> ViewFinancialBid(ViewFinancialBidModelEF model)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "B");
                P.Add("INT_ID", 0);
                var result = await Connection.QueryAsync<ViewFinancialBidModelEF>("USP_V_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception e) { throw; }
        }

        public async Task<List<ViewFinancialBidModelEF>> ViewFinancialDetails(int Id)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "E");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<ViewFinancialBidModelEF>("USP_V_TENDER_FINANCIAL_DTLS", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception e) { throw; }
        }
    }
}
