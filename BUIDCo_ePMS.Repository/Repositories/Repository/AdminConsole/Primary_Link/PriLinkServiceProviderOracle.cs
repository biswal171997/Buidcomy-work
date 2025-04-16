
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using BUIDCO.Repository.Extention;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Primary_Link;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Domain.AdminConsole.Primary_Link;
using BUIDCO.Domain.Common;
using BUIDCO.Domain.AdminConsole.ProjectLink;
using BUIDCO.Domain.AdminConsole.Global_Link;

namespace BUIDCO.Repository.AdminConsole.Primary_Link
{
    public class PriLinkServiceProviderOracle : RepositoryBase, IPriLinkServiceProvider
    {

        #region Variable Declaration        
        object param = new object();
      //  int intOutput;
        #endregion

        public PriLinkServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public string AddPrimaryLink(PrimaryModel objPrimary)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_nvchPLinkName", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkName);
                dyParam.Add("P_nvchPLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkNameHin);
                dyParam.Add("P_nvchPLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkNameUrd);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.GlinkId);
                dyParam.Add("P_intFunctionId", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.FunctionId);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.CreatedBy);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.UpdatedBy);
                dyParam.Add("P_INTSLNO", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.INTSLNO);

                dyParam.Add("P_mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_PRIMARYLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successid.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public string MarkInactivePrimaryLink(PrimaryModel objPrimary)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "I");
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.UpdatedBy);
                dyParam.Add("P_mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.INTPLINKID);

                dyParam.Add("P_nvchPLinkName", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_nvchPLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_nvchPLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intFunctionId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTSLNO", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successid.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public async Task<PrimaryModel> GetAllFunctionMaster()

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VF");

                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<FunctionMasterModel>();
                PrimaryModel viewModel = new PrimaryModel();
                viewModel.FunctionList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<PrimaryModel> GetAllPrimaryLink(int id)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, id);

                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<PrimaryLink>();
                PrimaryModel viewModel = new PrimaryModel();
                viewModel.PrimaryLinkList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<IEnumerable<UpdatePrimaryLink>> GetPrimaryLinkById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, id);

                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
               
                var result = await Connection.QueryAsync<UpdatePrimaryLink>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }

        public string EditPrimaryLink(PrimaryModel objPrimary)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.INTPLINKID);
                dyParam.Add("P_nvchPLinkName", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkName);
                dyParam.Add("P_nvchPLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkNameHin);
                dyParam.Add("P_nvchPLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkNameUrd);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.INTGLINKID);
                dyParam.Add("P_intFunctionId", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.INTFUNCTIONID);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.UpdatedBy);

                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTSLNO", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successid.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public string MarkActivePrimaryLink(PrimaryModel objPrimary)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "EA");
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.UpdatedBy);
                dyParam.Add("P_mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.INTPLINKID);
                
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchPLinkName", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intFunctionId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTSLNO", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchPLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkNameHin);
                dyParam.Add("P_nvchPLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, objPrimary.PlinkNameUrd);
                var query = "USP_PRIMARYLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successid.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public async Task<PrimaryModel> GetAllPrimaryLinkByGlobalLink(PrimaryModel objPrimary)
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VG");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, objPrimary.GlinkId);

                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<PrimaryLink>();
                PrimaryModel viewModel = new PrimaryModel();
                viewModel.PrimaryLinkList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string ModifySlnoPrimaryLink(int primaryId, int slno, int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "S");
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, updatedby);
                dyParam.Add("P_mvarintFunctionId", MySqlDbType.Int32, ParameterDirection.Input, primaryId);
                dyParam.Add("P_INTSLNO", MySqlDbType.Int32, ParameterDirection.Input, slno);

                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchPLinkName", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_nvchPLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_nvchPLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intFunctionId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public int GetPrimaryLinkMaxId(int Glinkid)
        {
            int INTSLNO;
            IEnumerable<PrimaryModel> maxid;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "S");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, Glinkid);

                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
                maxid = Connection.Query<PrimaryModel>(query, dyParam, commandType: CommandType.StoredProcedure);
                INTSLNO = Convert.ToInt32(maxid.AsList()[0].INTSLNO);
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
            return INTSLNO;
        }
        public async Task<PrimaryModel> GetAllProjectLink()
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VP");

                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewPoject>();
                PrimaryModel viewModel = new PrimaryModel();
                viewModel.ViewProjectLinkList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<PrimaryModel> GetAllActiveGlobalLinkByProjectId(int ProjectId)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "GP");
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, ProjectId);

                dyParam.Add("P_intPLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PRIMARYLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewGlobal>();
                PrimaryModel viewModel = new PrimaryModel();
                viewModel.ViewGlobalLinkDetailsByProjectId = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
    }
}