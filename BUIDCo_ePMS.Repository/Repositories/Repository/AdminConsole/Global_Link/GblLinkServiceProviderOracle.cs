using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Global_Link;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Domain.AdminConsole.Global_Link;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Extention;

namespace BUIDCO.Repository.AdminConsole.Global_Link
{
    public class GblLinkServiceProviderOracle : RepositoryBase, IGblLinkServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
       // int intOutput;
        #endregion

        public GblLinkServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public int ActivateGlobalLink(Global objGloballink)
        {
            throw new NotImplementedException();
        }

        //public string AddGlobalLink(Global objGloballink)
        //{
        //    string strOutput = "";
        //    IEnumerable<SuccessMessage> SuccessMessages;
        //    try
        //    {
        //        var dyParam = new MySqlDynamicParameters();
        //        dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "A");
        //        dyParam.Add("P_nvchGLinkName", MySqlDbType.VarChar, ParameterDirection.Input, objGloballink.GlobalLinkName.ToUpper());
        //        dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.CreatedBy);
        //        dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.CreatedBy);
        //        dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.GintSortNum);
        //        //dyParam.Add("P_Msg", MySqlDbType.RefCursor, ParameterDirection.Output);
        //        var query = "USP_GLOBALLINK_MANAGE";
        //        SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
        //        strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Logger.LogError(ex, ex.Message, Model);
        //        throw ex;
        //    }
        //    return strOutput;
        //}
        public string AddGlobalLink(ViewGlobal objGloballink)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_nvchGLinkName", MySqlDbType.VarChar, ParameterDirection.Input, objGloballink.GlobalLinkName.Trim());
                dyParam.Add("P_nvchGLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, objGloballink.GlobalLinkNameH.Trim());
                dyParam.Add("P_nvchGLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, objGloballink.GlobalLinkNameU.Trim());
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.CreatedBy);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.CreatedBy);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.GintSortNum);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, objGloballink.INTPROJECTLINKID);
                dyParam.Add("P_VCHICONCLASS", MySqlDbType.VarChar, ParameterDirection.Input, objGloballink.VCHICONCLASS);

                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_MANAGE";
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
        public string EditGlobalLink(ViewGlobal objupdateGloballink)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_nvchGLinkName", MySqlDbType.VarChar, ParameterDirection.Input, objupdateGloballink.nvchGLinkName.Trim());
                dyParam.Add("P_nvchGLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, objupdateGloballink.nvchGLinkNameHin.Trim());
                dyParam.Add("P_nvchGLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, objupdateGloballink.nvchGLinkNameUrd.Trim());
                dyParam.Add("P_VCHICONCLASS", MySqlDbType.VarChar, ParameterDirection.Input, objupdateGloballink.VCHICONCLASS.Trim());
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, objupdateGloballink.intGLinkID);             
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objupdateGloballink.updatedBy);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, objupdateGloballink.INTPROJECTLINKID);

                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_MANAGE";
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
        public string DeleteGlobalLink(int id, int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "D");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input,id);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, updatedby);

                dyParam.Add("P_nvchGLinkName", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchGLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input,0);
                dyParam.Add("P_nvchGLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input,0);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_VCHICONCLASS", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_MANAGE";
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
        public async Task<ViewGlobalLink> GetAllActiveGlobalLink()     
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VAA");

                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewGlobal>();
                ViewGlobalLink viewModel = new ViewGlobalLink();
                viewModel.ViewGlobalLinkDetailsmodel = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
               //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<ViewGlobalLink> GetAllInActiveGlobalLink()

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VAI");

                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewGlobal>();
                ViewGlobalLink viewModel = new ViewGlobalLink();
                viewModel.ViewGlobalLinkDetailsmodel = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string ModifySlnoGlobalLink(int globalId,int slno, int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "MS");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, globalId);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, slno);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, updatedby);

                dyParam.Add("P_nvchGLinkName", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchGLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchGLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_VCHICONCLASS", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_MANAGE";
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
        //public async Task<IEnumerable<Global>> GetGlobalLinkMaxId()
        public int GetGlobalLinkMaxId()
        {
            int GMaxId;
            IEnumerable<ViewGlobal> maxid;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "S");

                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_VIEW";
                maxid= Connection.Query<ViewGlobal>(query, dyParam, commandType: CommandType.StoredProcedure);
                GMaxId =Convert.ToInt32( maxid.AsList()[0].GMAxid);
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
            return GMaxId;
        }
    
        public async Task<IEnumerable<ViewGlobal>> GetGlobalLinkById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, id);
                
                var query = "USP_GLOBALLINK_VIEW";
                  var result = await Connection.QueryAsync<ViewGlobal>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<ViewGlobalLink> GetById(int id)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, id);
                
                var query = "USP_GLOBALLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewGlobal>();
                ViewGlobalLink viewModel = new ViewGlobalLink();
                viewModel.ViewGlobalLinkDetailsmodel = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }

        public async Task<ViewGlobalLink> GetMaxId()
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "S");

                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewGlobal>();
                ViewGlobalLink viewModel = new ViewGlobalLink();
                viewModel.ViewGlobalLinkDetailsmodel = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string MarkActiveGlobalLink(int id, int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "EI");
                dyParam.Add("P_intGLinkId", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, updatedby);

                dyParam.Add("P_nvchGLinkName", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchGLinkNameHin", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_nvchGLinkNameUrd", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intSortNum", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTPROJECTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_VCHICONCLASS", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                var query = "USP_GLOBALLINK_MANAGE";
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

        //public int DeleteGlobalLink(Global objGloballink)
        //{
        //    throw new NotImplementedException();
        //}

        //public int EditGlobalLink(Global objGloballink)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<Global> GetAllGlobalLink(Global objGloballink)
        //{
        //    throw new NotImplementedException();
        //}

        public IList<Global> GetAllLocation(Global objGloballink)
        {
            throw new NotImplementedException();
        }

        //public string GetGlobalLinkById(Global objGloballink)
        //{
        //    throw new NotImplementedException();
        //}

        public IList<Global> GetGlobalLinkDetails(Global objGloballink)
        {
            throw new NotImplementedException();
        }

        public int GetMaxGlinkId()
        {
            throw new NotImplementedException();
        }

        public int InActivateGlobalLink(Global objGloballink)
        {
            throw new NotImplementedException();
        }

        public int UpdateSlno(Global objGloballink)
        {
            throw new NotImplementedException();
        }
    }
}