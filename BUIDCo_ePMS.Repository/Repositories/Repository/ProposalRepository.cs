using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BUIDCo_ePMS.Core.Net;
using MySql.Data.MySqlClient;
using BUIDCo_ePMS.Model.Entities.Proposal;

namespace BUIDCo_ePMS.Repository.Repositories.Repository
{
    public class ProposalRepository : Db_BUIDCo_PMSRepositoryBase, IProposalRepository
    {
        public ProposalRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {
            
        }

        public async Task<ProposalDetails> GetProposal(string searchtype)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "A");
                p.Add("P_proposalid", null);
                p.Add("P_SearchType", searchtype);
                p.Add("P_Id", null);
                p.Add("P_FdrId", null);
                p.Add("P_Landid", null);
                using var multi = await Connection.QueryMultipleAsync("USP_V_Proposal", p, commandType: CommandType.StoredProcedure);
                var proposal = (await multi.ReadAsync<Proposal>()).ToList();
                var proposalsummary = await multi.ReadFirstOrDefaultAsync<ProposalSummary>();
                return new ProposalDetails
                {
                    proposal = proposal,
                    proposalsummary = proposalsummary!
                };
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<Proposal> GetProposalByID(int Id)
        {
            try
            {
                var p = new DynamicParameters(); 
                p.Add("@P_Action", "A", DbType.String);
                p.Add("@P_SearchType", null, DbType.String);
                p.Add("P_proposalid", Id, DbType.Int32);
                p.Add("@P_FdrId", null, DbType.Int32);
                p.Add("@P_Landid", null, DbType.Int32);
                var results = await Connection.QueryAsync<Proposal>("USP_V_Proposal1", p, commandType: CommandType.StoredProcedure);
                
                return results.FirstOrDefault()!;

            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> SaveProposal(Proposal obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "A");
                p.Add("P_proposalid", obj.proposalid);
                p.Add("P_FyId", obj.fyId);
                p.Add("P_submittedByid", obj.submittedByid);
                p.Add("P_proposalName", obj.proposalName);
                p.Add("P_categoryid", obj.categoryid);
                p.Add("P_subCategoryid", obj.subCategoryid);
                p.Add("P_projectTypeid", obj.projectTypeid);
                p.Add("P_districtid", obj.districtid);
                p.Add("P_officerId", obj.officerId);
                p.Add("P_ulbId", obj.ulbId);
                p.Add("P_letterNo", obj.letterNo);
                p.Add("P_proposalLetterDate", obj.proposalLetterDate);
                p.Add("P_letterDocPath", obj.letterDocPath);
                p.Add("P_subject", obj.subject);
                p.Add("P_remarks", obj.remarks);
                p.Add("P_createdBy", obj.createdBy);
                p.Add("P_MSG_OUT", dbType:DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<Proposal>("USP_M_Proposal", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<ProposalSite> GetProposalSiteByID(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "D");
                p.Add("P_proposalid", null);
                p.Add("P_SearchType", null);
                p.Add("P_Id", null);
                p.Add("P_FdrId", null);
                p.Add("P_Landid", Id);
                //var results = await Connection.QueryAsync<ProposalSite>("USP_V_Proposal", p, commandType: CommandType.StoredProcedure);
                using var multi = await Connection.QueryMultipleAsync("USP_V_Proposal", p, commandType: CommandType.StoredProcedure);
                var proposalsite = await multi.ReadFirstOrDefaultAsync<ProposalSite>();

                // Read Proposal Site Documents
                var proposalsitedocs = (await multi.ReadAsync<ProposalSiteDocument>()).ToList();
                proposalsite.proposalsitedocs = proposalsitedocs;
                return proposalsite;
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> SaveProposalSite(ProposalSite obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_proposalid", obj.proposalId);
                p.Add("@P_Landid", obj.landId);
                p.Add("@P_area", obj.area);
                p.Add("@P_nocPath", obj.nocPath);
                p.Add("@P_plannedMap", obj.plannedMap);
                p.Add("@P_districtId", obj.districtId);
                p.Add("@P_blockId", obj.blockId);
                p.Add("@P_Wardid", obj.Wardid);
                p.Add("@P_address", obj.address);
                p.Add("@P_lattitude", obj.lattitude);
                p.Add("@P_longitude", obj.longitude);
                p.Add("@P_khataNo", obj.khataNo);
                p.Add("@P_khesraNo", obj.khesraNo);
                p.Add("@P_createdBy", obj.createdBy);
                var jsondata = JsonConvert.SerializeObject(obj.proposalsitedocs);
                p.Add("@P_sitedocs", jsondata);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                

                //var employees = new[]
                //{
                //    new { Name = "John", Age = 30, Department = "HR" },
                //    new { Name = "Alice", Age = 25, Department = "IT" }
                //};

                //var jsonData = JsonConvert.SerializeObject(employees);
                //p.Add("@jsonData", jsonData, DbType.String);

                await Connection.ExecuteAsync("USP_M_ProposalSite", p, commandType: CommandType.StoredProcedure);

                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> DeleteProposalSite(ProposalSite obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_proposalid", null);
                p.Add("@P_Landid", obj.landId);
                p.Add("@P_area", null);
                p.Add("@P_nocPath", null);
                p.Add("@P_plannedMap", null);
                p.Add("@P_districtId", null);
                p.Add("@P_blockId", null);
                p.Add("@P_Wardid", null);
                p.Add("@P_address", null);
                p.Add("@P_lattitude", null);
                p.Add("@P_longitude", null);
                p.Add("@P_khataNo", null);
                p.Add("@P_khesraNo", null);
                p.Add("@P_sitedocs", null);
                p.Add("@P_createdBy", obj.createdBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                await Connection.ExecuteAsync("USP_M_ProposalSite", p, commandType: CommandType.StoredProcedure);

                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);

                return 1;
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<ProposalFdr> GetProposalFDRByID(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "E");
                p.Add("P_proposalid", null);
                p.Add("P_SearchType", null);
                p.Add("P_Id", null);
                p.Add("P_FdrId", Id);
                p.Add("P_Landid", null);
                var results = await Connection.QueryAsync<ProposalFdr>("USP_V_Proposal", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault()!;
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> SaveFDRDetails(ProposalFdr obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_Fdrid", obj.fdrId);
                p.Add("@P_proposalid", obj.proposalId);
                p.Add("@P_preparedBy", obj.preparedBy);
                p.Add("@P_submittedOn", obj.submittedOn);
                p.Add("@P_agencyName", obj.agencyName);
                p.Add("@P_loaDate", obj.loaDate);
                p.Add("@P_loaNo", obj.loaNo);
                p.Add("@P_duration", obj.duration);
                p.Add("@P_loaLetterPath", obj.loaLetterPath);
                p.Add("@P_pptPath", obj.pptPath);
                p.Add("@P_fdrPath", obj.fdrPath);
                p.Add("@P_mapPath", obj.mapPath);
                p.Add("@P_designLayout", obj.designLayout);
                p.Add("@P_createdBy", obj.createdBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<Proposal>("USP_M_ProposalFDR", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<ProposalInformation> GetProposalInformationByID(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "C");
                p.Add("P_proposalid", Id);
                p.Add("P_SearchType", null);
                p.Add("P_Id", null);
                p.Add("P_FdrId", null);
                p.Add("P_Landid", null);
                using var multi = await Connection.QueryMultipleAsync("USP_V_Proposal", p, commandType: CommandType.StoredProcedure);

                // Read the first result as a single Proposal
                var proposal = await multi.ReadFirstOrDefaultAsync<Proposal>();

                // Read multiple ProposalSite entries
                var proposalsites = (await multi.ReadAsync<ProposalSite>()).ToList();

                // Read Proposal FDR (single object)
                var proposalfdr = await multi.ReadFirstOrDefaultAsync<ProposalFdr>();

                // Read Proposal Site Documents
                var proposalsitedocs = (await multi.ReadAsync<ProposalSiteDocument>()).ToList();

                // Map documents to the correct ProposalSite
                foreach (var site in proposalsites)
                {
                    site.proposalsitedocs = proposalsitedocs.Where(doc => doc.landId == site.landId).ToList();
                }

                return new ProposalInformation
                {
                    proposal = proposal,
                    proposalsite = proposalsites,  // Now handling multiple sites
                    proposalfdr = proposalfdr
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<int> SubmitProposal(Proposal obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_proposalid", obj.proposalid);
                p.Add("@P_FyId", null);
                p.Add("@P_submittedByid", null);
                p.Add("@P_proposalName", null);
                p.Add("@P_categoryid", null);
                p.Add("@P_subCategoryid", null);
                p.Add("@P_projectTypeid", null);
                p.Add("@P_districtid", null);
                p.Add("@P_officerId", null);
                p.Add("@P_ulbId", null);
                p.Add("@P_letterNo", null);
                p.Add("@P_proposalLetterDate", null);
                p.Add("@P_letterDocPath", null);
                p.Add("@P_subject", null);
                p.Add("@P_remarks", null);
                p.Add("@P_createdBy", obj.createdBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<Proposal>("USP_M_Proposal", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<int> CancelProposal(Proposal obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_proposalid", obj.proposalid);
                p.Add("@P_FyId", null);
                p.Add("@P_submittedByid", null);
                p.Add("@P_proposalName", null);
                p.Add("@P_categoryid", null);
                p.Add("@P_subCategoryid", null);
                p.Add("@P_projectTypeid", null);
                p.Add("@P_districtid", null);
                p.Add("@P_officerId", null);
                p.Add("@P_ulbId", null);
                p.Add("@P_letterNo", null);
                p.Add("@P_proposalLetterDate", null);
                p.Add("@P_letterDocPath", null);
                p.Add("@P_subject", null);
                p.Add("@P_remarks", null);
                p.Add("@P_createdBy", obj.createdBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<Proposal>("USP_M_Proposal", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
    }
}
