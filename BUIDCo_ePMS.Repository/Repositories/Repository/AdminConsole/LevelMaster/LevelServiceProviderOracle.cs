using Dapper;
using BUIDCO.Domain.AdminConsole.LevelMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.LevelMaster;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.LevelMaster
{
    public class LevelServiceProviderOracle : RepositoryBase, ILevelServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
      //  int intOutput;
        #endregion
        public LevelServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddLevel(CreateLevelMaster objlevel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTHIERARCHYID);
                dyParam.Add("P_NVCHLABEL", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.NVCHLABEL);
                dyParam.Add("P_VCHALLIAS", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHALLIAS);
                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTPARENTID);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTCREATEDBY);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input,0);
                var query = "USP_LEVELMASTER_MANAGE";
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

        public async Task<CreateLevelMaster> GetAllLevelByHierarchyId(int id)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VL");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, id); 
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<BUIDCO.Domain.AdminConsole.LevelMaster.LevelMaster>();
                CreateLevelMaster viewModel = new CreateLevelMaster();
                viewModel.ParentLevelList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<LevelMasterModel> GetAllLevel(int id)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<BUIDCO.Domain.AdminConsole.LevelMaster.LevelMaster>();
                LevelMasterModel viewModel = new LevelMasterModel();
                viewModel.LevelList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<IEnumerable<CreateLevelMaster>> GetLevelById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELMASTER_VIEW";

                var result = await Connection.QueryAsync<CreateLevelMaster>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string EditLevel(CreateLevelMaster objlevel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTLEVELID);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTHIERARCHYID);
                dyParam.Add("P_NVCHLABEL", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.NVCHLABEL);
                dyParam.Add("P_VCHALLIAS", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHALLIAS);
                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTPARENTID);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTUPDATEDBY);

                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELMASTER_MANAGE";
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

        public string MarkInactive(LevelMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "I");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTLEVELID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTLEVELID);

                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHLABEL", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHALLIAS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELMASTER_MANAGE";
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

        public string MarkActive(LevelMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "EA");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTLEVELID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTLEVELID);

                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHLABEL", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHALLIAS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELMASTER_MANAGE";
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
