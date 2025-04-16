using Dapper;
using BUIDCO.Domain.AdminConsole.TabMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.TabMaster;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.TabMaster
{
    public class TabMasterServiceProvider : RepositoryBase, ITabMasterServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
        // int intOutput;
        #endregion
        public TabMasterServiceProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddTabmaster(CreateTabMaster objbutton)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.INTBUTTONID);
                dyParam.Add("P_NVCHTAB", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHTAB);
                dyParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.VCHURL);
                dyParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHDESCRIPTION);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objbutton.intSortNum);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);

                dyParam.Add("P_INTTABID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_MASTER_TAB_MANAGE";
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
        public async Task<IEnumerable<CreateTabMaster>>GetTabById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTTABID", MySqlDbType.Int32, ParameterDirection.Input, id);

                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_TABMASTER_VIEW";

                var result = await Connection.QueryAsync<CreateTabMaster>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<TabMasterModel>GetAllTabview(int id)

        {
            try
             {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, id);

                dyParam.Add("P_INTTABID", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_TABMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Tab_Master>();
                TabMasterModel viewModel = new TabMasterModel();
                viewModel.TabList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string MarkInactive(TabMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "IA");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTTABID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTTABID);

                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_TABMASTER_VIEW";
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

        public string MarkActive(TabMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "ACTIVE");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTTABID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTTABID);

                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_TABMASTER_VIEW";
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

        public IList<CreateTabMaster> GetAllTab(CreateTabMaster objtab)
        {
            List<CreateTabMaster> list = new List<CreateTabMaster>();
            var vParam = new MySqlDynamicParameters();
            vParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, objtab.ActionCode);
            vParam.Add("P_INTTABID", MySqlDbType.Int32, ParameterDirection.Input, objtab.INTTABID);

            vParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
            vParam.Add("P_INTUPDATEDBY", MySqlDbType.VarChar, ParameterDirection.Input, 0);
            var query = "USP_TABMASTER_VIEW";
            var result = Connection.Query<TabMasterNew>(query, vParam, commandType: CommandType.StoredProcedure);
            foreach (var tabMaster in result.AsList())
            {
                CreateTabMaster item = new CreateTabMaster
                {
                    INTTABID = tabMaster.INTTABID,
                    INTBUTTONID = tabMaster.INTBUTTONID,
                    NVCHTAB = tabMaster.NVCHTAB,
                    NVCHDESCRIPTION = tabMaster.NVCHDESCRIPTION,
                    intSortNum = tabMaster.intSortNum,
                    VCHURL = tabMaster.VCHURL,
                    FAdd = tabMaster.VCHBUTTON1,
                    FView = tabMaster.VCHBUTTON2,
                    FManage = tabMaster.VCHBUTTON3,

                };
                list.Add(item);
            }


            return list;
        }

        public int Edittabmaster(CreateTabMaster objMaster)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.ActionCode);
                aParam.Add("P_INTTABID", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.INTTABID);
                aParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.INTBUTTONID);
                aParam.Add("P_NVCHTAB", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.NVCHTAB);
                aParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.VCHURL);
                aParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.NVCHDESCRIPTION);
                aParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.FAdd);
                aParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.FView);
                aParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.FManage);
                aParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objMaster.INTCREATEDBY);

                aParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_TAB_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
        public string EditButton(CreateTabMaster objbutton)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "U");
                dyParam.Add("P_INTTABID", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTTABID);
                dyParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.INTBUTTONID);
                dyParam.Add("P_NVCHTAB", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHTAB);
                dyParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.VCHURL);
                dyParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHDESCRIPTION);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objbutton.intSortNum);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);

                dyParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_MASTER_TAB_MANAGE";
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
        public async Task<ViewTabLink> GetMaxId()
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "S");

                dyParam.Add("P_INTTABID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHTAB", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_TAB_MANAGE";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<CreateTabMaster>();
                ViewTabLink viewModel = new ViewTabLink();
                viewModel.ViewTabLinkDetails = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public int Addtabbmaster(CreateTabMaster objtab)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, objtab.ActionCode);
                aParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objtab.INTBUTTONID);
                aParam.Add("P_NVCHTAB", MySqlDbType.VarChar, ParameterDirection.Input, objtab.NVCHTAB);
                aParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objtab.VCHURL);
                aParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objtab.NVCHDESCRIPTION);
                aParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objtab.TintSortNum);
                aParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, objtab.FAdd);
                aParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, objtab.FView);
                aParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, objtab.FManage);
                aParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objtab.INTCREATEDBY);
                aParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objtab.INTCREATEDBY);

                aParam.Add("P_INTTABID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_TAB_MANAGE";
               
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
    }
}
