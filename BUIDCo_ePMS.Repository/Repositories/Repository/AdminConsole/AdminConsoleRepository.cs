using Dapper;
using BUIDCO.Domain;
using BUIDCO.Repository.Contract.Contract.AdminConsole;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole
{
    public class AdminConsoleRepository : RepositoryBase, IAdminConsoleRepository
    {
        private readonly ILogger<AdminConsoleRepository> Logger;
        public AdminConsoleRepository(IConnectionFactory connectionFactory,ILogger<AdminConsoleRepository> logger) : base(connectionFactory)
        {
            Logger = logger;
            Logger.LogInformation("DummyService initialized");
        }
         
        public AdminConsoleRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            //LoggerFactory logfac = new LoggerFactory();
            //Logger = logfac.CreateLogger<AdminConsoleRepository>();
        }
        public async Task<int> GetUserId(string VCHUSERNAME)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            try
            {
                string sql = "select INTUSERID from M_POR_USER where upper(VCHUSERNAME) ='" + VCHUSERNAME.ToUpper() + "'";
                var userId = await Connection.QueryFirstAsync<int>(sql);
                return userId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<LinkAccess> GetLinkAccessByUserId(int UserId, int ProjectId, int desgid,string Lang)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            try
            {
                var aParam = new MySqlDynamicParameters();
                aParam.Add("p_action", MySqlDbType.VarChar, ParameterDirection.Input, "VU");
                aParam.Add("p_intuserid", MySqlDbType.Int32, ParameterDirection.Input, UserId);
                aParam.Add("p_intprojectid", MySqlDbType.Int32, ParameterDirection.Input, ProjectId);
                aParam.Add("p_intdesignationid", MySqlDbType.Int32, ParameterDirection.Input, desgid);

                aParam.Add("p_intlocationid", MySqlDbType.Int32, ParameterDirection.Input, 0);
                aParam.Add("p_vchmobtel", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("p_vchusername", MySqlDbType.VarChar, ParameterDirection.Input, "");
                aParam.Add("p_language", MySqlDbType.VarChar, ParameterDirection.Input, Lang);
                var query = "USP_USERMASTER_VIEW";
                var result = Connection.Query<LinkAccess>(query, aParam, commandType: CommandType.StoredProcedure);
                return result.ToList();
                        }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);
                throw exception;
                //throw new Exception("Execution Failed", exception);
            }
        }
    }
}
