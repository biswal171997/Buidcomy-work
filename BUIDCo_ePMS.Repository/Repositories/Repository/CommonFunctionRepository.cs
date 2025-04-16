using BUIDCo_ePMS.Model.Entities.Common;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BUIDCo_ePMS.Core.Net;

namespace BUIDCo_ePMS.Repository.Repositories.Repository
{
    public class CommonFunctionRepository : Db_BUIDCo_PMSRepositoryBase, ICommonFunctionRepository 
    {

        public CommonFunctionRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {
            
        }
        public async Task<List<ProjectSubcategory>> GetSubcategory(int obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "F");
                p.Add("@P_INT_ID", obj);
                var results = await Connection.QueryAsync<ProjectSubcategory>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<LocationLevel>> GetDistrict()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<LocationLevel>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<LocationLevel>> GetBlock(int obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_INT_ID", obj);
                var results = await Connection.QueryAsync<LocationLevel>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<LocationLevel>> GetWard(int obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "D");
                p.Add("@P_INT_ID", obj);
                var results = await Connection.QueryAsync<LocationLevel>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<Director>> GetDirector()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "J");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<Director>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<ProjectCategory>> GetCategory()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "E");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<ProjectCategory>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<FinancialYear>> GetFinancialYear()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "M");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<FinancialYear>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<Consultant>> GetConsultant()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "P");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<Consultant>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<ClientMaster>> GetClient()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "O");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<ClientMaster>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<ProjectTypeMaster>> GetProjectType()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "Q");
                p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<ProjectTypeMaster>("USP_Common_Provider", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
