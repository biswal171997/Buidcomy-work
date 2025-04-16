using Dapper;
using System.Data;
using CodeGen.Repository.Repositories.Interfaces;
using CodeGen.Model.LoginModel;
using CodeGen.Model.forgetpassmodel;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using ClientsideEncryption;

namespace CodeGen.Repository.Repository
{
    public class CodeGenLoginRepository : Db_BUIDCo_PMSRepositoryBase, ICodeGenLoginRepository
    {
        public CodeGenLoginRepository(IDb_BUIDCo_PMSConnectionFactory TConnectionFactory) : base(TConnectionFactory)
        {

        }
        public async Task<CodeGenLogin> GetLoginDetails(CodeGenLogin log)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_VCHUSERNAME", log.UserName);
                string encrypted = AESEncrytDecry.EncryptData(log.Password);
                p.Add("@P_VCHPASSWORD", encrypted);
                p.Add("@P_Action", "LOGIN");
                p.Add("@Output", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                var results = await Connection.QueryAsync<CodeGenLogin>("USP_CPKG_1_USERLOGIN", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> ChangePwd(CodeGenLogin Upd)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@userID", Upd.userID);
                p.Add("@Password", Upd.CurrentPassword);
                p.Add("@Conformpassword", Upd.Conformpassword);
                p.Add("@action", "Changepassword");
                var results = await Connection.ExecuteAsync("USP_CPKG_1_USERLOGIN", p, commandType: CommandType.Text);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<forgetpassmodel>> GetLoginDetails(forgetpassmodel logins)
        {
            var p = new DynamicParameters();
            p.Add("@action", "Forgetpass");
            p.Add("@Domainname", logins.Domainname);
            p.Add("@Email", logins.vchemail);
            var results = await Connection.QueryAsync<forgetpassmodel>("SP_FWCONSOLE", p, commandType: CommandType.StoredProcedure);
            return results;
        }
        public async Task<int> insertotp(forgetpassmodel TBL)
        {
            var p = new DynamicParameters();
            p.Add("@Domainname", TBL.Domainname);
            p.Add("@OTP", TBL.otp);
            p.Add("@Role_id", TBL.roleid);
            p.Add("@action", "insertotp");
            var results = await Connection.ExecuteAsync("SP_FWCONSOLE", p, commandType: CommandType.StoredProcedure);
            return results;
        }
        public async Task<forgetpassmodel> Otpcheck(forgetpassmodel TBL)
        {
            var p = new DynamicParameters();
            p.Add("@Domainname", TBL.Domainname);
            //p.Add("@OTP", TBL.otp);
            p.Add("@action", "checkotp");

            var results = await Connection.QueryFirstOrDefaultAsync<forgetpassmodel>("SP_FWCONSOLE", p, commandType: CommandType.StoredProcedure);
            return results;
        }
        public async Task<int> NewPassword(forgetpassmodel TBL)
        {
            var p = new DynamicParameters();
            p.Add("@Domainname", TBL.Domainname);
            p.Add("@Domainpassword", TBL.Domainpassword);
            p.Add("@action", "Updatepass");
            var results = await Connection.ExecuteAsync("SP_FWCONSOLE", p, commandType: CommandType.StoredProcedure);
            return results;
        }
        public async Task<IEnumerable<CodeGenLogin>> validateuser(CodeGenLogin logins)
        {
            var p = new DynamicParameters();
            p.Add("@action", "sendsms");
            p.Add("@Domainname", logins.Domainname);
            p.Add("@Mobileno", logins.vchmobno);
            var results = await Connection.QueryAsync<CodeGenLogin>("SP_FWCONSOLE", p, commandType: CommandType.StoredProcedure);
            return results;
        }

    }
}
