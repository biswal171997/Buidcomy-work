using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.TAapproval;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.TAapproval;
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

namespace BUIDCo_ePMS.Repository.Repositories.Repository.TAapproval
{
    public class TAapprovalRepository : Db_BUIDCo_PMSRepositoryBase, ITAapproval
    {
        public TAapprovalRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }
        public async Task<List<TAViewEF>> GetTAapplicationDetails(TASearchEF obj)
        {

            try
            {
                var p = new DynamicParameters();
                if(obj.TAId >0)
                p.Add("@P_Action", "B");
                else
                    p.Add("@P_Action", "A");
                p.Add("@P_ProposalId", obj.ProposalId ?? 0);
                p.Add("@P_TAID", obj.TAId ?? 0);
                p.Add("@P_FyId", obj.fyId ?? 0);
                p.Add("@P_letterNo", obj.letterNo );
                p.Add("@P_submittedByid", obj.submittedByid ?? 0);
                p.Add("@P_categoryid", obj.categoryid ?? 0);
                p.Add("@P_subCategoryid", obj.subCategoryid ?? 0);
                p.Add("@P_projectTypeid", obj.projectTypeid ?? 0);
                p.Add("@P_districtid", obj.districtid ?? 0);
                p.Add("@P_ulbId", obj.ulbId ?? 0);






                p.Add("@P_CreatedBy", obj.CreatedBy ?? 0);

                var results = await Connection.QueryAsync<TAViewEF>("USP_V_TA_Approval ", p, commandType: CommandType.StoredProcedure);
                return results.ToList(); ;
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<int> SaveTAdetails(TAApprovalSave obj)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", obj.Action);
                p.Add("@P_TAID", obj.TAid);
                p.Add("@P_PROPOSALID", obj.ProposalID);
                p.Add("@P_TALETTERPATH", obj.TAletterPath);
                p.Add("@P_TALETTERNO", obj.TAletterNo);
                p.Add("@P_TALETTERDATE", obj.TAletterDate != null ? Convert.ToDateTime(obj.TAletterDate) : DBNull.Value);
                p.Add("@P_ESTIMATEDCOST", obj.EstimattedCost);
                p.Add("@P_NAZARIMAP", obj.NazariMap);
                p.Add("@P_DRAWINGPATH", obj.DrawingPath);
                p.Add("@P_OTHERDOC", obj.OtherDocPath);
                p.Add("@P_REMARKS", obj.Remarks);
                p.Add("@P_CREATEDBY", obj.Createdby);
                p.Add("@P_STATUS", obj.Status);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_TA_Approval ", p, commandType: CommandType.StoredProcedure);
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
