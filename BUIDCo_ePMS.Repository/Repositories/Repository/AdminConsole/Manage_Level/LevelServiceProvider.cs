using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BUIDCO.Domain.AdminConsole.Manage_Level;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Manage_Level;

namespace BUIDCO.Repository.AdminConsole.Manage_Level
{
    public class LevelServiceProvider : BaseProvider, ILevel
    {
        //#region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        //CSMPDK_3_0.CommonDLL ObjCmnDll = new CSMPDK_3_0.CommonDLL();

        //int intOutput = 0;

        //#endregion
        public LevelServiceProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }
        //    /// <summary>
        //    /// Author -Subrat Acharya
        //    /// Modified by:Subhasis Dash
        //    /// Method-To Add Level Details
        //    /// Date-20-May-2010
        //    /// Date-03-Jul-2010
        //    /// </summary>
        //    /// <param name="objHierarchy"></param>
        //    /// <returns></returns>
        //    //public override int AddLevelDetails(Level objLevelDetails)
        //    //{
        //    //    try
        //    //    {
        //    //        object[] arrHierarDetails = 
        //    //                                {"chrActionCode", objLevelDetails.ActionCode,
        //    //                                "intLevelDetailId",objLevelDetails.LeveldetailsID,
        //    //                                "nvchLevelName",objLevelDetails.LevelName,
        //    //                                "intPldId",objLevelDetails.Parentid,
        //    //                                "intLevelId",objLevelDetails.Levelid,
        //    //                                "nvchAddress",objLevelDetails.Address,
        //    //                                "vchTeleNo",objLevelDetails.TelNo,
        //    //                                "vchFaxNo",objLevelDetails.FaxNo,
        //    //                                "vchDISECode",objLevelDetails.DISECode,
        //    //                                "chrFlag",objLevelDetails.Strflag,
        //    //                                "intCreatedBy",objLevelDetails.CreatedBy,
        //    //                                "intOutPut","out"};

        //    //        intOutput = Convert.ToInt32(ObjCmnDll.DbExecuteNonQuery(DataBaseHelper.ConnectionString, "KAC.usp_M_AdminLevelDetails_Manage", arrHierarDetails));
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        throw new CustomException("Execution Failed", ex);
        //    //    }
        //    //    return intOutput;
        //    //}
        //    /// <summary>
        //    /// Author -Subrat Acharya
        //    /// Modified by:Subhasis Dash
        //    /// Method-To Edit Leveldetails
        //    /// Date-20-May-2010
        //    /// Date-03-Jul-2010
        //    /// Modified by:Dilip Tripathy
        //    /// Modify Date : 29-May-2013
        //    /// Desc : Uncomment 'intPldId' and ;intLevelId' parameter
        //    /// </summary>
        //    /// <param name="objHierarchy"></param>
        //    /// <returns></returns>
        //    //public override int EditLevelDetails(Level objLevelDetails)
        //    //{
        //    //    try
        //    //    {
        //    //        object[] arrHierarDetails = { 
        //    //                                        "chrActionCode", objLevelDetails.ActionCode,
        //    //                                        "intLevelDetailId",objLevelDetails.LeveldetailsID,
        //    //                                        "nvchLevelName",objLevelDetails.LevelName,
        //    //                                        "intPldId",objLevelDetails.Parentid,
        //    //                                        "intLevelId",objLevelDetails.Levelid,
        //    //                                        "nvchAddress",objLevelDetails.Address,
        //    //                                        "vchTeleNo",objLevelDetails.TelNo,
        //    //                                        "vchFaxNo",objLevelDetails.FaxNo,
        //    //                                        "chrFlag",objLevelDetails.Strflag,
        //    //                                        "vchDISECode",objLevelDetails.DISECode,
        //    //                                        "intCreatedBy",objLevelDetails.CreatedBy,
        //    //                                        "intOutPut","out"
        //    //                                    };
        //    //        intOutput = Convert.ToInt32(ObjCmnDll.DbExecuteNonQuery(DataBaseHelper.ConnectionString, "KAC.usp_M_AdminLevelDetails_Manage", arrHierarDetails));
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        throw new CustomException("Execution Failed", ex);
        //    //    }
        //    //    return intOutput;

