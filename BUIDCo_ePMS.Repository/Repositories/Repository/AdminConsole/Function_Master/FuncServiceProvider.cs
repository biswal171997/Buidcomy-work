using BUIDCO.Repository.AdminConsole.Persistence;
using BUIDCO.Domain.AdminConsole.Function_Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BUIDCO.Repository.AdminConsole.SqlHelper;

namespace BUIDCO.Repository.AdminConsole.Function_Master
{

    //public class FuncServiceProvider :  BaseProvider, IFuncServiceProvider
    public class FuncServiceProvider : BaseProvider
    {
        #region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        object param = new object();
        int intOutput = 0;
        
        #endregion

        public FuncServiceProvider(IDataBaseHelper dataBaseHelper): base(dataBaseHelper)
        {
            
        }
        public int ActiveFunction(FunctionMaster objFunctionMaster)
        {
            try
            {
                object[] objArray = new object[] { "chrActionCode", objFunctionMaster.ActionCode, "intFunctionId", objFunctionMaster.FunctionId, "intCreatedBy", objFunctionMaster.CreatedBy };
                this.intOutput = Convert.ToInt32(SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_Function_Manage", out param, objArray));
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return Convert.ToInt32(param);
        }

        public int AddFunction(FunctionMaster objFunctionMaster)
        {
            try
            {
                object[] objArray = new object[] { 
                                                    "chrActionCode", objFunctionMaster.ActionCode, 
                                                    "intFunctionId", objFunctionMaster.FunctionId, 
                                                    "vchFunctionName", objFunctionMaster.FunctionName, 
                                                    "vchFileName", objFunctionMaster.FileName, 
                                                    "vchDescription", objFunctionMaster.Description, 
                                                    "vchAction1", objFunctionMaster.FAdd, 
                                                    "vchAction2", objFunctionMaster.FView, 
                                                    "vchAction3", objFunctionMaster.FManage, 
                                                    "bitMailR", objFunctionMaster.MailR,
                                                    "bitFreeBees", objFunctionMaster.FreeBees, 
                                                    "vchPortletFile", objFunctionMaster.PortletFile, 
                                                     "intCreatedBy", objFunctionMaster.CreatedBy
                                                    
                                                };
                this.intOutput = SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_Function_Manage",out param , objArray);
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return Convert.ToInt32(param);
        }

        public int EditFunction(FunctionMaster objFunctionMaster)
        {            
            try
            {
                object[] objArray = new object[] { 
                                                    "chrActionCode", objFunctionMaster.ActionCode, 
                                                    "intFunctionId", objFunctionMaster.FunctionId, 
                                                    "vchFunctionName", objFunctionMaster.FunctionName, 
                                                    "vchFileName", objFunctionMaster.FileName, 
                                                    "vchDescription", objFunctionMaster.Description, 
                                                    "vchAction1", objFunctionMaster.FAdd, 
                                                    "vchAction2", objFunctionMaster.FView, 
                                                    "vchAction3", objFunctionMaster.FManage, 
                                                    "bitMailR", objFunctionMaster.MailR,
                                                    "bitFreeBees", objFunctionMaster.FreeBees, 
                                                    "vchPortletFile", objFunctionMaster.PortletFile, 
                                                     "intCreatedBy", objFunctionMaster.CreatedBy
                                                };
                this.intOutput = SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_Function_Manage",out param, objArray);
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return Convert.ToInt32(param);
        }
        public int DeleteFuncImage(string actionCode, int funcId)
        {
            try
            {
                object[] objArray = new object[] { 
                                                    "chrActionCode", actionCode, 
                                                    "intFunctionId", funcId
                                                    
                                                 };
                this.intOutput = SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_Function_Manage", out param, objArray);
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return Convert.ToInt32(param);
        }
        public IList<FunctionMaster> GetAllFunction(FunctionMaster objFunctionMaster)
        {
            List<FunctionMaster> list = new List<FunctionMaster>();
            object[] objArray = new object[] { 
                                                "chrActionCode", objFunctionMaster.ActionCode, 
                                                "intFunctionId", objFunctionMaster.FunctionId,
                                                "vchFunName",objFunctionMaster.FunctionName,
                                                "intFlag", objFunctionMaster.Flag 
                                            };
            DataSet ds = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteDataset(DataBaseHelper.ConnectionString, "usp_Function_View", objArray);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
            }

            SqlDataReader reader = SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_Function_View", objArray);
            try
            {
                
                while (reader.Read())
                {
                    FunctionMaster item = new FunctionMaster
                    {
                        RowNo = Convert.ToInt32(reader["RowNo"].ToString()),
                        FunctionId = Convert.ToString(reader["intFunctionId"]),
                        FunctionName = Convert.ToString(reader["vchFunction"]),
                        FileName = Convert.ToString(reader["vchFileName"]),
                        Description = Convert.ToString(reader["vchDescription"]),
                        FAdd = Convert.ToString(reader["vchAction1"]),
                        FView = Convert.ToString(reader["vchAction2"]),
                        FManage = Convert.ToString(reader["vchAction3"]),
                        MailR = Convert.ToInt32(reader["bitMailSend"]),
                        FreeBees = Convert.ToInt32(reader["bitFreebees"]),
                        PortletFile = Convert.ToString(reader["vchportletfile"])
                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list;
        }

        public IList<FunctionMaster> GetFunctionId(string userId)
        {
            List<FunctionMaster> list = new List<FunctionMaster>();
            string strQry = "select intFunctionId  from m_adm_function where intCreatedBy=" + int.Parse(userId);
            IDataReader reader = (IDataReader)SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GetFunctionIdByUser", "", "userId", int.Parse(userId));
            //ArrayList arrListFuncId = new ArrayList();
            while (reader.Read())
            {
                FunctionMaster item = new FunctionMaster
                {
                    FunctionId = reader["intFunctionId"].ToString(),
                };
                list.Add(item);
            }
            reader.Close();
            return list;

        }
        public IList<FunctionMaster> FillFunctionType()
        {
            IList<FunctionMaster> list = new List<FunctionMaster>();
            try
            {

                SqlDataReader reader = SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, System.Data.CommandType.Text, "select intFunctionId,  vchFunction from M_ADM_Function where bitStatus=1 ORDER BY vchFunction");
                while (reader.Read())
                {
                    FunctionMaster item = new FunctionMaster
                    {
                        FunctionId = reader["intFunctionId"].ToString(),
                        FunctionName = reader["vchFunction"].ToString(),

                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;
        }

        public string GetFunctionData(int intFuncId)
        {
            object[] objArray = new object[] { "chrActionCode", "E", "intFunctionId", intFuncId };
            DataSet ds = new DataSet();
            ds = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteDataset(DataBaseHelper.ConnectionString, "usp_Function_View", objArray);
            return ds.GetXml();
        }

        public IList<FunctionMaster> GetFunctionDetails(FunctionMaster objFunctionMaster)
        {
            List<FunctionMaster> list = new List<FunctionMaster>();
            object[] objArray = new object[] { "chrActionCode", objFunctionMaster.ActionCode, "intFunctionId", objFunctionMaster.FunctionId, "vchSearchText", objFunctionMaster.Description };
            IDataReader reader = (IDataReader)SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_Function_View", objArray);

            try
            {
                while (reader.Read())
                {
                    FunctionMaster item = new FunctionMaster
                    {
                        FunctionId = reader["FunctionId"].ToString(),
                        FunctionName = Convert.ToString(reader["vchFunction"]),
                        FileName = Convert.ToString(reader["vchFileName"]),
                        Description = Convert.ToString(reader["vchDescription"]),
                        FAdd = Convert.ToString(reader["vchAdd"]),
                        FView = Convert.ToString(reader["vchView"]),
                        FManage = Convert.ToString(reader["vchManage"]),
                        MailR = Convert.ToInt32(reader["bitMailSend"]),
                        FreeBees = Convert.ToInt32(reader["bitFreebees"]),
                        PortletFile = Convert.ToString(reader["vchportletfile"])
                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list;
        }


    }
}