using BUIDCo_ePMS.Model.Entities.AdministartiveApproval;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.AdministartiveApproval;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.AdministartiveApproval
{
    public class AdministartiveApproval : Db_BUIDCo_PMSRepositoryBase, IAdministartiveApproval
    {
        public AdministartiveApproval(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<List<AdminApprovalViewEF>> GetAARecords()
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<AdminApprovalViewEF>("USP_V_AA_Approval ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<int> SaveAADetails(AdminApprovalSaveEF TBL)
        {
            try
            {
                var p = new DynamicParameters();
               
                p.Add("@P_Action", TBL.Action);
                p.Add("@P_AAId", TBL.AAId);
                p.Add("@P_PROPOSALID", TBL.ProposalId);
                p.Add("@P_AALETTERPATH", TBL.AALetterPath);
                p.Add("@P_AALETTERNO", TBL.AALetterNo);
                p.Add("@P_AALETTERDATE", Convert.ToDateTime(TBL.AALetterDate));
                p.Add("@P_AASCHEMEID", TBL.AASchemeID);
                //p.Add("@P_AAAPPROVEDBY", "");
                //p.Add("@P_AASIGNEDDOCUMENT", TBL.AASignedDocumentPath);
                p.Add("@P_OTHERDOC", TBL.AAOtherDocuemntPath);
                p.Add("@P_IsMultipleProject", TBL.IsMultipleProject);
                p.Add("@P_AAPARTPROJECT", TBL.ProjectDetailsList); // Json Formate
                p.Add("@P_CREATEDBY", TBL.AACreatedBy);
                p.Add("@P_AAUploadRemarks", TBL.AARemarks);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_AA_Approval ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<AdminApprovalSaveEF> GetSavedTADetails(int ProposalId)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_INT_ID", ProposalId);
                var results = await Connection.QueryAsync<AdminApprovalSaveEF>("USP_V_AA_Approval ", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<List<DropdownList>> GetSchemeList()
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "R");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<DropdownList>("USP_Common_Provider ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
    }
}
