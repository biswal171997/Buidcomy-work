using BUIDCo_ePMS.Model.Entities.AssignProjectWork;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using Dapper;
using System.Data;
namespace BUIDCo_ePMS.Repository.Repository

{
    public class AssignWorkRepository : Db_BUIDCo_PMSRepositoryBase, IAssignWorkRepository
    {
        public AssignWorkRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<int> SaveAssignProject(AssignProject TBL)
        {
            try
            {
                var p = new DynamicParameters();
                if (TBL.id > 0  || TBL.id != null)
                {
                    p.Add("@P_Id", TBL.id);
                    p.Add("@P_Action", "B"); 
                    p.Add("@p_projectId", TBL.hiddenProjectId);
                }
                else
                {
                    p.Add("@P_Id", 0);
                    p.Add("@P_Action", "A");  
                    p.Add("@p_projectId", 0); 
                    p.Add("@p_tenderId", TBL.tenderId ?? 0); 

                }
                p.Add("@p_tenderId", TBL.tenderId ?? 0); 
                p.Add("@p_projectId", TBL.hiddenProjectId);
                p.Add("@P_AssignTo", TBL.AssignTo);
                p.Add("@P_AgreementAmount", TBL.AgreementAmount);
                p.Add("@p_bidderId", TBL.bidderId ?? 0);
                p.Add("@p_panNo", TBL.panNo);  
                p.Add("@p_gstNo", TBL.gstNo);
                p.Add("@p_licenseNo", TBL.licenseNo);
                p.Add("@p_contactNo", TBL.ContactNo);
                p.Add("@p_phoneNo", TBL.phoneNo);
                p.Add("@p_InstrumentType", TBL.InstrumentType);
                p.Add("@p_PGAmount", TBL.PGAmount);
                p.Add("@p_BankName", TBL.BankName);
                p.Add("@p_ValidTill", TBL.ValidTill);
                p.Add("@p_UploadPgDocuments", TBL.UploadPGDocumentPath);
                p.Add("@p_faxNo", TBL.faxNo);
                p.Add("@p_emailId", TBL.emailId);
                p.Add("@p_mobileNo", TBL.mobileNo);
                p.Add("@p_contactPerson", TBL.contactPerson);
                p.Add("@P_contactPersonMobile", TBL.contactPersonMobileNumber);
                p.Add("@p_address", TBL.address);
                p.Add("@p_bgStatus", 0); 
                p.Add("p_letterDocPath", TBL.letterDocpath);
                p.Add("@p_projectDuration", TBL.projectDuration); 
                p.Add("@p_startDate", TBL.startDate);  
                p.Add("@p_endDate", TBL.endDate);
                p.Add("@P_createdBy", TBL.createdBy);
                p.Add("P_BankList", TBL.bankdetailsList12);                
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);               
                await Connection.ExecuteAsync("USP_T_Project_AssignWork", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result); 
            }
            catch (Exception EX)
            {
                throw EX;  // Rethrow exception to handle it elsewhere if necessary
            }
        }

        public async Task<List<ViewAssignProject1>> GetAssignProjectById(int Id)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_Id", Id);
                var results = await Connection.QueryAsync<ViewAssignProject1>("USP_V_AssignProject ", p, commandType: CommandType.StoredProcedure);

                // Get the output message from the stored procedure
                return results.ToList()!;
            }

            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<AssignProject>> GetallAssignProject(AssignProject TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@ProjectId", 0);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<AssignProject>("USP_T_Project_AssignWork ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<List<AssignProject>> GetassignprojectList(AssignProject TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "k");
                p.Add("@P_INT_ID", 0);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<AssignProject>("USP_Common_Provider ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }

        public async Task<List<ViewAssignProject>> GetallAssignProjectView(ViewAssignProject TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_Id", 0);
                var results = await Connection.QueryAsync<ViewAssignProject>("USP_V_AssignProject ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<string> DeleteAssignProject(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "D");  // Action 'C' for Delete
                p.Add("@P_Id", Id, DbType.Int32);
            
                await Connection.ExecuteAsync("USP_V_AssignProject", p, commandType: CommandType.StoredProcedure);

                string result = p.Get<string>("@P_MSG_OUT");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting project: " + ex.Message);
            }
        }


        public async Task<AssignProject> EditAssignProjectById(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");  // Action 'A' for Select
                p.Add("@P_Id", Id, DbType.Int32);

                var result = await Connection.QueryAsync<AssignProject>(
                    "USP_V_AssignProject",
                    p,
                    commandType: CommandType.StoredProcedure
                );

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching project by ID: " + ex.Message);
            }
        }

    
        public  async Task<List<AssignProject>> ViewDetails(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_Id", Id);
              
                var results = await Connection.QueryAsync<AssignProject>("USP_V_AssignProject ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ViewBidderDetails>> GetAssignToList(int PId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "G");
                p.Add("@P_Id", PId);
               
                var results = await Connection.QueryAsync<ViewBidderDetails>("USP_V_AssignProject ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ViewBankComponent>> GetBankComponents(ViewBankComponent model)
        {
            try {
                var P = new DynamicParameters();
                P.Add("P_Action","E");
                P.Add("P_Id", 0);
                var result =await Connection.QueryAsync<ViewBankComponent>("USP_V_AssignProject", P, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            catch(Exception e) { throw; }
        }
    }
    }






