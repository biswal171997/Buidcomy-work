using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Xml;

namespace BUIDCO.Repository.AdminConsole.Login
{
    public class LoginServiceProvider : BaseProvider, ILoginServiceProvider
    {
        #region Variable Declaration
        object param = new object();
        #endregion

        public LoginServiceProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }

        public Task<IList<BUIDCO.Domain.AdminConsole.Login.Login>> LoginUser(string ActionCode, string strUserName, string strPassword, int intLocID, string ipAddress)
        {
            DbDataReader objDataReader;
            IList<BUIDCO.Domain.AdminConsole.Login.Login> UserList = new List<BUIDCO.Domain.AdminConsole.Login.Login>();

            try
            {
                object[] arrUser = { "chrActionCode", ActionCode, "vchUserName", strUserName,
                                     "vchPassword",strPassword,"intLocId",intLocID,"@USERIPADDRESS", ipAddress
                                   };
                objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "USP_USERMASTER_VIEW", arrUser);

                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {

                        if (ActionCode == "V")
                        {
                            UserList.Add(new BUIDCO.Domain.AdminConsole.Login.Login
                            {
                                GetID = Convert.ToInt32(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                                HID = Convert.ToInt32(objDataReader["intHierarchyId"] == DBNull.Value ? 0 : objDataReader["intHierarchyId"]),
                                LevelId = Convert.ToInt32(objDataReader["intlevelid"] == DBNull.Value ? 0 : objDataReader["intlevelid"]),
                                UserID = Convert.ToString(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                                //Type = Convert.ToString(objDataReader["vchType"] == DBNull.Value ? 0 : objDataReader["vchType"]),
                                AdminPrev = Convert.ToString(objDataReader["bitAdminPrevil"] == DBNull.Value ? 0 : objDataReader["bitAdminPrevil"]),
                                SubAdminPrev = Convert.ToString(objDataReader["bitSubAdminPrevil"] == DBNull.Value ? 0 : objDataReader["bitSubAdminPrevil"]),
                                AccessLev = Convert.ToString(objDataReader["intAccessLevel"] == DBNull.Value ? 0 : objDataReader["intAccessLevel"]),
                                Security = Convert.ToString(objDataReader["vchSecurity"] == DBNull.Value ? 0 : objDataReader["vchSecurity"]),
                                UserName = Convert.ToString(objDataReader["vchUserName"] == DBNull.Value ? 0 : objDataReader["vchUserName"]),
                                Password = Convert.ToString(objDataReader["vchPassWord"] == DBNull.Value ? 0 : objDataReader["vchPassWord"]),
                                FullName = Convert.ToString(objDataReader["vchFullName"] == DBNull.Value ? 0 : objDataReader["vchFullName"]),
                                DepartmentID = Convert.ToString(objDataReader["deptid"] == DBNull.Value ? 0 : objDataReader["deptid"]),
                                strDepartment = Convert.ToString(objDataReader["DEPT"] == DBNull.Value ? 0 : objDataReader["DEPT"]),
                                strPID = Convert.ToString(objDataReader["PID"] == DBNull.Value ? 0 : objDataReader["PID"]),
                                DesigID = Convert.ToInt32(objDataReader["intdesignationid"] == DBNull.Value ? 0 : objDataReader["intdesignationid"]),
                                Locid = Convert.ToInt32(objDataReader["location"] == DBNull.Value ? 0 : objDataReader["location"]),
                                email = Convert.ToString(objDataReader["vchEmail"] == DBNull.Value ? 0 : objDataReader["vchEmail"])
                            }

                                );
                        }
                        if (ActionCode == "L")
                        {
                            UserList.Add(new BUIDCO.Domain.AdminConsole.Login.Login
                            {

                                Locid = Convert.ToInt32(objDataReader["intLevelDetailId"] == DBNull.Value ? 0 : objDataReader["intLevelDetailId"]),
                                Location = Convert.ToString(objDataReader["nvchLevelName"] == DBNull.Value ? 0 : objDataReader["nvchLevelName"]),
                                //Locdiff = Convert.ToString(objDataReader["locDiff"])
                            }
                              );
                        }

                        if (ActionCode == "D")
                        {
                            UserList.Add(new BUIDCO.Domain.AdminConsole.Login.Login
                            {
                                Locid = Convert.ToInt32(objDataReader["intLevelDetailId"] == DBNull.Value ? 0 : objDataReader["intLevelDetailId"])
                                //Locdiff = Convert.ToString(objDataReader["locDiff"])
                            }
                              );
                        }

                        if (ActionCode == "O")
                        {
                            UserList.Add(new BUIDCO.Domain.AdminConsole.Login.Login
                            {
                                dtStartTime = Convert.ToDateTime(objDataReader["vchStartTime"] == DBNull.Value ? 0 : objDataReader["vchStartTime"]),
                                dtEndTime = Convert.ToDateTime(objDataReader["vchEndTime"] == DBNull.Value ? 0 : objDataReader["vchEndTime"]),
                                dtRecessFrom = Convert.ToDateTime(objDataReader["vchRecessFrom"] == DBNull.Value ? 0 : objDataReader["vchRecessFrom"]),
                                dtRecessTo = Convert.ToDateTime(objDataReader["vchRecessTo"] == DBNull.Value ? 0 : objDataReader["vchRecessTo"]),
                                dtTimeZone = Convert.ToInt32(objDataReader["intTimeZone"] == DBNull.Value ? 0 : objDataReader["intTimeZone"])

                            }
                              );
                        }


                    }
                    objDataReader.Close();
                }
            }

            //catch (CustomException customEx)
            //{
            //    throw customEx;
            //}
            catch (Exception ex)
            {
                throw ex;// new CustomException("Execution Failed", ex);
            }
            return Task.FromResult(UserList);
        }


        public Task<string> GetUserAccess(int intUserId)
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
            return Task.FromResult(xml);
        }
        public int IpTracking(BUIDCO.Domain.AdminConsole.Login.IPTrack objiptrack)
        {
            int intreturnval = 0;
            try
            {
                

                object[] objArray = {
                                    "chrActionCode",objiptrack.ActionCode ,"Id",objiptrack.Id,
                                    "IpAddress",objiptrack.IpAddress,
                                    "CreatedBy",objiptrack.UserId                                    
                                 };
                intreturnval = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_IpTracking_manage",out param, objArray);
                intreturnval = Convert.ToInt32(param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return intreturnval;
        }

        public string GetLoginLogo()
        {
            string strLogo;
            try
            {
                strLogo = Convert.ToString(SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, "SELECT LOGO FROM  M_POR_CUSTOMIZE", 0));                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strLogo;
        }
        public string GetLoginHeader()
        {
            string HEADER;
            try
            {
                HEADER = Convert.ToString(SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, "SELECT HEADER FROM  M_POR_CUSTOMIZE", 0));
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HEADER;
        }
        public string GetLoginFooter()
        {
            string Footer;
            try
            {
                Footer = Convert.ToString(SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, "SELECT Footer FROM  M_POR_CUSTOMIZE", 0));
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Footer;
        }
    }
}