using Dapper;
using BUIDCO.Domain.AdminConsole.User_Management;
using BUIDCO.Domain.Common;
using BUIDCO.Repository;
using BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AdminConsoleCore.Persistence.User_Management
{
    public class UserServiceProviderOracle : RepositoryBase, IUserServiceProvider
    {
        #region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        object param = new object();
       // int intOutput = 0;

        #endregion
        public UserServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public int ActivateUser(User objUser)
        {
            throw new NotImplementedException();
        }

        public int ChangePasswod(User user)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, user.ActionCode);
                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, Convert.ToInt32(user.UserID));
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, user.CreatedBy);
                aParam.Add("v_vchPassword", MySqlDbType.VarChar, ParameterDirection.Input, user.UserPasswaord);
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);
                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public int CreateUser(User objUser)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objUser.ActionCode);
                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, objUser.intuserid);
                aParam.Add("iv_intGradeId", MySqlDbType.Int32, ParameterDirection.Input, 0); 
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, objUser.UserName);
                aParam.Add("v_vchPassword", MySqlDbType.VarChar, ParameterDirection.Input, objUser.UserPasswaord);
                aParam.Add("v_vchFullName", MySqlDbType.VarChar, ParameterDirection.Input, objUser.FullName);
                //New Parameters added
                aParam.Add("v_intHLocation", MySqlDbType.VarChar, ParameterDirection.Input, objUser.intHLocation);
                aParam.Add("v_intLG", MySqlDbType.VarChar, ParameterDirection.Input, objUser.intLG);
                aParam.Add("v_intDepartment", MySqlDbType.VarChar, ParameterDirection.Input, objUser.intDepartment);                
                //End
                aParam.Add("v_intLevelDetailId", MySqlDbType.Int32, ParameterDirection.Input, objUser.LeveleID);
                //aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, objUser.intLocation);
                aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, 1);
                aParam.Add("v_intDesigId", MySqlDbType.Int32, ParameterDirection.Input, objUser.DesignationID);
                if(objUser.ReportingUserID=="null")
                {
                    aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                }
                else
                {
                    aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, objUser.ReportingUserID);
                }                
                aParam.Add("v_vchGender", MySqlDbType.VarChar, ParameterDirection.Input, objUser.Gender);
                aParam.Add("iv_intIsadmin", MySqlDbType.Int32, ParameterDirection.Input, objUser.ISADMIN);
                aParam.Add("v_dtmDoj", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_dtmDob", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_vchEmail", MySqlDbType.VarChar, ParameterDirection.Input, objUser.email);
                aParam.Add("v_vchMobTel", MySqlDbType.VarChar, ParameterDirection.Input, objUser.Mobile);
                aParam.Add("v_vchUserImage", MySqlDbType.VarChar, ParameterDirection.Input, objUser.UserImage);
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objUser.CreatedBy);
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);
                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public int DeActivateUser(User objUser)
        {
            throw new NotImplementedException();
        }

        public int DeleteUser(User objUser)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objUser.ActionCode);
                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, objUser.intuserid);
                aParam.Add("iv_intGradeId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_vchPassword", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_vchFullName", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_intHLocation", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intLG", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intDepartment", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intLevelDetailId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_intDesigId", MySqlDbType.Int32, ParameterDirection.Input, null);
                aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchGender", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("iv_intIsadmin", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_dtmDoj", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_dtmDob", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_vchEmail", MySqlDbType.VarChar, ParameterDirection.Input, null);
                aParam.Add("v_vchMobTel", MySqlDbType.VarChar, ParameterDirection.Input,null);
                aParam.Add("v_vchUserImage", MySqlDbType.VarChar, ParameterDirection.Input,null);
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objUser.CreatedBy);
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);
                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public int EditUser(User objUser)
        {
            try
            {
                string doj = Convert.ToDateTime(objUser.DateOfJoing).ToString("yyyy/MM/dd");
                string dob = Convert.ToDateTime(objUser.DateOfBirth).ToString("yyyy/MM/dd");
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, objUser.ActionCode);
                aParam.Add("v_intLevelDetailId", MySqlDbType.Int32, ParameterDirection.Input, objUser.LeveleID);
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, objUser.UserName);
                aParam.Add("v_vchFullName", MySqlDbType.VarChar, ParameterDirection.Input, objUser.FullName);
                aParam.Add("v_intDesigId", MySqlDbType.Int32, ParameterDirection.Input, objUser.DesignationID);
                //aParam.Add("v_dtmDoj", MySqlDbType.VarChar, ParameterDirection.Input, doj);
                //aParam.Add("v_dtmDob", MySqlDbType.VarChar, ParameterDirection.Input, dob);
                aParam.Add("v_vchMobTel", MySqlDbType.VarChar, ParameterDirection.Input, objUser.Mobile);
                aParam.Add("v_vchEmail", MySqlDbType.VarChar, ParameterDirection.Input, objUser.email);
                //aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, objUser.intLocation);
                aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, 1);
                aParam.Add("v_vchGender", MySqlDbType.VarChar, ParameterDirection.Input, objUser.Gender);
                aParam.Add("iv_intIsadmin", MySqlDbType.Int32, ParameterDirection.Input, objUser.ISADMIN);
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objUser.CreatedBy);
            //    aParam.Add("v_vchUserImage", MySqlDbType.VarChar, ParameterDirection.Input, objUser.UserImage);
                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, objUser.intuserid);
                aParam.Add("v_intLG", MySqlDbType.Int32, ParameterDirection.Input, objUser.intLG);
                aParam.Add("v_intDepartment", MySqlDbType.Int32, ParameterDirection.Input, objUser.intDepartment);
                aParam.Add("v_intHLocation", MySqlDbType.Int32, ParameterDirection.Input, objUser.intHLocation);

                aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchPassword", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("v_vchPreAddress", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("v_vchOffTel", MySqlDbType.VarChar, ParameterDirection.Input,"");
                aParam.Add("v_bitAdminPrevil", MySqlDbType.Bit, ParameterDirection.Input, false);
                aParam.Add("v_bitSubAdminPrevil", MySqlDbType.Bit, ParameterDirection.Input, false);
                aParam.Add("v_bitAttendance", MySqlDbType.Bit, ParameterDirection.Input, false);
                aParam.Add("v_vchDomainUName", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("v_vchOfficeId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchEmpCode", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("iv_intGradeId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_bitPayroll", MySqlDbType.Bit, ParameterDirection.Input, false);
                aParam.Add("v_bitEPF", MySqlDbType.Bit, ParameterDirection.Input, false);
                aParam.Add("v_intShiftId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public IList<User> FillChildSO(int RptID)
        {
            throw new NotImplementedException();
        }

        public IList<User> FillParentSO(int Location)
        {
            throw new NotImplementedException();
        }

        public IList<User> FillPermissionReport(int Location, int Access, int Plink)
        {
            throw new NotImplementedException();
        }

        public IList<User> FillUserRA()
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers(User objUser)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("p_action", MySqlDbType.VarChar, ParameterDirection.Input, objUser.ActionCode);
                aParam.Add("p_intdesignationid", MySqlDbType.Int32, ParameterDirection.Input, objUser.intDesignationID);
                aParam.Add("p_intlocationid", MySqlDbType.Int32, ParameterDirection.Input, objUser.intLocation);
                aParam.Add("p_vchmobtel", MySqlDbType.VarChar, ParameterDirection.Input, objUser.vchmobtel);
                aParam.Add("p_vchusername", MySqlDbType.VarChar, ParameterDirection.Input, objUser.vchusername);

                aParam.Add("p_intuserid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_intprojectid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_language", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                var query = "USP_USERMASTER_VIEW";
                var result = Connection.Query<User>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.ToList();

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
        public IList<USEREXPORT> GetuserExport()
        {
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("p_action", MySqlDbType.VarChar, ParameterDirection.Input, "EXPORT");

                p.Add("p_intdesignationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("p_intlocationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("p_vchmobtel", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("p_vchusername", MySqlDbType.VarChar, ParameterDirection.Input, "");
                p.Add("p_intuserid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("p_intprojectid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("p_language", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                var query = "USP_USERMASTER_VIEW";
                var result = Connection.Query<USEREXPORT>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<User> GetDesigInfo(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<Designation> GetDesignations()
        {
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("p_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, "D");

                p.Add("p_intparentLevelDtlsId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("p_inthirarchyid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILS_VIEW";
                var result = Connection.Query<Designation>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<User> GetDetails(User objUser)
        {
            throw new NotImplementedException();
        }

        public string GetFullNameFromId(int intUserId)
        {
            throw new NotImplementedException();
        }

        public IList<LevelDetail> GetLevelDetails(int hirachyId)
        {
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("p_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                p.Add("p_inthirarchyid", MySqlDbType.Int32, ParameterDirection.Input, hirachyId);

                p.Add("p_intparentLevelDtlsId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILS_VIEW";
                var result = Connection.Query<LevelDetail>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<LevelDetail> GetLevelDetailsByParentId(int ParentId)
        {
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("p_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, "P");
                p.Add("p_intparentLevelDtlsId", MySqlDbType.Int32, ParameterDirection.Input, ParentId);

                p.Add("p_inthirarchyid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILS_VIEW";
                var result = Connection.Query<LevelDetail>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLevelDTlID(string LvlDtlId)
        {
            throw new NotImplementedException();
        }

        public IList<LinkAccess> GetLinkAccessByUserId(int UserId)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("p_action", MySqlDbType.VarChar, ParameterDirection.Input, "VU");
                aParam.Add("p_intuserid", MySqlDbType.Int32, ParameterDirection.Input, UserId);


                aParam.Add("p_intdesignationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_intlocationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_vchmobtel", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("p_vchusername", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("p_intprojectid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_language", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                var query = "USP_USERMASTER_VIEW";
                var result = Connection.Query<LinkAccess>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.ToList();

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public IList<UserDetail> GetLevelDetailsByuser(int ParentId)
        {
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("p_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, "UP");
                p.Add("p_intparentLevelDtlsId", MySqlDbType.Int32, ParameterDirection.Input, ParentId);

                p.Add("p_inthirarchyid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILS_VIEW";
                var result = Connection.Query<UserDetail>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Location> GetLocation()
        {
            try
            {
                var p = new MySqlDynamicParameters();
                p.Add("p_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, "L");

                p.Add("p_intparentLevelDtlsId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                p.Add("p_inthirarchyid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILS_VIEW";
                var result = Connection.Query<Location>(query, p, commandType: CommandType.StoredProcedure);
                return result.AsList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetPosition(string LevelId)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetPosition2(string Id)
        {
            throw new NotImplementedException();
        }

        public int GetSubAdminPrev(string userid)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetTGradeDetail(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetUserById(int UserId, string ActionCode)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("p_action", MySqlDbType.VarChar, ParameterDirection.Input, ActionCode);
                aParam.Add("p_intuserid", MySqlDbType.Int32, ParameterDirection.Input, UserId);

                aParam.Add("p_intdesignationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_intlocationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_vchmobtel", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("p_vchusername", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("p_intprojectid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_language", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                var query = "USP_USERMASTER_VIEW";
                var result = Connection.Query<User>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.ToList();

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }

        public User GetUserInfo(User user)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, user.ActionCode);
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, user.UserName);
                aParam.Add("v_vchPassword", MySqlDbType.VarChar, ParameterDirection.Input, user.UserPasswaord);
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);
                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("iv_intGradeId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchFullName", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intHLocation", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intLG", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intDepartment", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intLevelDetailId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, 1);
                aParam.Add("v_intDesigId", MySqlDbType.Int32, ParameterDirection.Input, 0);

                aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);

                aParam.Add("v_vchGender", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("iv_intIsadmin", MySqlDbType.Int32, ParameterDirection.Input, null!);
                aParam.Add("v_dtmDoj", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_dtmDob", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchEmail", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchMobTel", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchUserImage", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0!);
                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<User>(query, aParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result!;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
        public User LDAPGetUserInfo(User user)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, user.ActionCode);
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, user.UserName);
                
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);

                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("iv_intGradeId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchFullName", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intHLocation", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intLG", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intDepartment", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intLevelDetailId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, 1);
                aParam.Add("v_intDesigId", MySqlDbType.Int32, ParameterDirection.Input, 0);

                aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);

                aParam.Add("v_vchGender", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("iv_intIsadmin", MySqlDbType.Int32, ParameterDirection.Input, null!);
                aParam.Add("v_dtmDoj", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_dtmDob", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchEmail", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchMobTel", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchUserImage", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0!);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<User>(query, aParam, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return result;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
        public string Message(string strActionCode, string strDuplicVal, string strUserId)
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown1()
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown3(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown4(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown5(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown6()
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown7()
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown8()
        {
            throw new NotImplementedException();
        }

        public IList<User> PopUpDropDown9(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> UserGetHierarchyID(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> UserGetLevel(string Id)
        {
            throw new NotImplementedException();
        }

        public IList<User> UserGetParentID(string Id)
        {
            throw new NotImplementedException();
        }

        public int ValidateUser(User user)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, user.ActionCode);
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, user.UserName);
                aParam.Add("v_vchPassword", MySqlDbType.VarChar, ParameterDirection.Input, user.UserPasswaord);
                aParam.Add("iv_intUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);



                aParam.Add("iv_intGradeId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("v_vchFullName", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                //New Parameters added
                aParam.Add("v_intHLocation", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_intLG", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                aParam.Add("v_intDepartment", MySqlDbType.VarChar, ParameterDirection.Input, 0);
                //End
                aParam.Add("v_intLevelDetailId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                //aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, objUser.intLocation);
                aParam.Add("v_intLocation", MySqlDbType.Int32, ParameterDirection.Input, 1);
                aParam.Add("v_intDesigId", MySqlDbType.Int32, ParameterDirection.Input, 0);
               
                    aParam.Add("v_intRptUserId", MySqlDbType.Int32, ParameterDirection.Input, 0);
                
                aParam.Add("v_vchGender", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("iv_intIsadmin", MySqlDbType.Int32, ParameterDirection.Input, null!);
                aParam.Add("v_dtmDoj", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_dtmDob", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchEmail", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchMobTel", MySqlDbType.VarChar, ParameterDirection.Input, null!);
                aParam.Add("v_vchUserImage", MySqlDbType.VarChar, ParameterDirection.Input,null!);
                aParam.Add("v_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0!);


                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
                var result = Connection.Query<SuccessMessage>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;

            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
        }
        public int LDAPValidateUser(User user)
        {
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("v_chrActionCode", MySqlDbType.VarChar, ParameterDirection.Input, user.ActionCode);
                aParam.Add("v_vchUserName", MySqlDbType.VarChar, ParameterDirection.Input, user.UserName);
               
                aParam.Add("v_intOutput", MySqlDbType.Int32, direction: ParameterDirection.Output);
                //p.Add("P_Msg", MySqlDbType.RefCursor, direction: ParameterDirection.Output);
                var query = "USP_USERMASTER_MANAGE";
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
