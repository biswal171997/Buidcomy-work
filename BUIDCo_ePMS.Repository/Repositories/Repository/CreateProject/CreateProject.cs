using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.CreateProject;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.CreateProject
{
    public class CreateProject : Db_BUIDCo_PMSRepositoryBase,ICreateProject
    {
        public CreateProject(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<ProposalDetail> GetProposalDetails(int ProposalId)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_INT_ID", ProposalId);
                var results = await Connection.QueryAsync<ProposalDetail>("USP_V_CREATE_PROJECT ", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<List<ProposalList>> BindLetterNoAndSubject(ProposalList TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "H");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<ProposalList>("USP_Common_Provider ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<int> SaveProjectDetails(ProjectDetail TBL)
        {
            try
            {
                var p = new DynamicParameters();
                if (TBL.ProjectId == 0)
                {
                    p.Add("@P_Action", "A");
                    p.Add("@P_projectId", 0);
                }
                else
                {
                    p.Add("@P_Action", "B");
                    p.Add("@P_projectId", TBL.ProjectId);
                }
                p.Add("@P_proposalId", TBL.ProposalId);
                p.Add("@P_projectName", TBL.ProjectName);
                p.Add("@P_estimatedAmount", TBL.EstimatedAmount);
                p.Add("@P_areaOfConstruction", TBL.AreaOfConstruction);
                p.Add("@P_length", TBL.Length);
                p.Add("@P_createdBy", TBL.CreatedBy);
                p.Add("@P_reviseUpdatedAmount", TBL.ReviseUpdatedAmount);
                p.Add("@P_reviseAmountDocpath", TBL.ReviseAmountDocpath);
                p.Add("@P_reviseAmountRemarks", TBL.ReviseAmountRemarks);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_CREATE_PROJECT ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<int> DeleteProjectDetails(ProjectDetail TBL)
        {
            try
            {
                var p = new DynamicParameters();
                
                p.Add("@P_Action", "C");
                p.Add("@P_projectId", TBL.ProjectId);
                p.Add("@P_proposalId", TBL.ProposalId);
                p.Add("@P_projectName", TBL.ProjectName);
                p.Add("@P_estimatedAmount", TBL.EstimatedAmount);
                p.Add("@P_areaOfConstruction", TBL.AreaOfConstruction);
                p.Add("@P_length", TBL.Length);
                p.Add("@P_createdBy", TBL.CreatedBy);
                p.Add("@P_reviseUpdatedAmount", TBL.ReviseUpdatedAmount);
                p.Add("@P_reviseAmountDocpath", TBL.ReviseAmountDocpath);
                p.Add("@P_reviseAmountRemarks", TBL.ReviseAmountRemarks);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_CREATE_PROJECT ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ProjectViewEF>> GetCreatedProjectRecord()
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<ProjectViewEF>("USP_V_CREATE_PROJECT ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<ProjectSavedDetail> GetSubmittedProjectDetails(int ProjectId)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_INT_ID", ProjectId);
                var results = await Connection.QueryAsync<ProjectSavedDetail>("USP_V_CREATE_PROJECT ", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
    }
}
