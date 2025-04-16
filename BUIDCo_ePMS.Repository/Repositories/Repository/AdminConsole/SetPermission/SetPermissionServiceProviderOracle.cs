using Dapper;
using BUIDCO.Domain.AdminConsole.Set_Permission;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.SetPermission;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.SetPermission
{
    public class SetPermissionServiceProviderOracle : RepositoryBase, ISetPermissionServiceProvider
    {
        public SetPermissionServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<SetPermissionModel> GetAllPrimaryLinkByGlobalLink(SetPermissionModel objpermission)
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VGP");
                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, objpermission.DesignId);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, objpermission.INTPROJECTLINKID);

                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<SetPermissionDetails>();
                SetPermissionModel viewModel = new SetPermissionModel();
                viewModel.GlobalPrimaryList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string SetPermissionLink_Designation(int designationId,int Plinkid,int Intaccess,int user, int projectId)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "AED");
                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, designationId);
                dyParam.Add("P_intpLinkId", MySqlDbType.Int32, ParameterDirection.Input, Plinkid);
                dyParam.Add("P_TINACCESS", MySqlDbType.Int32, ParameterDirection.Input, Intaccess);
                dyParam.Add("P_intuser", MySqlDbType.Int32, ParameterDirection.Input, user);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, projectId);

                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTACCESSID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_MANAGE";
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
        public async Task<SetPermissionModel> GetAllPrimaryLinkByGlobalLinkUserwise(SetPermissionModel objpermission)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VUGP");
                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, objpermission.UserId);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, objpermission.INTPROJECTLINKID);

                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input,0);
                var query = "USP_SETPERMISSION_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<SetPermissionDetails>();
                SetPermissionModel viewModel = new SetPermissionModel();
                viewModel.GlobalPrimaryList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string SetPermissionLink_User(int userId, int Plinkid, int Intaccess, int user,int projectId)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "AEU");
                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, userId);
                dyParam.Add("P_intpLinkId", MySqlDbType.Int32, ParameterDirection.Input, Plinkid);
                dyParam.Add("P_TINACCESS", MySqlDbType.Int32, ParameterDirection.Input, Intaccess);
                dyParam.Add("P_intuser", MySqlDbType.Int32, ParameterDirection.Input, user);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, projectId);

                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTACCESSID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_MANAGE";
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
        public string DeletePermissionLink_Designation(int DesignationId, int projectId)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "DPD");
                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, DesignationId);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, projectId);

                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intpLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_TINACCESS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intuser", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTACCESSID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_MANAGE";
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
        public string DeletePermissionLink_User(int userId,int projectId)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "DPU");
                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, userId);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, projectId);

                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intpLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_TINACCESS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intuser", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTACCESSID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_MANAGE";
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
        public async Task<SetPermissionModel> GetAllUser()

        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VU");

                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<UserDetails>();
                SetPermissionModel viewModel = new SetPermissionModel();
                viewModel.UserList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string RemovePermissionList_User(int userId,int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "RUP");
                dyParam.Add("P_INTUSERID", MySqlDbType.Int32, ParameterDirection.Input, userId);
                dyParam.Add("P_intuser", MySqlDbType.Int32, ParameterDirection.Input, updatedby);

                dyParam.Add("P_INTDESINATIONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intpLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_TINACCESS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTACCESSID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_SETPERMISSION_MANAGE";
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
    }
}
