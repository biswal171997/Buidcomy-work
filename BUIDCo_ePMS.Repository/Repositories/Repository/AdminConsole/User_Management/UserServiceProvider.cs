using BUIDCO.Domain.AdminConsole.User_Management;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management;
using System;
using System.Collections.Generic;
using System.Data;

namespace BUIDCO.Repository.AdminConsole.User_Management
{
    public  class UserServiceProvider : BaseProvider, IUserServiceProvider
    {
        #region Variable Declaration
        object param = new object();
        int intOutput = 0;
        string StrQuery = "";

        #endregion
        public UserServiceProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }
        public int CreateUser(User objUser)
        {
            try
            {
                object[] arrUser = { "chrActionCode", objUser.ActionCode, 
                                     "intUserId", objUser.GetID,
                                     "vchUserName",objUser.UserName,
                                     "vchPassword",objUser.UserPasswaord,
                                     "vchFullName",objUser.FullName,
                                     "intLevelDetailId",objUser.DepartmentID,
                                     "intDesigId",objUser.intDesignationID,
                                     "dtmDoj",objUser.DateOfJoing,
                                     "dtmDob",objUser.DateOfBirth,
                                     "vchPreAddress",objUser.PrsentAddress,
                                     "vchOffTel",objUser.OfficeTelephone,
                                     "vchMobTel",objUser.Mobile,
                                     "vchEmail",objUser.email,
                                     "intRptUserId",objUser.ReportingUserId,
                                     "bitAdminPrevil",objUser.AdminPrevilliage,
                                     "intLocation",objUser.intLocation,
                                     "bitSubAdminPrevil",objUser.SubAdminPrevillage,
                                     "bitAttendance",objUser.Attendance,
                                     "vchGender",objUser.Gender,
                                     "vchDomainUName",objUser.DomainUserName,
                                     "vchOfficeId",objUser.OfficeID,
                                     "vchEmpCode",objUser.EmployeeCode,
                                     "intGradeId",objUser.GradeId,
                                     "bitPayroll",objUser.Payroll,
                                     "bitEPF",objUser.EPF,
                                     "intShiftId",objUser.ShiftID,
                                     "intCreatedBy",objUser.CreatedBy,
                                     "vchUserImage",objUser.UserImage,
                                     //"intUserType",objUser.UserType
                                   };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage",out param, arrUser);
                intOutput = Convert.ToInt32(param);

            }
            catch (Exception ex)
            {
               throw new Exception("Execution Failed", ex); ;
            }
            return intOutput;
        }
        /// Author-Subrat Acharya
        /// Method-Edit User
        /// Date-24-May-2010
        /// Modified By Pratik On 02-Jul-2010 to use PDK function
        public int EditUser(User objUser)
        {
            try
            {
                object[] arrUser = { "chrActionCode", objUser.ActionCode, 
                                     "intUserId", objUser.GetID,
                                     "intHierarchyId",objUser.HierarchyId,
                                     "intLevelId",objUser.LevelId,
                                     "nvchUsername",objUser.UserName,
                                     "vchPassword",objUser.UserPasswaord,
                                     "nvchFullname",objUser.FullName,
                                     "vchDeptId",objUser.DepartmentID,
                                     "intDesigId",objUser.intDesignationID,
                                     "intAccesslevel",objUser.AccessLevel,
                                     "dtmDoj",objUser.DateOfJoing,
                                     "dtmdob",objUser.DateOfBirth,
                                     "vchSecurity",objUser.security,
                                     "nvchAddlDept",objUser.AdditionalDepartment,
                                     "nvchPreAddress",objUser.PrsentAddress,
                                     "vchOfftel",objUser.OfficeTelephone,
                                     "vchMobtel",objUser.Mobile,
                                     "vchEmail",objUser.email,
                                     "vchRptDept",objUser.ReportDepartment,
                                     "vchRptAccl",objUser.RepotingptAccesslable,
                                     "intRptUserId",objUser.ReportingUserId,
                                     "intTmpRptUserId",objUser.TempReportingUserId,
                                     "vchStatus",objUser.status,
                                     "bitAdminPrevil",objUser.AdminPrevilliage,
                                     "intLocation",objUser.intLocation,
                                     "bitSubAdminPrevil",objUser.SubAdminPrevillage,
                                     "vchSecretary",objUser.Secretary,
                                     "nvchReligion",objUser.Religion,
                                     "bitAttendance",objUser.Attendance,
                                     "vchGender",objUser.Gender,
                                     "vchaddlResponsibilities",objUser.AdditionalResponsibilities,
                                     "intOptRptUserId",objUser.OptionalReportingUserId,
                                     "vchSectionID1",objUser.SectionID,
                                     "vchType",objUser.Type,
                                     "vchDomainUName",objUser.DomainUserName,
                                     "vchOfficeId",objUser.OfficeID,
                                     "vchEmpCode",objUser.EmployeeCode,
                                     "vchExchUser",objUser.ExchangeUser,
                                     "vchExchPassword",objUser.EschangePassword,
                                     "vchRType",objUser.ReportingType,
                                     "dtmPCDate",objUser.ProbationCompleteDate,
                                     "vchRStatus",objUser.Reignationstatus,
                                     "dtmLeavingDate",objUser.LeavingDate,
                                     "intGradeId",objUser.GradeId,
                                     "nvchReason",objUser.Reason,
                                     "bitPayroll",objUser.Payroll,
                                     "bitEPF",objUser.EPF,
                                     "intShiftId",objUser.ShiftID,
                                     "intCreatedBy",objUser.CreatedBy,
                                     "vchFatherNameEnglish",objUser.FatherNameEnglish,
                                     "vchFatherNameAmharic",objUser.FatherNameAmharic,
                                     "vchGrandFatherNameEnglish",objUser.FatherNameEnglish,
                                     "vchGrandFatherNameAmharic",objUser.FatherNameAmharic,
                                     "UserImage",objUser.UserImage,
                                     "intUserType",objUser.UserType
                                   };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage",out param, arrUser);
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }
            return intOutput;
        }
        /// Author-Subrat Acharya
        /// Method-Delete User
        /// Date-24-May-2010
        /// Modified By Pratik On 02-Jul-2010 to use PDK function
        public int DeleteUser(User objUser)
        {

            try
            {
                object[] arrUser = { "chrActionCode", objUser.ActionCode, "vchUserIDs", objUser.UserID,
                                     "intCreatedBy",objUser.CreatedBy,"intOutput",0
                                   };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage",out param, arrUser);
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }
            return intOutput;
        }
        /// Author-Subrat Acharya
        /// Method-Activate User
        /// Date-25-May-2010
        /// Modified By Pratik On 02-Jul-2010 to use PDK function
        public int ActivateUser(User objUser)
        {
            try
            {
                object[] arrUser = { "chrActionCode", objUser.ActionCode, "intUserId", objUser.GetID,
                                     "intCreatedBy",objUser.CreatedBy
                                   };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage",out param, arrUser);
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }
            return intOutput;
        }
        /// Author-Subrat Acharya
        /// Method-Deactivate User
        /// Date-25-May-2010
        /// Modified By Pratik On 02-Jul-2010 to use PDK function
        public int DeActivateUser(User objUser)
        {
            try
            {
                object[] arrUser = { "chrActionCode", objUser.ActionCode, "intUserId", objUser.GetID,
                                     "intCreatedBy",objUser.CreatedBy
                                   };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage",out param, arrUser);
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }
            return intOutput;
        }
        /// Author-Subrat Acharya
        /// Method-Get all User
        /// Date-25-May-2010
        /// Modified By Pratik On 02-Jul-2010 to use PDK function
        public IList<User> GetAllUsers(User objUser)
        {
           
            List<User> UserList = new List<User>();
            try
            {
                object[] arrUser = { "chrActionCode",objUser.ActionCode,"intUserId",Convert.ToInt32(objUser.UserID),
                                     "intLevelId",objUser.LevelId,"intDeptId",Convert.ToInt32(objUser.DepartmentID),"vchUserName",objUser.FullName
                                   };
                IDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage_View",  arrUser);

                while (objDataReader.Read())
                {
                    if (objUser.ActionCode == "V")
                    {
                        UserList.Add(new User
                        {

                            GetID = Convert.ToInt32(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                            UserName = Convert.ToString(objDataReader["vchUserName"] == DBNull.Value ? "" : objDataReader["vchUserName"]),
                            HierarchyId = Convert.ToInt32(objDataReader["intHierarchyId"] == DBNull.Value ? 0 : objDataReader["intHierarchyId"]),
                            LevelId = Convert.ToInt32(objDataReader["intLevelID"] == DBNull.Value ? 0 : objDataReader["intLevelID"]),
                            UserPasswaord = Convert.ToString(objDataReader["vchPassWord"] == DBNull.Value ? "" : objDataReader["vchPassWord"]),
                            FullName = Convert.ToString(objDataReader["vchFullName"] == DBNull.Value ? "" : objDataReader["vchFullName"]),
                            DepartmentID = Convert.ToString(objDataReader["intLevelDetailId"] == DBNull.Value ? "" : objDataReader["intLevelDetailId"]),
                            DesignationID = Convert.ToString(objDataReader["intDesignationId"] == DBNull.Value ? "" : objDataReader["intDesignationId"]),
                            DateOfJoing = Convert.ToDateTime(objDataReader["dtmDoj"]).ToString(),
                            DateOfBirth = Convert.ToDateTime(objDataReader["dtmDob"]).ToString(),
                            //DateOfJoing = Convert.ToDateTime(objDataReader["dtmDoj"]),
                            //DateOfBirth = Convert.ToDateTime(objDataReader["dtmDob"]),
                            PrsentAddress = Convert.ToString(objDataReader["vchPreAddress"] == DBNull.Value ? "" : objDataReader["vchPreAddress"]),
                            OfficeTelephone = Convert.ToString(objDataReader["vchOffTel"] == DBNull.Value ? "" : objDataReader["vchOffTel"]),
                            Mobile = Convert.ToString(objDataReader["vchMobTel"] == DBNull.Value ? "" : objDataReader["vchMobTel"]),
                            email = Convert.ToString(objDataReader["vchEmail"] == DBNull.Value ? "" : objDataReader["vchEmail"]),
                            ReportingUserId = Convert.ToInt32(objDataReader["intraUserId"] == DBNull.Value ? 0 : objDataReader["intraUserId"]),
                            AdminPrevilliage = Convert.ToString(objDataReader["bitAdminPrevil"] == DBNull.Value ? "" : objDataReader["bitAdminPrevil"]),
                            intLocation = Convert.ToInt32(objDataReader["intLocationId"] == DBNull.Value ? 0 : objDataReader["intLocationId"]),
                            SubAdminPrevillage = Convert.ToString(objDataReader["intSubAdminPrevil"] == DBNull.Value ? "" : objDataReader["intSubAdminPrevil"]),
                            Attendance = Convert.ToString(objDataReader["bitAttendance"] == DBNull.Value ? "" : objDataReader["bitAttendance"]),
                            Gender = Convert.ToString(objDataReader["vchGender"] == DBNull.Value ? "" : objDataReader["vchGender"]),
                            DomainUserName = Convert.ToString(objDataReader["vchDomainUName"] == DBNull.Value ? "" : objDataReader["vchDomainUName"]),
                            EmployeeCode = Convert.ToString(objDataReader["vchEmpCode"] == DBNull.Value ? "" : objDataReader["vchEmpCode"]),
                            GradeId = Convert.ToInt32(objDataReader["intGradeId"] == DBNull.Value ? "" : objDataReader["intGradeId"]),
                            GradeName = Convert.ToString(objDataReader["vchGradeName"] == DBNull.Value ? "" : objDataReader["vchGradeName"]),
                            Payroll = Convert.ToString(objDataReader["bitPayroll"] == DBNull.Value ? "" : objDataReader["bitPayroll"]),
                            UserImage = Convert.ToString(objDataReader["vchUserImage"] == DBNull.Value ? "" : objDataReader["vchUserImage"]),
                           // UserType = Convert.ToInt32(objDataReader["intUserType"] == DBNull.Value ? "0" : objDataReader["intUserType"])
                        }
                       );
                    }
                    if ((objUser.ActionCode == "F") || (objUser.ActionCode == "T") || (objUser.ActionCode == "I"))
                    {
                        UserList.Add(new User
                        {
                            GetID = Convert.ToInt32(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                            ShiftID = Convert.ToInt32(objDataReader["id"] == DBNull.Value ? 0 : objDataReader["id"]),
                            UserName = Convert.ToString(objDataReader["vchusername"] == DBNull.Value ? "" : objDataReader["vchusername"]),
                            FullName = Convert.ToString(objDataReader["vchfullname"] == DBNull.Value ? "" : objDataReader["vchfullname"]),
                            DepartmentID = Convert.ToString(objDataReader["nvchLevelName"] == DBNull.Value ? "" : objDataReader["nvchLevelName"]),
                            DesignationID = Convert.ToString(objDataReader["nvchdesigname"] == DBNull.Value ? "" : objDataReader["nvchdesigname"]),
                            GradeName = Convert.ToString(objDataReader["vchGradeName"] == DBNull.Value ? "" : objDataReader["vchGradeName"]),
                            status = Convert.ToString(objDataReader["statusFlag"] == DBNull.Value ? "" : objDataReader["statusFlag"]),
                        }
                          );
                    }
                    if (objUser.ActionCode == "E")
                    {
                        UserList.Add(new User
                        {

                            GetID = Convert.ToInt32(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                            UserName = Convert.ToString(objDataReader["vchusername"] == DBNull.Value ? "" : objDataReader["vchusername"])
                        }
                        );
                    }

                    if (objUser.ActionCode == "E1")
                    {
                        UserList.Add(new User
                        {

                            GetID = Convert.ToInt32(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                            FullName = Convert.ToString(objDataReader["vchfullname"] == DBNull.Value ? "" : objDataReader["vchfullname"]),
                        }
                        );
                    }
                }
               

            }

            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }
            return UserList;
        }
        /// <summary>
        /// Method to get fullname from user id
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public string GetFullNameFromId(int intUserId)
        {
            string strUserId = null;
            string strUserName = null;
            List<IUserServiceProvider> UserList = new List<IUserServiceProvider>();
            try
            {
                object[] arrUser = { "chrActionCode","N","intUserId",intUserId,
                                     "intLevelId",0,"intDeptId",0,"vchUserName",""
                                   };
                IDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_UserMaster_Manage_View", arrUser);

                while (objDataReader.Read())
                {
                    strUserId = Convert.ToString(objDataReader["int_UserId"] == DBNull.Value ? 0 : objDataReader["int_UserId"]);
                    strUserName = Convert.ToString(objDataReader["fullname"] == DBNull.Value ? "" : objDataReader["fullname"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }
            return strUserId + "~" + strUserName;
        }

        public IList<User> GetDetails(User objUser)
        {
            List<User> objUserList = new List<User>();

            object[] arrUser = { "chrActionCode", objUser.ActionCode, "intID", objUser.HierarchyId };
            IDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_Admin_Populate",  arrUser);
            try
            {
                while (objDataReader.Read())
                {
                    if (objUser.ActionCode == "P")
                    {
                        objUserList.Add(new User
                        {
                            PositionId = Convert.ToInt32(objDataReader["int_Position"] == DBNull.Value ? 0 : objDataReader["int_Position"])
                        }
                          );
                    }
                    if (objUser.ActionCode == "L")
                    {

                        objUserList.Add(new User
                        {
                            LevelName = Convert.ToString(objDataReader["nvch_Label"] == DBNull.Value ? "" : objDataReader["nvch_Label"])
                        }
                         );
                    }
                    if (objUser.ActionCode == "I")
                    {

                        objUserList.Add(new User
                        {
                            ParentId = Convert.ToInt32(objDataReader["int_PldId"] == DBNull.Value ? "" : objDataReader["int_PldId"])
                        }
                         );
                    }
                    if (objUser.ActionCode == "F")
                    {

                        objUserList.Add(new User
                        {
                            LeveleID = Convert.ToInt32(objDataReader["int_leveldetailid"] == DBNull.Value ? 0 : objDataReader["int_leveldetailid"]),
                            LevelName = Convert.ToString(objDataReader["nvch_LevelName"] == DBNull.Value ? "" : objDataReader["nvch_LevelName"])
                        }
                         );
                    }
                    if (objUser.ActionCode == "U")
                    {

                        objUserList.Add(new User
                        {
                            UserID = Convert.ToString(objDataReader["userid"] == DBNull.Value ? 0 : objDataReader["userid"]),
                            FullName = Convert.ToString(objDataReader["fullname"] == DBNull.Value ? "" : objDataReader["fullname"])
                        }
                         );
                    }
                }
                objDataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex); ;
            }

            return objUserList;
        }

        public IList<User> PopUpDropDown1()
        {
            IList<User> list = new List<User>();
            try
            {

                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, "select intLocationId,nvchLocation from M_ADM_Location where bitStatus=1 ORDER BY nvchLocation");
                while (reader.Read())
                {
                    User item = new User
                    {
                        intLocation = Convert.ToInt32(reader["intLocationId"].ToString()),
                        Location = reader["nvchLocation"].ToString(),

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
        public int GetLevelDTlID(string LvlDtlId)
        {


            if (LvlDtlId != "0")
            {
                string strQr = "select intLevelDetailId from M_ADM_LevelDetails where intLevelDetailId=" + LvlDtlId + "";
               // string levelid = SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, strQr, 0).ToString();
                return (int)SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, strQr, 0);
            }
            else
            {
                return 0;
            }
            
          
        }

        public int GetPosition(string LevelId)
        {
            string strQr = "select intPosition from M_ADM_Level where intLevelId=" + LevelId;
            return (int)SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString,System.Data.CommandType.Text, strQr);
        }
        public int GetSubAdminPrev(string userid)
        {
            string strQr = "select bitSubAdminPrevil from M_POR_User where intUserId=" + userid;
            return (int)SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, strQr, 0);
        }
        public IList<User> PopUpDropDown3(string Id)
        {
            IList<User> list = new List<User>();
            try
            {

                object[] objArray = new object[] { "int_HierarchyId", Id };
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GetDesignationByLoc",  objArray);
                while (reader.Read())
                {
                    User item = new User
                    {
                        intDesignationID = Convert.ToInt32(reader["intDesigId"].ToString()),
                        FullName = reader["nvchdesigname"].ToString()//For Designame 


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
        public IList<User> PopUpDropDown4(string Id)
        {
            IList<User> list = new List<User>();
            try
            {

                object[] objArray = new object[] { "int_HierarchyId", Id };
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GetGradeByLoc",  objArray);
                while (reader.Read())
                {
                    User item = new User
                    {
                        GradeId = Convert.ToInt32(reader["intGradeId"].ToString()),
                        GradeName = reader["vchGradeName"].ToString()//For Designame 


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
        public IList<User> GetDesigInfo(string Id)
        {
            IList<User> list = new List<User>();
            try
            {

                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, "select M.intDesigId,M.nvchDesigName from M_ADM_Designation M join T_ADM_Designation T on M.intDesigId=T.intDesignationId where intHierarchyId=" + Id.ToString());
                while (reader.Read())
                {
                    User item = new User
                    {
                        intDesignationID = Convert.ToInt32(reader["intDesigId"].ToString()),
                        FullName = reader["nvchDesigName"].ToString()//For Designame 


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
        public IList<User> GetTGradeDetail(string Id)
        {
            IList<User> list = new List<User>();
            try
            {

                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, "SELECT M.intGradeId,M.vchGradeName from M_ADM_Grade M join T_ADM_Grade T on M.intGradeId=T.intGradeId where intHierarchyId=" + Id.ToString());
                while (reader.Read())
                {
                    User item = new User
                    {
                        GradeId = Convert.ToInt32(reader["intGradeId"].ToString()),
                        GradeName = reader["vchGradeName"].ToString()//For Designame 


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
        public IList<User> UserGetLevel(string Id)
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQryLevel = "SELECT intNolevel from M_Adm_Hierarchy where bitStatus=1 and  inthierarchyid=(Select inthierarchyid from M_Adm_Level where bitStatus=1 and  intLevelId=(Select intLevelId from M_Adm_LevelDetails where bitStatus=1 and  intleveldetailid=" + Id + ")) ";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQryLevel);
                while (reader.Read())
                {
                    User item = new User
                    {
                        GradeId = Convert.ToInt32(reader["intNolevel"].ToString()),



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
        public IList<User> GetPosition2(string Id)
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQryLevel = "SELECT intPosition from M_Adm_Level where bitStatus=1 and intLevelId=(Select intLevelId from M_Adm_LevelDetails where bitStatus=1 and  intleveldetailid=" + Id + ")";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQryLevel);
                while (reader.Read())
                {
                    User item = new User
                    {
                        PositionId = Convert.ToInt32(reader["intPosition"].ToString())



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
        public IList<User> UserGetHierarchyID(string Id)
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQryLevel = " select intHierarchyId from M_Adm_Hierarchy where intHierarchyId in (select intHierarchyId from M_Adm_Level where intLevelId in (select intLevelId from M_Adm_LevelDetails where intLevelDetailId=" + Id + " ))";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQryLevel);
                while (reader.Read())
                {
                    User item = new User
                    {
                        PositionId = Convert.ToInt32(reader["intHierarchyId"].ToString())//Hierarchy ID



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
        public IList<User> UserGetParentID(string Id)
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQryLevel = "SELECT intParentId from M_Adm_LevelDetails where intleveldetailid=" + Id + " and bitStatus=1 ";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQryLevel);
                while (reader.Read())
                {
                    User item = new User
                    {
                        ParentId = Convert.ToInt32(reader["intParentId"].ToString())//Hierarchy ID



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
        public IList<User> PopUpDropDown5(string Id)
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQryLevel = "SELECT intleveldetailid,nvchLevelName from M_Adm_LevelDetails where intParentId=" + Id + " and bitStatus=1 ";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQryLevel);
                while (reader.Read())
                {
                    User item = new User
                    {
                        LevelId = Convert.ToInt32(reader["intleveldetailid"].ToString()),
                        LevelName = reader["vchGradeName"].ToString()




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
        public IList<User> PopUpDropDown6()
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQryLevel = "SELECT intOfficeId, vchName FROM M_OfficeDirectory WHERE bitStatus=1 ORDER BY vchName ASC";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQryLevel);
                while (reader.Read())
                {
                    User item = new User
                    {
                        intLocation = Convert.ToInt32(reader["intOfficeId"].ToString()),
                        FullName = reader["vchName"].ToString()




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
        public IList<User> PopUpDropDown7()
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from M_Admin_LevelDetails A,M_Admin_Level B where  A.intLevelId=B.intLevelId AND A.intParentId=0";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQuery);
                while (reader.Read())
                {
                    User item = new User
                    {
                        LevelId = Convert.ToInt32(reader["intLevelDetailId"].ToString()),
                        LevelName = reader["nvchLevelName"].ToString()




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
        public IList<User> PopUpDropDown8()
        {
            IList<User> list = new List<User>();
            try
            {
                string StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from M_Adm_LevelDetails A,M_Adm_Level B where  A.intLevelId=B.intLevelId AND A.intParentId=0";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQuery);
                while (reader.Read())
                {
                    User item = new User
                    {
                        LevelId = Convert.ToInt32(reader["intLevelDetailId"].ToString()),
                        LevelName = reader["nvchLevelName"].ToString()




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
        public IList<User> PopUpDropDown9(string Id)
        {
            IList<User> list = new List<User>();
            try
            {
                string strQryLevelName = "Select nvchLabel from M_Adm_Level where bitStatus=1 and intLevelId = (Select intLevelId from M_Adm_LevelDetails where bitStatus=1 and intLevelDetailId=" + Id + ")";
                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, strQryLevelName);
                while (reader.Read())
                {
                    User item = new User
                    {

                        LevelName = reader["nvchLabel"].ToString()




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
        public string Message(string strActionCode, string strDuplicVal, string strUserId)
        {

            try
            {
                object[] objParam = { "P_CHARACTIONTYPE", strActionCode, "P_DUPLICATETEXT", strDuplicVal, "@P_USERID", strUserId };
                return SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, "USP_CHECKDUPLIC_USERNAME_EMAIL_DOMAIN", objParam).ToString();

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }

        }
        public IList<User> FillPermissionReport(int Location, int Access, int Plink)
        {
            IList<User> list = new List<User>();
            try
            {

                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, "Select DISTINCT u.intUserId,u.vchFullName,h.nvchHierarchyName,a.nvchLevelName from M_POR_User u,M_Adm_Hierarchy h, M_ADM_LinkAccess l,M_Adm_LevelDetails a,M_ADM_Level B  where  a.intLevelDetailId=u.intLevelDetailId and a.intLevelId=b.intLevelId  and b.intHierarchyId=h.intHierarchyId and u.intLocationId=" + Location + " and h.bitStatus=1 and l.tinAccess=" + Access + "  and u.intUserId=l.intUserID and l.bitStatus=1 and  intPlinkId=" + Plink + " order by u.vchFullName");
                while (reader.Read())
                {
                    User item = new User
                    {
                        UserID = reader["intUserId"].ToString(),
                        FullName = reader["vchFullName"].ToString(),
                        UserName = reader["nvchHierarchyName"].ToString(),
                        LevelName = reader["nvchLevelName"].ToString()


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
        public IList<User> FillParentSO(int Location)
        {
            IList<User> list = new List<User>();
            try
            {

                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, "Select intLevelDetailId,a.intUserId,a.intrptUserId,a.vchUserName,a.vchFullName,b.nvchDesigName from M_POR_User a left outer join M_ADM_Designation b on a.intDesignationId=b.intDesigId where a.bitStatus=1 AND a.intRptUserId=0 AND (select dbo.UDF_GetparentId(intLevelDetailId))=" + Location + "");
                while (reader.Read())
                {
                    User item = new User
                    {
                        UserID = reader["intUserId"].ToString(),
                        ReportingUserName = reader["intrptUserId"].ToString(),
                        DesignationID = reader["nvchDesigName"].ToString(),
                        UserName = reader["vchFullName"].ToString()

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
        public IList<UserDetail> GetLevelDetailsByuser(int ParentId)
        {
            throw new NotImplementedException();
        }
        public IList<User> FillChildSO(int RptID)
        {
            IList<User> list = new List<User>();
            try
            {

                IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, "Select a.intUserId,a.intrptUserId,a.vchUserName,a.vchFullName,b.nvchdesigname,c.nvchHierarchyName from M_POR_User a left outer join M_ADM_Designation b on a.intDesignationId=b.intDesigId left outer join M_Adm_Hierarchy c on (select dbo.UDF_GetparentId(intLevelDetailId))=c.intHierarchyId where  a.bitStatus=1  AND c.bitStatus=1 AND  a.intrptUserId=" + RptID + "");
                while (reader.Read())
                {
                    User item = new User
                    {
                        UserID = reader["intUserId"].ToString(),
                        ReportingUserName = reader["intrptUserId"].ToString(),
                        DesignationID = reader["nvchDesigName"].ToString(),
                        UserName = reader["vchFullName"].ToString(),
                        Location = reader["nvchHierarchyName"].ToString()


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
        public IList<User> FillUserRA()
        {
            List<User> list = new List<User>();
            StrQuery = "select intUserId,vchFullName from M_POR_User where bitStatus=1 order by vchFullName";
            IDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, CommandType.Text, StrQuery);

            try
            {
                while (reader.Read())
                {
                    User item = new User
                    {
                        UserID = reader["intUserId"].ToString(),
                        UserName = reader["vchFullName"].ToString()
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

        public IList<LevelDetail> GetLevelDetails(int hirachyId)
        {
            throw new NotImplementedException();
        }

        public IList<LevelDetail> GetLevelDetailsByParentId(int ParentId)
        {
            throw new NotImplementedException();
        }

        public IList<Location> GetLocation()
        {
            throw new NotImplementedException();
        }

        public IList<Designation> GetDesignations()
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUserById(int UserId, string ActionCode)
        {
            throw new NotImplementedException();
        }

        public int ValidateUser(User user)
        {
            throw new NotImplementedException();
        }
        public int LDAPValidateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserInfo(User user)
        {
            throw new NotImplementedException();
        }
        public User LDAPGetUserInfo(User user)
        {
            throw new NotImplementedException();
        }
        public IList<USEREXPORT> GetuserExport()
        {
            throw new NotImplementedException();
        }
        public int ChangePasswod(User user)
        {
            throw new NotImplementedException();
        }

        public IList<LinkAccess> GetLinkAccessByUserId(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}