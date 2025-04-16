using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using BUIDCO.Repository;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ProjectLink;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Domain.AdminConsole.ProjectLink;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Extention;

namespace AdminConsoleCore.Persistence.ProjectLink
{
    public class ProjectLinkServiceProviderOracle : RepositoryBase, IProjectLinkServiceProvider
    {
        public ProjectLinkServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddProjectLink(Project objProjectlink)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_NVCHPROJECTLINKNAME", MySqlDbType.VarChar, ParameterDirection.Input, objProjectlink.NVCHPROJECTLINKNAME.Trim());
                dyParam.Add("P_NVCHPROJECTLINKDESC", MySqlDbType.VarChar, ParameterDirection.Input, objProjectlink.NVCHPROJECTLINKDESC!=null ? objProjectlink.NVCHPROJECTLINKDESC.Trim(): objProjectlink.NVCHPROJECTLINKDESC);
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, objProjectlink.INTCREATEDBY);

                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PROJECTLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public async Task<ViewProjectLink> GetAllActiveProjectLink()

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VAA");

                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_M_ADM_PROJECTLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewPoject>();
                ViewProjectLink viewModel = new ViewProjectLink();
                viewModel.ViewProjectLinkDetailsmodel = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public async Task<ViewProjectLink> GetAllInActiveProjectLink()

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VAI");

                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_M_ADM_PROJECTLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewPoject>();
                ViewProjectLink viewModel = new ViewProjectLink();
                viewModel.ViewProjectLinkDetailsmodel = t1.AsList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }
        public string InactiveProjectLink(int id, int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "I");
                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, updatedby);

                dyParam.Add("P_NVCHPROJECTLINKNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_NVCHPROJECTLINKDESC", MySqlDbType.VarChar, ParameterDirection.Input,"");
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PROJECTLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public string ActiveProjectLink(int id, int updatedby)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "MA");
                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, updatedby);


                dyParam.Add("P_NVCHPROJECTLINKNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_NVCHPROJECTLINKDESC", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PROJECTLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
        public async Task<ViewProjectLink> GetById(int id)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, id);
                
                var query = "USP_M_ADM_PROJECTLINK_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<ViewPoject>();
                ViewProjectLink viewModel = new ViewProjectLink();
                viewModel.ProjectLinkModelIdwise = t1.ToList();
                return viewModel;
            }
            catch (Exception ex)
            {
                //Logger.LogError(ex, ex.Message, componentDomain);
                throw ex;
            }
        }

        public string UpdateProjectLink(Project objProjectlink)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTPROJECTLINKID", MySqlDbType.Int32, ParameterDirection.Input, objProjectlink.INTPROJECTLINKID);
                dyParam.Add("P_NVCHPROJECTLINKNAME", MySqlDbType.VarChar, ParameterDirection.Input, objProjectlink.NVCHPROJECTLINKNAME.Trim());
                dyParam.Add("P_NVCHPROJECTLINKDESC", MySqlDbType.VarChar, ParameterDirection.Input, objProjectlink.NVCHPROJECTLINKDESC != null ? objProjectlink.NVCHPROJECTLINKDESC.Trim() : objProjectlink.NVCHPROJECTLINKDESC);
                dyParam.Add("P_intUpdatedBy", MySqlDbType.Int32, ParameterDirection.Input, objProjectlink.INTUPDATEDBY);
                
                dyParam.Add("P_intCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_PROJECTLINK_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex, ex.Message, Model);
                throw ex;
            }
            return strOutput;
        }
    }

}
