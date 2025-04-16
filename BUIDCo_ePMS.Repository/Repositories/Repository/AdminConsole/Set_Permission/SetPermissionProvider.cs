using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Set_Permission;

namespace BUIDCO.Repository.AdminConsole.Set_Permission
{
    public class SetPermissionProvider : BaseProvider,ISetPermission
    {
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        //CSMPDK_3_0.CommonDLL objComnDll = new CSMPDK_3_0.CommonDLL();


        //private string strConString = DataBaseHelper.ConnectionString;
        private int intOutput = 0;
        public SetPermissionProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }
        public int AddPermission(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetPermission)
        {
            try
            {
                object[] objArray = new object[] {
                                                    "ActionCode", objSetPermission.ActionCode,
                                                    "intUserID", objSetPermission.UserID,
                                                    "intPlinkId", objSetPermission.PlinkId,
                                                    "tinAccess", objSetPermission.PermissionType,
                                                    "intUpdatedBy", objSetPermission.UpdatedBy,
                                                    //"Plinks", objSetPermission.PLinkName,
                                                    "OutPut", 0
                                                };
                this.intOutput = Convert.ToInt32(BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_LinkAccess_Manage", objArray));
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return intOutput;
        }
        public  IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> GetPermissionOfPerticularUser(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetPermission)
        {
            IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> list = new List<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission>();
            try
            {
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_LinkAccess_View", new object[] { "chrActionCode", objSetPermission.Action, "ID", objSetPermission.ID });
                while (reader.Read())
                {
                    if (objSetPermission.Action == "V")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission item = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            UserID = Convert.ToInt32(reader["intUserID"].ToString()),
                            GlinkId = Convert.ToString(reader["nvchGlinkId"].ToString()),
                            PlinkView = Convert.ToString(reader["nvchPlinkView"].ToString()),
                            PlinkAdd = Convert.ToString(reader["nvchPlinkAdd"].ToString()),
                            PlinkManage = Convert.ToString(reader["nvchPlinkManage"].ToString()),
                            UpdatedBy = Convert.ToInt32(reader["intUpdatedBy"].ToString())
                        };
                        list.Add(item);
                    }
                    if (objSetPermission.Action == "G")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission permission2 = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            GlinkId = Convert.ToString(reader["intGLinkID"].ToString()),
                            GLinkName = Convert.ToString(reader["GLINKNAME"].ToString())
                        };
                        list.Add(permission2);
                    }
                    if (objSetPermission.Action == "L")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission permission3 = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            GlinkId = Convert.ToString(reader["nvchGlinkId"].ToString())
                        };
                        list.Add(permission3);
                    }
                    if (objSetPermission.Action == "P")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission permission4 = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            PlinkId = Convert.ToInt32(reader["PlinkId"].ToString()),
                            PLinkName = Convert.ToString(reader["PlinkName"].ToString()),
                            ID = Convert.ToInt32(reader["id"].ToString())
                        };
                        list.Add(permission4);
                    }
                    if (objSetPermission.Action == "F")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission permission5 = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            FunctionId = Convert.ToInt32(reader["FunctionId"].ToString())
                        };
                        list.Add(permission5);
                    }
                    if (objSetPermission.Action == "M")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission permission6 = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            PlinkView = Convert.ToString(reader["vch_View"].ToString()),
                            PlinkAdd = Convert.ToString(reader["vch_Add"].ToString()),
                            PlinkManage = Convert.ToString(reader["vch_Manage"].ToString())
                        };
                        list.Add(permission6);
                    }
                    if (objSetPermission.Action == "N")
                    {
                        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission permission6 = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
                        {
                            GlinkId = Convert.ToString(reader["intGLinkID"].ToString()),
                            GLinkName = Convert.ToString(reader["GLINKNAME"].ToString()),
                            PlinkId = Convert.ToInt32(reader["PlinkId"].ToString()),
                            PLinkName = Convert.ToString(reader["PlinkName"].ToString()),
                            ID = Convert.ToInt32(reader["id"].ToString())
                        };
                        list.Add(permission6);
                    }
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;
        }

        public string UpdateGroupPermission(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetGrpPermission)
        {
            object[] objArray = new object[] {
                "chrActionCode", objSetGrpPermission.ActionCode, "vchUserId", objSetGrpPermission.GroupUserId, "TINACCESS", objSetGrpPermission.FunctionId,
                "vchDeptId", objSetGrpPermission.GroupDeptId,  "INTPLINKID", objSetGrpPermission.PlinkId, "Status", objSetGrpPermission.PermissionStatus,
                "intUpdatedBy", objSetGrpPermission.UpdatedBy,
                "OutPut", "out"
             };
            return BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString,"usp_GroupSetPermission", objArray).ToString();
        }

        //public override int UpdatePermission(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetPermission)
        //{
        //    try
        //    {
        //        object[] objArray = new object[] { "ActionCode", objSetPermission.ActionCode, "intUserID", objSetPermission.UserID, "nvchGlinkId", objSetPermission.GlinkId, "nvchPlinkView", objSetPermission.PlinkView, "nvchPlinkAdd", objSetPermission.PlinkAdd, "nvchPlinkManage", objSetPermission.PlinkManage, "intUpdatedBy", objSetPermission.UpdatedBy, "OutPut", "out" };
        //        this.intOutput = Convert.ToInt32(this.objComnDll.DbExecuteNonQuery(this.strConString, "KAC.usp_LinkAccess_Manage", objArray));
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("Execution Failed", exception);
        //    }
        //    return this.intOutput;
        //}
        //public override string GetUserID(string searchText)
        //{
        //    string strUserIdNames = "--Select--,0,";
        //    if (searchText != "0")
        //    {
        //      string[] strIdText = searchText.Split(',');
        //      DataTable dtUserIdName = this.objComnDll.GetDataTable(DataBaseHelper.ConnectionString, "exec KAC.usp_GetUserByLocAdmin " + Convert.ToInt32(strIdText[0].ToString()) + ", '" + strIdText[1].ToUpper() + "'");

        //        if (dtUserIdName.Rows.Count != 0)
        //        {
        //            for (int i = 0; i < dtUserIdName.Rows.Count; i++)
        //            {
        //                strUserIdNames += dtUserIdName.Rows[i][1].ToString() + "," + dtUserIdName.Rows[i][0].ToString() + ",";
        //            }
        //            return strUserIdNames.TrimEnd(',');
        //        }
        //    }
        //    else
        //    {
        //        return strUserIdNames.TrimEnd(',');
        //    }
        //    return strUserIdNames; 
        //}

        //public IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> GetUserList(string strUserName)
        //{
        //    IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> strResult = new List<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission>();
        //    SqlConnection con = new SqlConnection(DataBaseHelper.ConnectionString);
        //    SqlCommand cmd = new SqlCommand("select vchFullName,intUserId FROM M_POR_User WHERE bitStatus=1 and vchFullName like  @SearchText+'%'",con);
        //    cmd.Parameters.AddWithValue("@SearchText", strUserName);
        //    con.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objPermission = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
        //        {
        //            UserName = Convert.ToString(dr["vchFullName"].ToString()),
        //            UserID = Convert.ToInt16(dr["intUserId"].ToString())

        //        };
        //        strResult.Add(objPermission);

        //    }
        //    return strResult;
        //}
        //public override IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> GetPermissionUsers(BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objSetPermission)
        //{
        //    IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> strResult = new List<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission>();
        //    try
        //    {
        //        IDataReader dr = (IDataReader)this.objComnDll.ExeReader(this.strConString, "KAC.usp_LinkAccess_View", "Recordset", new object[] { "chrActionCode", objSetPermission.Action, "@vchSearchText", objSetPermission.UserName });
        //        while (dr.Read())
        //         {
        //             BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objPermission = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
        //             {
        //                 UserName = Convert.ToString(dr["vchFullName"].ToString()),
        //                 UserID = Convert.ToInt16(dr["intUserId"].ToString())

        //             };
        //             strResult.Add(objPermission);
        //         }
        //    }
        //    catch { }
        //    finally
        //    {

        //    }
        //    return strResult;
        //}
        //public override List<string> getAllUserList(string strUserName)
        //{
        //    List<string> result = new List<string>();
        //    return result;
        //}

        //public override IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> GetAllusers_Assignlink(string strGrUID, string strGrDeptID)
        //{
        //    IList<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission> strResult = new List<BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission>();
        //    try
        //    {
        //        IDataReader dr = (IDataReader)this.objComnDll.ExeReader(this.strConString, "SELECT DISTINCT * FROM KAC.UDF_GetAllUserByLocId('" + strGrUID + "','" + strGrDeptID + "')");
        //        while (dr.Read())
        //        {
        //            BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission objPermission = new BUIDCO.Domain.AdminConsole.Set_Permission.Set_Permission
        //            {
        //                GroupUserId = Convert.ToString(dr["U_ID"].ToString()),
        //            };
        //            strResult.Add(objPermission);
        //        }
        //    }
        //    catch { }
        //    finally
        //    {

        //    }
        //    return strResult;
        //}
    }
}