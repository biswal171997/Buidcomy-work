using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.TakeAction;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TAapproval;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TakeAction;
using Azure;
using BUIDCo_ePMS.Model.Entities.TAapproval;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.TakeAction
{
    public class TakeActionRepository : Db_BUIDCo_PMSRepositoryBase, ITakeAction
    {
        public TakeActionRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }
        public async Task<TakeActionDetails> GetActionPageDetails(TakeActionSearch obj)
        {

            try
            {
                var p = new DynamicParameters();


                p.Add("@P_Action", "A");
                p.Add("@P_ProposalId", obj.ProposalId ?? 0);
                using (var multi = await Connection.QueryMultipleAsync("USP_V_TAKEACTION", p, commandType: CommandType.StoredProcedure))
                {
                    var response = new TakeActionDetails();
                    response.Proposal = await multi.ReadFirstOrDefaultAsync<ProposalDetails>();
                    response.DPR = await multi.ReadFirstOrDefaultAsync<DPRDetails>();
                    response.ProjectSite= (await multi.ReadAsync<ProjectSiteDetails>()).ToList();
                    response.TAdata= await multi.ReadFirstOrDefaultAsync<TADetails>();
                    response.AAdata = await multi.ReadFirstOrDefaultAsync<AADetails>();
                    return response;
                }


            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<int> SaveTakeAction(TakeActionSave obj)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_ProposalId", obj.ProposalId);
                p.Add("@P_Moduleid", obj.ModuleId);
                p.Add("@P_Status", obj.Status);
                p.Add("@P_Remarks", obj.Remarks );
                p.Add("@P_vchDoc", obj.docPath);
                p.Add("@P_createdBy", obj.CreatedBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_TakeAction ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);

                //p.Add("@P_INT_ID", ProposalId);

            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
    }
}
