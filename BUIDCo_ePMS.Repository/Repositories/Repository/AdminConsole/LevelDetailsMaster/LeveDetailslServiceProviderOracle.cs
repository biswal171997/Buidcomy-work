using Dapper;
using BUIDCO.Domain.AdminConsole.HierarchyMaster;
using BUIDCO.Domain.AdminConsole.LevelDetailsMaster;
using BUIDCO.Domain.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.LevelDetailsMaster;
using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Extention;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.AdminConsole.LevelDetailsMaster
{
    public class LeveDetailslServiceProviderOracle: RepositoryBase, ILevelDetailsServiceProvider
    {
        #region Variable Declaration        
        object param = new object();
       // int intOutput;
        #endregion
        public LeveDetailslServiceProviderOracle(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public string AddLevelDetails(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster objlevel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                //dyParam.Add("P_NVCHLEVELNAME", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.NVCHLEVELNAME.ToUpper());

                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHLEVELNAME", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.NVCHLEVELNAME);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTLEVELID);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTLEVELDETAILID);
                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTPARENTID);
                //dyParam.Add("P_VCHALIAS", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHALIAS != null ? objlevel.VCHALIAS.ToUpper() : objlevel.VCHALIAS);
                dyParam.Add("P_VCHALIAS", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHALIAS);
                dyParam.Add("P_VCHTELNO", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHFAXNO);
                dyParam.Add("P_VCHFAXNO", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHTELNO);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTCREATEDBY);
                //dyParam.Add("P_Msg", MySqlDbType.RefCursor, ParameterDirection.Output);
                var query = "USP_LEVELDETAILSMASTER_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
                return strOutput;
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
        public async Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetAllLevelDetailsByHierarchyId(int id)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VLD");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<LevelDetails>();
                BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster viewModel = new BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster();
                viewModel.ParentLevelDetailsList = t1.AsList();
                return viewModel;
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
        public async Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetAllLevelParentDetailsByHierarchyId(int id,int hid)

        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VHP");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, hid);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<LevelDetails>();
                BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster viewModel = new BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster();
                viewModel.ParentLevelDetailsList = t1.AsList();
                return viewModel;
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
        public async Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetLevelByParentId(int id)
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VLP");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<LevelDetails>();
                BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster viewModel = new BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster();
                viewModel.ParentLevelDetailsList = t1.AsList();
                return viewModel;
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
        public async Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetAllLevelDetailsForEdit()

        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "A");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<LevelDetails>();
                BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster viewModel = new BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster();
                viewModel.ParentLevelDetailsList = t1.AsList();
                return viewModel;
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
        public async Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster> GetHierarchy()

        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VH");
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<Hierarchy>();
                BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster viewModel = new BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster();
                viewModel.HierarchyList = t1.AsList();
                return viewModel;
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
        public async Task<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMasterModel> GetAllLevelDetails(int id)
        {
            try
            {

                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "V");
                dyParam.Add("P_intStatus", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";
                var result = await Connection.QueryMultipleAsync(query, dyParam, commandType: CommandType.StoredProcedure);
                var t1 = await result.ReadAsync<LevelDetails>();
                LevelDetailsMasterModel viewModel = new LevelDetailsMasterModel();
                viewModel.LevelDetailsList = t1.AsList();
                return viewModel;
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
        public async Task<IEnumerable<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster>> GetLevelDetailsById(int id)
        {
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "VI");
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_IntStatus", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETALISMASTER_VIEW";

                var result = await Connection.QueryAsync<BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster>(query, dyParam, commandType: CommandType.StoredProcedure);
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
        public string EditLevelDetails(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMaster objlevel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_ACTION", MySqlDbType.VarChar, ParameterDirection.Input, "E");
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTLEVELDETAILID);
                dyParam.Add("P_NVCHLEVELNAME", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.NVCHLEVELNAME.ToUpper());
                //dyParam.Add("P_NVCHLEVELNAME", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.NVCHLEVELNAME);
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTLEVELID);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTLEVELDETAILID);
                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTPARENTID);
                dyParam.Add("P_VCHALIAS", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHALIAS != null ? objlevel.VCHALIAS.ToUpper() : objlevel.VCHALIAS);
                //dyParam.Add("P_VCHALIAS", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHALIAS != null ? objlevel.VCHALIAS : objlevel.VCHALIAS);
                dyParam.Add("P_VCHTELNO", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHFAXNO);
                dyParam.Add("P_VCHFAXNO", MySqlDbType.VarChar, ParameterDirection.Input, objlevel.VCHTELNO);
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTCREATEDBY);
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objlevel.INTCREATEDBY);
                //dyParam.Add("P_Msg", MySqlDbType.RefCursor, ParameterDirection.Output);
                var query = "USP_LEVELDETAILSMASTER_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
                return strOutput;
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
        public string MarkInactive(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "I");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTLEVELDETAILID);

                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHLEVELNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_VCHALIAS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHTELNO", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHFAXNO", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILSMASTER_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
                return strOutput;
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
        public string MarkActive(BUIDCO.Domain.AdminConsole.LevelDetailsMaster.LevelDetailsMasterModel objmodel)
        {
            string strOutput = "";
            IEnumerable<SuccessMessage> SuccessMessages;
            try
            {
                var dyParam = new MySqlDynamicParameters();
                dyParam.Add("P_Action", MySqlDbType.VarChar, ParameterDirection.Input, "EA");
                dyParam.Add("P_INTUPDATEDBY", MySqlDbType.Int32, ParameterDirection.Input, objmodel.INTUPDATEDBY);
                dyParam.Add("P_INTLEVELDETAILID", MySqlDbType.VarChar, ParameterDirection.Input, objmodel.INTLEVELDETAILID);

                dyParam.Add("P_INTPARENTID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_INTHIERARCHYID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_NVCHLEVELNAME", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTLEVELID", MySqlDbType.Int32, ParameterDirection.Input, 0);
                dyParam.Add("P_VCHALIAS", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHTELNO", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_VCHFAXNO", MySqlDbType.VarChar, ParameterDirection.Input, "");
                dyParam.Add("P_INTCREATEDBY", MySqlDbType.Int32, ParameterDirection.Input, 0);
                var query = "USP_LEVELDETAILSMASTER_MANAGE";
                SuccessMessages = Connection.Query<SuccessMessage>(query, dyParam, commandType: CommandType.StoredProcedure);
                strOutput = SuccessMessages.AsList()[0].successmessage.ToString();
                return strOutput;
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
    }
}
