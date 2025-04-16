using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository
{
    public class PreBidQueries : Db_BUIDCo_PMSRepositoryBase,IPreBidQueries
    {
        public PreBidQueries(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<int> DeletePreBidQueries(PreBidQueriesModelEF model)
        {  try
            {
                var P = new DynamicParameters();
                P.Add("P_Action", "C");
                P.Add("P_Id", model.Id);
                P.Add("P_projectId", 0);
                P.Add("P_tenderId", 0);
                P.Add("P_preBidexcelDoc",null);
                P.Add("P_preBidpdfDoc", null);
                P.Add("P_createdBy", model.createdBy);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_PREBID", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception e) { throw; }
        }

        public async Task<PreBidQueriesModelEF> GetPreBidQueriesDetailsById(int Id)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "B");
                P.Add("INT_ID", Id);
                var result = await Connection.QueryAsync<PreBidQueriesModelEF>("USP_V_PROJECT_TENDER_PREBID", P, commandType: System.Data.CommandType.StoredProcedure);
                return result.FirstOrDefault()!;
            }
            catch(Exception e) { throw; }
        }

        public async Task<int> Save_Tender_PreBidQueries(PreBidQueriesModelEF model)
        {
            try {
                var P = new DynamicParameters();
                if (model.Id > 0)
                {
                    P.Add("P_Action", "B");
                    P.Add("P_Id", model.Id);
                }
                else
                {
                    P.Add("P_Action", "A");
                    P.Add("P_Id", 0);
                }
                P.Add("P_projectId",model.projectId);
                P.Add("P_tenderId",model.tenderId);
                P.Add("P_preBidexcelDoc", model.preBidexcelDoc);
                P.Add("P_preBidpdfDoc", model.preBidpdfDoc);
                P.Add("P_createdBy",model.createdBy);
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_PREBID", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch(Exception e) { throw; }
        }

        public async Task<List<PreBidQueriesModelEF>> ViewPreBidQueriesDetails(PreBidQueriesModelEF model)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "A");
                P.Add("INT_ID", 0);
                var result = await Connection.QueryAsync<PreBidQueriesModelEF>("USP_V_PROJECT_TENDER_PREBID", P, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }catch(Exception e) { throw; }
        }
    }
}
