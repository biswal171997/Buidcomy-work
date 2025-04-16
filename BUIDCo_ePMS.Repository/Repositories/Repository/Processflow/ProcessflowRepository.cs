using BUIDCo_ePMS.Model.Entities.Common;
using BUIDCo_ePMS.Model.Entities.Processflow;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.Processflow;
using Dapper;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.Processflow
{
    public class ProcessflowRepository : Db_BUIDCo_PMSRepositoryBase, IProcessflowRepository
    {
        public ProcessflowRepository(IDb_BUIDCo_PMSConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

       

        public async Task<IEnumerable<ProcessflowModel>> GetAllPages()
        {
            try
            {
                var p = new DynamicParameters();
                var results = await Connection.QueryAsync<ProcessflowModel>("USP_GetPages", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ProcessflowModel>> GetallUser()
        {
            try
            {
                var p = new DynamicParameters();
                var results = await Connection.QueryAsync<ProcessflowModel>("USP_GetUser", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        
        public async Task<int> AddProcessAsync(ProcessflowModel process)
        {
            
            try
            {
                
                var p = new DynamicParameters();
                p.Add("P_LevelNO", process.LevelNO);
                p.Add("P_INTPLINKID", process.INTPLINKID);
                p.Add("P_SelectedMode", process.SelectedMode);
                if (process.SelectedMode==1)
                {
                    p.Add("P_INTUSERID", process.INTUSERID);
                    p.Add("P_INTDESIGID", process.INTDESIGID);
                }
                else
                {
                    p.Add("P_INTUSERID", process.INTUSERID);
                    p.Add("P_INTDESIGID", process.INTDESIGID);
                }
                var results = await Connection.ExecuteAsync("USP_Addprocess", p, commandType: CommandType.StoredProcedure);
                return results;
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<int> DeleteProcessAsync(ProcessflowModel process)
        {
            try
            {
                var p = new DynamicParameters();
               
                p.Add("P_INTPLINKID", process.INTPLINKID);
              
                var results = await Connection.ExecuteAsync("USP_Deleteprocess", p, commandType: CommandType.StoredProcedure);
                return results;
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<IEnumerable<ProcessflowModel>> GetalldataviewPages()
        {
            try
            {
                var p = new DynamicParameters();
                var results = await Connection.QueryAsync<ProcessflowModel>("USP_ViewAprovalprocess", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<ProcessflowModel>> GetProcessById(int INTPLINKID)
        {
            var p = new DynamicParameters();

            p.Add("P_INTPLINKID", INTPLINKID);
            var results = await Connection.QueryAsync<ProcessflowModel>("USP_ProcessbyPageId", p, commandType: CommandType.StoredProcedure);
            return results.ToList();
            //string query = "SELECT * FROM Approval_Config WHERE FormName = @FormName";

           // return (await Connection.QueryAsync<ProcessflowModel>(query, new { FormName = INTPLINKID })).ToList();
        }

        public async Task<int> DeleteProcessById(int APCID)
        {
            var p = new DynamicParameters();

            p.Add("P_APCID", APCID);

            var results = await Connection.ExecuteAsync("USP_Deleteprocessdata", p, commandType: CommandType.StoredProcedure);
            return results;
        }

        public async Task<List<ProcessflowModel>> GetallDesignation()
        {
            try
            {
                var p = new DynamicParameters();
                var results = await Connection.QueryAsync<ProcessflowModel>("PF_GetAllDesignation", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
