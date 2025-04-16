using Dapper;
using BUIDCO.Domain.AdminConsole.ButtonMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ButtonMaster;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.ButtonMaster
{
    public class ButtonMasterServiceProvider : RepositoryBase, IButtonMasterServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
        // int intOutput;
        #endregion
        public ButtonMasterServiceProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddButtonmaster(CreateButtonMaster objbutton)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_INTFUNCTIONID", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.INTFUNCTIONID);
                dyParam.Add("P_NVCHBUTTON", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHBUTTON);
                dyParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.VCHURL);
                dyParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHDESCRIPTION);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objbutton.intSortNum);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);

                dyParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_MASTER_BUTTON_MANAGE";
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

        public int AddButtnmaster(CreateButtonMaster objbutton)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.ActionCode);
                aParam.Add("P_INTFUNCTIONID", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.INTFUNCTIONID);
                aParam.Add("P_NVCHBUTTON", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHBUTTON.Trim());
                aParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.VCHURL.Trim());
                aParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHDESCRIPTION);
                aParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.FAdd);
                aParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.FView);
                aParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.FManage);
                aParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objbutton.BintSortNum);
                aParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);
                aParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTCREATEDBY);

                aParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_BUTTON_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public IList<CreateButtonMaster> GetAllbutton(CreateButtonMaster objButtonMaster)
        {
            List<CreateButtonMaster> list = new List<CreateButtonMaster>();
            var vParam = new MySqlDynamicParameters();
            vParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, objButtonMaster.ActionCode);
            vParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, objButtonMaster.INTBUTTONID);

            vParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
            vParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
            var query = "USP_BUTTONMASTER_VIEW";
            var result = Connection.Query<ButtonMasterNew>(query, vParam, commandType: CommandType.StoredProcedure);
            foreach (var buttonMaster in result.AsList())
            {
                CreateButtonMaster item = new CreateButtonMaster
                {
                    INTBUTTONID = buttonMaster.INTBUTTONID,
                    INTFUNCTIONID = buttonMaster.INTFUNCTIONID,
                    NVCHBUTTON = buttonMaster.NVCHBUTTON,
                    NVCHDESCRIPTION = buttonMaster.NVCHDESCRIPTION,
                    intSortNum= buttonMaster.intSortNum,
                    VCHURL = buttonMaster.VCHURL,
                    FAdd = buttonMaster.VCHBUTTON1,
                    FView = buttonMaster.VCHBUTTON2,
                    FManage = buttonMaster.VCHBUTTON3,
                    
                };
                list.Add(item);
            }


            return list;
        }

        public int EditButtonmaster(CreateButtonMaster objMaster)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.ActionCode);
                aParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.INTBUTTONID);
                aParam.Add("P_INTFUNCTIONID", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.INTFUNCTIONID);
                aParam.Add("P_NVCHBUTTON", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.NVCHBUTTON.Trim());
                aParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.VCHURL.Trim());
                aParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.NVCHDESCRIPTION);
                aParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.FAdd);
                aParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.FView);
                aParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, objMaster.FManage);
                aParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objMaster.INTUPDATEDBY);

                aParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_BUTTON_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
        public async Task<IEnumerable<CreateButtonMaster>> GetButtonById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, id);

                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_BUTTONMASTER_VIEW";

                var result = await Connection.QueryAsync<CreateButtonMaster>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<ButtonMasterModel> GetAllButtonview( int id )
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, id);

                dyParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_BUTTONMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Button_Master>();
                ButtonMasterModel viewModel = new ButtonMasterModel();
                viewModel.ButtonList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string MarkInactive(ButtonMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "IA");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTBUTTONID);

                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_BUTTONMASTER_VIEW";
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

        public string MarkActive(ButtonMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "ACTIVE");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTBUTTONID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTBUTTONID);

                dyParam.Add("P_intStatus", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_BUTTONMASTER_VIEW";
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
        public string EditButton(CreateButtonMaster objbutton)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "U");
                dyParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTBUTTONID);
                dyParam.Add("P_INTFUNCTIONID", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTFUNCTIONID);
                dyParam.Add("P_NVCHBUTTON", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHBUTTON);
                dyParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.VCHURL);
                dyParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, objbutton.NVCHDESCRIPTION);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objbutton.intSortNum);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objbutton.INTUPDATEDBY);

                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_MASTER_BUTTON_MANAGE";
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
        public async Task<ViewButtonLink> GetMaxId()

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "S");

                dyParam.Add("P_INTBUTTONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTFUNCTIONID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHBUTTON", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHURL", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_NVCHDESCRIPTION", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_BUTTON1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_BUTTON3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_MASTER_BUTTON_MANAGE";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<CreateButtonMaster>();
                ViewButtonLink viewModel = new ViewButtonLink();
                viewModel.ViewButtonLinkDetails = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<ButtonMasterModel>GetButton()
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VH");

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
                var t1 = await result.ReadAsync<Button_Master>();
                ButtonMasterModel viewModel = new ButtonMasterModel();
                viewModel.ButtonList = t1.AsList();
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
