using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;
using BUIDCO.Domain.AdminConsole.CommonFunction;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.CommonFunction;

namespace BUIDCO.Repository.AdminConsole.Common_Function 
{
    public class CommonFunServiceProvider : BaseProvider,ICommonFunServiceProvider
    {
        //#region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        //CSMPDK_3_0.CommonDLL ObjCmnDll = new CSMPDK_3_0.CommonDLL();
        //#endregion
        public CommonFunServiceProvider(IDataBaseHelper dataBaseHelper):base(dataBaseHelper)
        {

        }
        //public IList<CommonFun> GetPoId(int intLvlDtlId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "SELECT intPosition from M_Adm_Level where bitStatus=1 and intLevelId=(Select intLevelId from M_Adm_LevelDetails where bitStatus=1 and  intLevelDetailId=" + intLvlDtlId + "");
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                PositionId = Convert.ToInt32(reader["intPosition"].ToString()),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}

        //public IList<CommonFun> GetPrntId(int intLvlDtlId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "SELECT intparentid from M_Adm_LevelDetails where intleveldetailid=" + intLvlDtlId + " and bitstatus=1");
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                ParentId = Convert.ToInt32(reader["intparentid"].ToString()),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}


        //public IList<CommonFun> fillDropdown(int intparentId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "SELECT intleveldetailid,nvchLevelName from M_Adm_LevelDetails where intparentid=" + intparentId + " and bitstatus=1");
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                LevelDtlsId = Convert.ToInt32(reader["intleveldetailid"].ToString()),
        //                LevelName = reader["nvchLevelName"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}

        //public IList<CommonFun> GetLevelNames(int intDepartmentId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "Select nvchLabel from M_Adm_Level where bitStatus = 1 and intLevelId = (Select intLevelId from M_Adm_LevelDetails where bitStatus = 1 and intLevelDetailId=" + intDepartmentId + ")");
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                LabelName = reader["nvchLabel"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}

        //public IList<CommonFun> FillControls(int intDepartmentId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "SELECT A.intLevelDetailId,A.nvchLevelName from M_Adm_LevelDetails A,M_Adm_Level B where  A.intLevelId=B.intLevelId AND B.intParentId=0");
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                LevelDtlsId = Convert.ToInt32(reader["intleveldetailid"].ToString()),
        //                LevelName = reader["nvchLevelName"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}

        //public IList<CommonFun> popuplocation(CommonFun ObjComnFun)
        //{
        //    List<CommonFun> list = new List<CommonFun>();
        //    try
        //    {
        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_M_AdminLevelDetails_View", "P_RECORDSET", new object[] { "chrActionCode", ObjComnFun.ActionCode });
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                LevelDtlsId = Convert.ToInt32(reader["intleveldetailid"].ToString()),
        //                LevelName = reader["nvchLevelName"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}

        //public IList<CommonFun> intHierachyLevel(int intUserId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "Select a.intNoLevel from M_Adm_Hierarchy a ,M_Adm_Level b,M_Adm_LevelDetails c,M_POR_User d where a.intHierarchyId=b.intHierarchyId and b.intLevelId=c.intLevelId and c.intLevelDetailId=d.intLevelDetailId and d.intUserId=" + intUserId.ToString() + "");
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                intNoLevel = Convert.ToInt32(reader["intNoLevel"].ToString()),                       
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}

        //public IList<CommonFun> GetUserLocation(int userId)
        //{
        //    List<CommonFun> list = new List<CommonFun>();
        //    try
        //    {
        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GetUserLocation", "P_RECORDSET", new object[] { "userId", userId });
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                intLocId = Convert.ToInt32(reader["INTLEVELDETAILID"].ToString()),
        //                LocName = reader["NVCHLEVELNAME"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}



        //public IList<CommonFun> GetUserLogFlag(int intUserId)
        //{
        //    IList<CommonFun> list = new List<CommonFun>();
        //    try
        //    {

        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "SELECT ISNULL(INTLOGFLAG,0) AS INT_LOGFLAG FROM M_POR_User WHERE INTUSERID=" + intUserId.ToString(), 1);
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                INT_LOGFLAG = Convert.ToInt32(reader["INT_LOGFLAG"].ToString()),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return list;
        //}

        //public IList<CommonFun> CreateHierarchyXml(CommonFun ObjComnFun)
        //{
        //    List<CommonFun> list = new List<CommonFun>();
        //    try
        //    {
        //        DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "USP_HIERARCHY_MANAGE_TREEVIEW", "P_RECORDSET", new object[] { "P_ACTIONCODE", ObjComnFun.ActionCode });
        //        while (reader.Read())
        //        {
        //            CommonFun item = new CommonFun
        //            {
        //                ID = reader["ID"].ToString(),
        //                HID = reader["HID"].ToString(),
        //                TOT = reader["TOT"].ToString(),
        //                LID = reader["LID"].ToString(),
        //                PID = reader["PID"].ToString(),
        //                PARENTID =reader["PARENTID"].ToString(),
        //                ALIAS = reader["ALIAS"].ToString(),
        //                FLAG = reader["FLAG"].ToString(),
        //                NAME = reader["NAME"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}

        public IList<CommonFun> GetLocationAdminiStrator(int intLvlDtlId)
        {
            IList<CommonFun> list = new List<CommonFun>();
            try
            {

                DbDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "SELECT isnull(A.vchFullName,'Not Assigned') vchFullName from M_POR_User A,T_Admin_AssignAdmin B where A.intUserId=B.intUserId and  a.bitStatus=1 And B.bitStatus<>0 and B.intLevelDetailId=" + intLvlDtlId + "");
                while (reader.Read())
                {
                    CommonFun item = new CommonFun
                    {
                        vchFullName = reader["vchFullName"].ToString(),
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
        public string GetUserAccess(int intUserId)
        {
            XmlDocument XDoc = new XmlDocument();
            DataSet dsTemp = null;
            string[] objParram = { "P_INT_USER_ID", intUserId.ToString() };
            dsTemp = SqlHelper.SqlHelper.ExecuteDataset(DataBaseHelper.ConnectionString, "USP_GET_USER_PERMISSION_BY_ID", objParram);
            dsTemp.DataSetName = "User";
            dsTemp.Tables[0].TableName = "UserMaster";
            dsTemp.Tables[1].TableName = "GLinkMaster";
            dsTemp.Tables[2].TableName = "PLinkMaster";
            dsTemp.Tables[3].TableName = "ButtonMaster";
            dsTemp.Tables[4].TableName = "TabMaster";

            dsTemp.Relations.Add("R_UserMaster_GlinkMaster", dsTemp.Tables[0].Columns["INT_USER_ID"], dsTemp.Tables[1].Columns["INT_USER_ID"]);
            dsTemp.Relations.Add("R_GLinkMaster_PlinkMaster", dsTemp.Tables[1].Columns["INT_GLINK_ID"], dsTemp.Tables[2].Columns["INT_GLINK_ID"]);

            dsTemp.Relations.Add("R_GLinkMaster_ButtonMaster", dsTemp.Tables[1].Columns["INT_GLINK_ID"], dsTemp.Tables[3].Columns["INT_GLINK_ID"]);
            dsTemp.Relations.Add("R_PLinkMaster_ButtonMaster", dsTemp.Tables[2].Columns["INT_PLINK_ID"], dsTemp.Tables[3].Columns["INT_PLINK_ID"]);
            string xml = "<?xml version='1.0' standalone='yes'?>";
            xml = xml + dsTemp.GetXml();
            return xml;
        }



    }
}