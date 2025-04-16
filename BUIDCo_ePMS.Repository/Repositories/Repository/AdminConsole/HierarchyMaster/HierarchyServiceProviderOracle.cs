using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using BUIDCO.Repository.Contract.Contract.AdminConsole.HierarchyMaster;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Domain.AdminConsole.HierarchyMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Extention;

namespace BUIDCO.Repository.AdminConsole.HierarchyMaster
{
    public class HierarchyServiceProviderOracle: RepositoryBase,IHierarchyServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
       // int intOutput;
        #endregion
        public HierarchyServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddHierarchy(Hierarchy objhierarchy)
         {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0); 
                dyParam.Add("P_NVCHHIERARCHYNAME", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.NVCHHIERARCHYNAME.ToUpper());
                dyParam.Add("P_VCHHIERARCHYALIAS", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.VCHHIERARCHYALIAS.ToUpper());
                dyParam.Add("P_INTNOLEVEL", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTNOLEVEL);
                dyParam.Add("P_NVCHADDRESS", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.NVCHADDRESS!=null ? objhierarchy.NVCHADDRESS.ToUpper(): objhierarchy.NVCHADDRESS);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                var query = "USP_HIERARCHYMASTER_MANAGE";
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
        public async Task<HierarchyModel> GetAllHierarchy(int id)
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input,0);
                var query = "USP_HIERARCHYMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Hierarchy>();
                HierarchyModel viewModel = new HierarchyModel();
                viewModel.HierarchyList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<IEnumerable<Hierarchy>> GetHierarchyById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_HIERARCHYMASTER_VIEW";

                var result = await Connection.QueryAsync<Hierarchy>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<HierarchyModel> GetById(int id)

        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_HIERARCHYMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Hierarchy>();
                HierarchyModel viewModel = new HierarchyModel();
                viewModel.HierarchyList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string EditHierarchy(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTHIERARCHYID);
                dyParam.Add("P_NVCHHIERARCHYNAME", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.NVCHHIERARCHYNAME.ToUpper());
                dyParam.Add("P_VCHHIERARCHYALIAS", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.VCHHIERARCHYALIAS.ToUpper());
                dyParam.Add("P_INTNOLEVEL", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTNOLEVEL);
                dyParam.Add("P_NVCHADDRESS", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.NVCHADDRESS != null ? objhierarchy.NVCHADDRESS.ToUpper() : objhierarchy.NVCHADDRESS);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTUPDATEDBY);
                var query = "USP_HIERARCHYMASTER_MANAGE";
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
        public string MarkInactive(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "I");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.INTHIERARCHYID);
                dyParam.Add("P_NVCHHIERARCHYNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHHIERARCHYALIAS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTNOLEVEL", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTNOLEVEL);
                dyParam.Add("P_NVCHADDRESS", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.NVCHADDRESS != null ? objhierarchy.NVCHADDRESS.ToUpper() : objhierarchy.NVCHADDRESS);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                var query = "USP_HIERARCHYMASTER_MANAGE";
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
        public string MarkActive(Hierarchy objhierarchy)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "EA");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.INTHIERARCHYID);
                dyParam.Add("P_NVCHHIERARCHYNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHHIERARCHYALIAS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTNOLEVEL", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTNOLEVEL);
                dyParam.Add("P_NVCHADDRESS", MySqlDbType.VarChar, ParameterDirection.Input, objhierarchy.NVCHADDRESS != null ? objhierarchy.NVCHADDRESS.ToUpper() : objhierarchy.NVCHADDRESS);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objhierarchy.INTCREATEDBY);
                var query = "USP_HIERARCHYMASTER_MANAGE";
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