        //    //}
        //    ///// <summary>
        //    ///// Author -Subrat Acharya
        //    ///// Modified by:Subhasis Dash
        //    ///// Method-To Delete Division
        //    ///// Date-20-May-2010
        //    ///// Date-03-Jul-2010
        //    ///// </summary>
        //    ///// <param name="objHierarchy"></param>
        //    ///// <returns></returns>
        //    //public override int DeleteLevelDetails(Level objLevelDetails)
        //    //{
        //    //    try
        //    //    {
        //    //        object[] arrHierarDetails = { 
        //    //                                        "chrActionCode", objLevelDetails.ActionCode,
        //    //                                        "intLevelDetailId",objLevelDetails.LeveldetailsID,
        //    //                                        "intCreatedBy",objLevelDetails.CreatedBy,
        //    //                                        "intOutPut","out"
        //    //                                    };
        //    //        intOutput = Convert.ToInt32(ObjCmnDll.DbExecuteNonQuery(DataBaseHelper.ConnectionString, "KAC.usp_M_AdminLevelDetails_Manage", arrHierarDetails));
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        throw new CustomException("Execution Failed", ex);
        //    //    }
        //    //    return intOutput;
        //    //}
        //    //public override IList<Level> GetAllLevelDetails(Level objLevelDetails)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { 
        //    //                                    "chrActionCode", objLevelDetails.ActionCode, 
        //    //                                    "intLevelDetailId", objLevelDetails.LeveldetailsID,
        //    //                                    "intLevelID",objLevelDetails.Levelid
        //    //                               };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_M_AdminLevelDetails_View", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                LeveldetailsID = Convert.ToInt32(reader["intLevelDetailId"]),
        //    //                LevelName = Convert.ToString(reader["nvchLevelName"]),
        //    //                Levelid = Convert.ToInt32(reader["intLevelId"]),
        //    //                Parentid = Convert.ToInt32(reader["intParentId"])
        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetLevelDetailsById(Level objLevelDetails)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "chrActionCode", objLevelDetails.ActionCode, 
        //    //                                "intLevelDetailId", objLevelDetails.LeveldetailsID
        //    //                                };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_M_AdminLevelDetails_View", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                LeveldetailsID = Convert.ToInt32(reader["intLevelDetailId"]),
        //    //                LevelName = Convert.ToString(reader["nvchLevelName"]),
        //    //                Levelid = Convert.ToInt32(reader["intLevelId"]),
        //    //                Parentid = Convert.ToInt32(reader["intParentId"]),
        //    //                Address = Convert.ToString(reader["nvchAddress"]),
        //    //                TelNo = Convert.ToString(reader["vchTelNo"]),
        //    //                FaxNo = Convert.ToString(reader["vchFaxNo"]),
        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetLocationDetails(Level objLevelDetails)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "chrActionCode", objLevelDetails.ActionCode };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_getLocation_Detail", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                LocId = Convert.ToString(reader["LocationID"]),
        //    //                LocName = Convert.ToString(reader["Location"]),
        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetDivisionDetails(Level objLevelDetails, string LocID)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "locid", LocID };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_getDivision_Detail", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                DivId = Convert.ToString(reader["vchDivID"]),
        //    //                DivName = Convert.ToString(reader["vchDivName"]),
        //    //                LayerOne = Convert.ToString(reader["vchLayer2Name"]),
        //    //                LayerTwo = Convert.ToString(reader["vchLayer3Name"])
        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetDepartmentDetails(Level objLevelDetails, string DivID)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "vchDIVID", DivID };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_getDepartment_Detail", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                DeptId = Convert.ToString(reader["deptid"]),
        //    //                DeptName = Convert.ToString(reader["deptname"]),
        //    //                AdminUserName = Convert.ToString(reader["adminusername"])

        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetSectionDetails(Level objLevelDetails, string DepID)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "vchDEPTID", DepID };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_getSection_Detail", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                SecId = Convert.ToString(reader["section_id"]),
        //    //                SecName = Convert.ToString(reader["section_name"])

        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetUserDetails(Level objLevelDetails, string SecID)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "vchSECID", SecID };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_getuser_Detail", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                UserName = Convert.ToString(reader["username"]),
        //    //                UserFullName = Convert.ToString(reader["fullname"]),
        //    //                UserId = Convert.ToString(reader["userid"])

        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> GetAdminUserFullName(Level objLevelDetails, string userid)
        //    //{
        //    //    List<Level> list = new List<Level>();

        //    //    object[] arrLeveldetails = { "vchuserid", userid };
        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.USP_GETUSER_FULLNAME", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                AdminUserFullName = Convert.ToString(reader["fullname"])

        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> FillHierachyControl()
        //    //{
        //    //    List<Level> list = new List<Level>();


        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "SELECT A.intLevelDetailId,A.nvchLevelName from KAC.M_ADM_LevelDetails A,KAC.M_ADM_Level B where  A.intLevelId=B.intLevelId AND B.intParentId=0 and A.bitstatus=1 and B.bitstatus=1 order by A.nvchLevelName");
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                SecId = Convert.ToString(reader["intLevelDetailId"]),
        //    //                LevelName = Convert.ToString(reader["nvchLevelName"])

        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> FillHierachyControl2(int Parent)
        //    //{
        //    //    List<Level> list = new List<Level>();


        //    //    IDataReader reader = (IDataReader)ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "SELECT A.intLevelDetailId, nvchLevelName from KAC.M_Adm_LevelDetails A,KAC.M_Adm_Level B where  A.intLevelId=B.intLevelId And A.intParentId=" + Parent + " AND A.bitStatus=1 And B.bitStatus=1  order by A.nvchLevelName asc");
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                SecId = Convert.ToString(reader["intLevelDetailId"]),
        //    //                LevelName = Convert.ToString(reader["nvchLevelName"])

        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;
        //    //}
        //    //public override IList<Level> FillLevelGrid(Level objLevelDetails)
        //    //{
        //    //    List<Level> list = new List<Level>();
        //    //    object[] arrLeveldetails = { "chrActionCode", "L", 
        //    //                             "intLevelDetailId", objLevelDetails.LeveldetailsID,
        //    //                             "intLevelID",0};
        //    //    IDataReader reader = (IDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, "KAC.usp_M_AdminLevelDetails_View", "P_RECORDSET", arrLeveldetails);
        //    //    try
        //    //    {
        //    //        while (reader.Read())
        //    //        {
        //    //            Level item = new Level
        //    //            {
        //    //                LeveldetailsID = Convert.ToInt32(reader["intLevelDetailId"].ToString()),
        //    //                LevelName = Convert.ToString(reader["nvchLevelName"]),
        //    //                Address = Convert.ToString(reader["nvchAddress"]),
        //    //                TelNo = Convert.ToString(reader["vchTelNo"]),
        //    //                FaxNo = Convert.ToString(reader["vchFaxNo"]),
        //    //            };
        //    //            list.Add(item);
        //    //        }
        //    //        reader.Close();
        //    //    }
        //    //    catch (Exception exception)
        //    //    {
        //    //        throw exception;
        //    //    }
        //    //    return list;

        //    //}
        public  IList<Level> GetAllHierarchyParents(Level objLevelDetails)
        {
            List<Level> list = new List<Level>();
            SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text, "select * from UDF_AllParentIds(" + objLevelDetails.Levelid + ") order by id asc");
            try
            {
                while (reader.Read())
                {
                    Level item = new Level
                    {
                        LeveldetailsID = Convert.ToInt32(reader["ID"].ToString()),
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