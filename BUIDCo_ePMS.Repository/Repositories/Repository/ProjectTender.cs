using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository
{
    public class ProjectTender : Db_BUIDCo_PMSRepositoryBase, IProjectTender
    {
        public ProjectTender(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<int> DeleteCorrigeduma_Addedum(int Id)
        {
            try
            {
                var P = new DynamicParameters();
                P.Add("p_Action", 'C');
                P.Add("P_corrigendumId", Id);
                P.Add("P_tenderId", 0);
                P.Add("P_projectId", 0);
                P.Add("P_corrigendumType", 0);
                P.Add("P_corrigendumDate",null);
                P.Add("P_approveBy",0 );
                P.Add("P_corrigendumFileName",null);
                P.Add("P_createdBy", 1);
                P.Add("P_CorrigendumList",null); 
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_CORRIGENDUM", P, commandType: CommandType.StoredProcedure);
                string result = P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception e) { throw; }
        }

        public async Task<int> DeleteProjectTender(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_tenderId", Id);
                p.Add("@P_projectId", 0);
                p.Add("@P_tenderNo", null);
                p.Add("@P_tenderSubject", null);
                p.Add("@P_publishedDate", null);
                p.Add("@P_openingDate", null);
                p.Add("@P_submissionDate", null);
                p.Add("@P_emdAmount", 0);
                p.Add("@P_processingFee", 0);
                p.Add("@P_nitDocFileName", 0);
                p.Add("@P_createdBy", 1);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_PROJECT_TENDER ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<VewProjectTenderCorrigendumEF> EditCorrigendumAddendum(int Id)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "D");
                P.Add("P_INT_Id", Id);
                var result = await Connection.QueryAsync<VewProjectTenderCorrigendumEF>("USP_V_PROJECT_TENDER_CORRIGENDUM", P, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault()!;
            }
            catch(Exception e) { throw; }
        }

        public async Task<ViewProjectTenderEF> Edit_GetTenderDetailsById(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "D");
                p.Add("@P_PMT", Convert.ToInt32(Id));
                p.Add("@P_projectId", 0);
                var results = await Connection.QueryAsync<ViewProjectTenderEF>("USP_V_PROJECT_TENDER", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ViewCorrigendumAddendumDetailsEF>> GetCorrigendumAddendumDetails(int INT_ID)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_INT_Id", INT_ID);
                var results = await Connection.QueryAsync<ViewCorrigendumAddendumDetailsEF>("USP_V_PROJECT_TENDER_CORRIGENDUM", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<Projects>> GetProject(string VCH_PRO)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_PMT", VCH_PRO);
                p.Add("@P_projectId", 0);
                var results = await Connection.QueryAsync<Projects>("USP_V_PROJECT_TENDER", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<Projects> GetProjectDetailsById(int PId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_PMT", null);
                p.Add("@P_projectId", PId);
                var results = await Connection.QueryAsync<Projects>("USP_V_PROJECT_TENDER", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ViewProjectTenderEF>> GetProjectTenderDetails(ViewProjectTenderEF model)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_PMT",null);
                p.Add("@P_projectId", 0);
                var results = await Connection.QueryAsync<ViewProjectTenderEF>("USP_V_PROJECT_TENDER ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<UserMasterModelEF>> GetUserName(UserMasterModelEF model)
        {
            try {

                var P = new DynamicParameters();
                P.Add("@P_Action",'A');
                P.Add("P_INT_Id", 0);
               var Result= await Connection.QueryAsync<UserMasterModelEF>("USP_V_PROJECT_TENDER_CORRIGENDUM", P, commandType: CommandType.StoredProcedure);
                return Result.ToList();
            }catch(Exception e) { throw; }
        }

        public async Task<int> SaveProjectTender(ProjectTenderEF TBL)
        {
                try
                {
                    var p = new DynamicParameters();
                    if (TBL.tenderId == 0)
                    {
                        p.Add("@P_Action", "A");
                        p.Add("@P_tenderId", 0);
                    }
                    else
                    {
                        p.Add("@P_Action", "B");
                        p.Add("@P_tenderId", TBL.tenderId);
                    }
                    p.Add("@P_projectId", TBL.projectId);
                    p.Add("@P_tenderNo", TBL.tenderNo);
                    p.Add("@P_tenderSubject", TBL.tenderSubject);
                    p.Add("@P_publishedDate", TBL.publishedDate);
                    p.Add("@P_openingDate", TBL.openingDate);
                    p.Add("@P_submissionDate", TBL.submissionDate);
                    p.Add("@P_emdAmount",TBL.emdAmount);
                    p.Add("@P_processingFee",TBL.processingFee);
                    p.Add("@P_nitDocFileName", TBL.nitDocFileName);
                    p.Add("@P_createdBy",1);
                    p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    await Connection.ExecuteAsync("USP_M_PROJECT_TENDER ", p, commandType: CommandType.StoredProcedure);
                    string result = p.Get<string>("@P_MSG_OUT");
                    return Convert.ToInt32(result);
                }
                catch (Exception EX)
                {
                    throw EX;
                }
        }

        public async Task<int> SaveProjectTenderCorrigendum(ProjectTenderCorrigendumEF model)
        {
            try {
                var P = new DynamicParameters();
                if (model.corrigendumId == 0)
                {
                    P.Add("p_Action", 'A');
                    P.Add("P_corrigendumId", 0);
                }
                else {
                    P.Add("p_Action", 'B');
                    P.Add("P_corrigendumId", model.corrigendumId);
                }
                P.Add("P_tenderId", model.tenderId);
                P.Add("P_projectId", model.projectId);
                P.Add("P_corrigendumType", model.corrigendumType);
                P.Add("P_corrigendumDate", Convert.ToDateTime(model.corrigendumDate));
                P.Add("P_approveBy", model.approveBy);
                P.Add("P_corrigendumFileName", model.corrigendumFileName);
                P.Add("P_createdBy", model.createdBy);
                P.Add("P_CorrigendumList", model.CorrigendumList); // Json Formate
                P.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_PROJECT_TENDER_CORRIGENDUM", P, commandType: CommandType.StoredProcedure);
                string result= P.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch(Exception e) { throw; } 
        }

        public async Task<List<VewProjectTenderCorrigendumEF>> ViewProjectTenderCorrigendum(int INT_ID)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action", "B");
                P.Add("P_INT_Id", INT_ID);
               var Result= await Connection.QueryAsync<VewProjectTenderCorrigendumEF>("USP_V_PROJECT_TENDER_CORRIGENDUM", P, commandType: CommandType.StoredProcedure);
                return Result.ToList();
                
            }catch(Exception e) { throw; }
        }
    }
}
