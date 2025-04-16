
using BUIDCo_ePMS.Model.Entities.Proposal;
using BUIDCo_ePMS.Model.Entities.TSApproval;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TSApproval;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BUIDCo_ePMS.Core.Net;

namespace BUIDCo_ePMS.Repository.Repositories.Repository.TSspproval
{
    public class TSapprovalRepository : Db_BUIDCo_PMSRepositoryBase, ITSApprovalRepository
    {
        public TSapprovalRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {

        }

        public async Task<int> GenerateTSLetter(TSApprovalUpload obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "A");
                
                p.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.QueryAsync<TSApprovalUpload>("USP_M_TS_Approval", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<TSApprovalUpload> GetTSApprovalByID(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B", DbType.String);
                p.Add("@P_proposalid", Id, DbType.Int32);
                p.Add("@P_SearchType", null, DbType.String);
                p.Add("@P_tsId", null);
                var results = await Connection.QueryAsync<TSApprovalUpload>("USP_V_TS_Approval", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault()!;

            }


            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<TSDetails> GetTSDetails(string searchtype)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "A");
                p.Add("@P_proposalid", null);
                p.Add("P_tsId", null);
                p.Add("P_SearchType", searchtype);
                using var multi = await Connection.QueryMultipleAsync("USP_V_TS_Approval", p, commandType: CommandType.StoredProcedure);
                var tsapprovals = (await multi.ReadAsync<TSApproval>()).ToList();
                var tssummary = await multi.ReadFirstOrDefaultAsync<TSSummary>();
                return new TSDetails
                {
                    tsapproval = tsapprovals,
                    tssummary = tssummary
                };
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> UploadTSInformation(TSApprovalUpload obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "B");
                p.Add("P_tsId", obj.tsId);
                p.Add("P_proposalid", obj.proposalId);
                p.Add("P_tsLetterPath", obj.tsLetterPath);
                p.Add("P_tsLetterGendate", obj.tsLetterGendate);
                p.Add("P_tsLetterNo", obj.tsLetterNo);
                p.Add("P_tsLetterDate", obj.tsLetterDate);
                p.Add("P_tsApprovedBy", obj.tsApprovedBy);
                p.Add("P_signedTSLetterPath", obj.signedTSLetterPath);
                p.Add("P_executionMode", obj.executionMode);
                p.Add("P_boqPath", obj.boqPath);
                p.Add("P_skilledLabour", obj.skilledLabour);
                p.Add("P_unskilledLabour", obj.unskilledLabour);
                p.Add("P_otherDocPath", obj.otherDocPath);
                p.Add("P_tsRemarks", obj.tsRemarks);
                p.Add("P_createdBy", obj.createdBy);
                p.Add("P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.QueryAsync<Proposal>("USP_M_TS_Approval", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
