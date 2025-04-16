using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Function_Master;
using BUIDCO.Domain.AdminConsole.Function_Master;
using BUIDCO.Repository.Extention;
using BUIDCO.Domain.Common;

namespace BUIDCO.Repository.AdminConsole.Function_Master
{

    public class FuncServiceProviderOracle : RepositoryBase, IFuncServiceProvider
    {
        #region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        object param = new object();
      //  int intOutput = 0;
        
        #endregion
        public FuncServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            
        }
        public int ActiveFunction(FunctionMaster objFunctionMaster)
        {           
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("mvarchrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.ActionCode);
                p.Add("mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FunctionId);
                p.Add("mvarintCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.CreatedBy);

                p.Add("mvarvchFunctionName", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("mvarvchFileName", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("mvarvchDescription", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("mvarvchAction1", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("mvarvchAction2", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("mvarvchAction3", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("mvarbitMailR", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("mvarvchNewTab", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.NewTab);
                p.Add("mvarbitFreeBees", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("mvarvchPortletFile", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_FUNCTION_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public int AddFunction(FunctionMaster objFunctionMaster)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("mvarchrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.ActionCode);
                aParam.Add("mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input,objFunctionMaster.FunctionId);
                aParam.Add("mvarvchFunctionName", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FunctionName.Trim());
                aParam.Add("mvarvchFileName", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FileName.Trim());
                aParam.Add("mvarvchDescription", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.Description);
                aParam.Add("mvarvchAction1", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FAdd);
                aParam.Add("mvarvchAction2", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FView);
                aParam.Add("mvarvchAction3", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FManage);
                aParam.Add("mvarbitMailR", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.MailR);
                aParam.Add("mvarbitFreeBees", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.FreeBees);
                aParam.Add("mvarvchPortletFile", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.PortletFile);
                aParam.Add("mvarvchNewTab", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.NewTab);
                aParam.Add("mvarintCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.CreatedBy); 
                 var query = "USP_FUNCTION_MANAGE";
                var result = Connection.Query<SuccessMessage>(query,aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;
                             
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }   
        }

        public int DeleteFuncImage(string actionCode, int funcId)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("mvarchrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, actionCode);
                aParam.Add("mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, funcId);
                aParam.Add("mvarvchOutPut", MySqlDbType.VarChar, direction: ParameterDirection.Output);
                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_FUNCTION_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;
              
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }           
        }

        public int EditFunction(FunctionMaster objFunctionMaster)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("mvarchrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.ActionCode);
                aParam.Add("mvarintFunctionId", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FunctionId);
                aParam.Add("mvarvchFunctionName", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FunctionName.Trim());
                aParam.Add("mvarvchFileName", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FileName.Trim());
                aParam.Add("mvarvchDescription", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.Description);
                aParam.Add("mvarvchAction1", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FAdd);
                aParam.Add("mvarvchAction2", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FView);
                aParam.Add("mvarvchAction3", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FManage);
                aParam.Add("mvarbitMailR", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.MailR);
                aParam.Add("mvarbitFreeBees", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.FreeBees);
                aParam.Add("mvarvchNewTab", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.NewTab); 
                aParam.Add("mvarvchPortletFile", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.PortletFile);
                aParam.Add("mvarintCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.CreatedBy);
                var query = "USP_FUNCTION_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }     
        }

        public IList<FunctionMaster>GetAllFunction(FunctionMaster objFunctionMaster)
        {
            List<FunctionMaster> list = new List<FunctionMaster>();
            var vParam = new MySqlDynamicParameters();
            vParam.Add("p_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.ActionCode);
            vParam.Add("p_intFunctionId", MySqlDbType.Int32, ParameterDirection.Input, objFunctionMaster.FunctionId);
            vParam.Add("p_vchFunName", MySqlDbType.VarChar, ParameterDirection.Input, objFunctionMaster.FunctionName);
            vParam.Add("p_vchSearchText", MySqlDbType.VarChar, ParameterDirection.Input, "");
            vParam.Add("p_intFlag", MySqlDbType.Int32, direction: ParameterDirection.Input,objFunctionMaster.Flag);
           
            var query = "USP_FUNCTION_VIEW";
            var result = Connection.Query<FunctionMasterNew>(query, vParam, commandType: CommandType.StoredProcedure);
            foreach (var funMaster in result.AsList())
            {
                FunctionMaster item = new FunctionMaster
                {
                    RowNo = funMaster.RowNo,// Convert.ToInt32(reader["RowNo"].ToString()),
                    FunctionId = funMaster.intFunctionId,//Convert.ToString(reader["intFunctionId"]),
                    FunctionName = funMaster.vchFunction,//Convert.ToString(reader["vchFunction"]),
                    FileName = funMaster.vchFileName,//Convert.ToString(reader["vchFileName"]),
                    Description = funMaster.vchDescription,// Convert.ToString(reader["vchDescription"]),
                    FAdd = funMaster.vchAction1,// Convert.ToString(reader["vchAction1"]),
                    FView = funMaster.vchAction2,//Convert.ToString(reader["vchAction2"]),
                    FManage = funMaster.vchAction3,//Convert.ToString(reader["vchAction3"]),
                    MailR = funMaster.bitMailSend,//Convert.ToInt32(reader["bitMailSend"]),
                    FreeBees = funMaster.bitFreebees,// Convert.ToInt32(reader["bitFreebees"]),
                    PortletFile =funMaster.vchportletfile,// Convert.ToString(reader["vchportletfile"])
                    NewTab = funMaster.bitnewtab,
                    FNtab= funMaster.vchAction4
                };
                list.Add(item);
            }
          
               
            return list;
        }
        public async Task<FunctionModel> GetFunction()
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VH");

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
                var t1 = await result.ReadAsync<FunctionMaster>();
                FunctionModel viewModel = new FunctionModel();
                viewModel.FunctionList = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string GetFunctionData(int intFuncId)
        {
            throw new NotImplementedException();
        }

        public IList<FunctionMaster> GetFunctionDetails(FunctionMaster objFunctionMaster)
        {
            throw new NotImplementedException();
        }

        public IList<FunctionMaster> GetFunctionId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}