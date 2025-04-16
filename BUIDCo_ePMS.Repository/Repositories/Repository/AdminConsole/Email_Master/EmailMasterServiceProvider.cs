using Dapper;
using BUIDCO.Domain.AdminConsole.EmailMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Email_Master;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.Email_Master
{
    public class EmailMasterServiceProvider: RepositoryBase, IEmailServiceProvider
    {
        public EmailMasterServiceProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<int> AddEmail(EmailMaster em)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters(); 
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "ADD");
                dyParam.Add("P_CONFIGID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_EMAILCC", MySqlDbType.VarChar, ParameterDirection.Input, em.emailcc);
                dyParam.Add("P_EMAILBCC", MySqlDbType.VarChar, ParameterDirection.Input,em.emailbcc);
                var query = "USP_EMAILMASTER_CONFIG";
                var result = await Connection.QueryAsync<Domain.Common.SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList().Count;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public async Task<IEnumerable<BUIDCO.Domain.AdminConsole.EmailMaster.EmailMaster>> GetallEmail()
        {

            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "VIEW");
                dyParam.Add("P_CONFIGID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_EMAILCC", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_EMAILBCC", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_EMAILMASTER_CONFIG";
                var result = await Connection.QueryAsync<BUIDCO.Domain.AdminConsole.EmailMaster.EmailMaster>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public async Task<IEnumerable<BUIDCO.Domain.AdminConsole.EmailMaster.EmailMaster>> Getemailbyid(int configid)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "EDIT");
                dyParam.Add("P_CONFIGID", MySqlDbType.Int32, ParameterDirection.Input, configid);
                dyParam.Add("P_EMAILCC", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_EMAILBCC", MySqlDbType.VarChar, ParameterDirection.Input, "");
                var query = "USP_EMAILMASTER_CONFIG";
                var result = await Connection.QueryAsync<BUIDCO.Domain.AdminConsole.EmailMaster.EmailMaster>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch
            {
                return null;
            }

            finally
            {
                //Connection.Dispose();

            }
        }
        public async Task<int> UpdateEmail(EmailMaster em)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "UPDATE");
                dyParam.Add("P_CONFIGID", MySqlDbType.Int32, ParameterDirection.Input, em.CONFIGID);
                dyParam.Add("P_EMAILCC", MySqlDbType.VarChar, ParameterDirection.Input, em.emailcc);
                dyParam.Add("P_EMAILBCC", MySqlDbType.VarChar, ParameterDirection.Input, em.emailbcc);
                var query = "USP_EMAILMASTER_CONFIG";
                var result = await Connection.QueryAsync<Domain.Common.SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                return result.AsList()[0].successid;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
