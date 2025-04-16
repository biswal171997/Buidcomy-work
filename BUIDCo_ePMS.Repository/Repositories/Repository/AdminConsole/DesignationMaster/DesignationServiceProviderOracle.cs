using Dapper;
using BUIDCO.Domain.AdminConsole.DesignationMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository;
using BUIDCO.Repository.Contract.Contract.AdminConsole.DesignationMaster;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.DesignationMaster
{
    public class DesignationServiceProviderOracle : RepositoryBase, IDesignationServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
        // int intOutput;
        #endregion
        public DesignationServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddDesignation(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_NVCHDESIGNAME", MySqlDbType.VarChar, ParameterDirection.Input, model.NVCHDESIGNAME);
                dyParam.Add("P_NVCHALIASNAME", MySqlDbType.VarChar, ParameterDirection.Input, model.NVCHALIASNAME);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, model.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, model.INTCREATEDBY);

                dyParam.Add("P_INTDESIGID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
        public async Task<DesignationMasterModel> GetAllDesgination(int id)
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VD");
                dyParam.Add("P_BITSTATUS", MySqlDbType.Int32, ParameterDirection.Input, id);

                dyParam.Add("P_INTDESIGID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_DESIGNATION_MANAGE_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster>();
                DesignationMasterModel viewModel = new DesignationMasterModel();
                viewModel.DesignationMasterList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string MarkActive(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "ACTIVE");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, model.INTUPDATEDBY);
                dyParam.Add("P_INTDESIGID", MySqlDbType.VarChar, ParameterDirection.Input, model.INTDESIGID);

                dyParam.Add("P_NVCHDESIGNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_NVCHALIASNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
        public string MarkInactive(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "I");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, model.INTUPDATEDBY);
                dyParam.Add("P_INTDESIGID", MySqlDbType.VarChar, ParameterDirection.Input, model.INTDESIGID);

                dyParam.Add("P_NVCHDESIGNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_NVCHALIASNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
        public async Task<DesignationMasterModel> GetById(int id)

        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTDESIGID", MySqlDbType.Int32, ParameterDirection.Input, id);

                dyParam.Add("P_BITSTATUS", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_DESIGNATION_MANAGE_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster>();
                DesignationMasterModel viewModel = new DesignationMasterModel();
                viewModel.DesignationMasterList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string EditDesignation(BUIDCO.Domain.AdminConsole.DesignationMaster.DesignationMaster model)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "U");
                dyParam.Add("P_INTDESIGID", MySqlDbType.Int32, ParameterDirection.Input, model.INTDESIGID);
                dyParam.Add("P_NVCHDESIGNAME", MySqlDbType.VarChar, ParameterDirection.Input, model.NVCHDESIGNAME);
                dyParam.Add("P_NVCHALIASNAME", MySqlDbType.VarChar, ParameterDirection.Input, model.NVCHALIASNAME);               
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, model.INTUPDATEDBY);

                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_DESIGNATION_MANAGE";
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
