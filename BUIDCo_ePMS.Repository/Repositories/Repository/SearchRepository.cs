using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.Proposal;
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

namespace BUIDCo_ePMS.Repository.Repositories.Repository
{
    public class SearchRepository : Db_BUIDCo_PMSRepositoryBase, ISearchRepository
    {
        public SearchRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
        {
            
        }
        public async Task<ProposalDetails> SearchProposal(Proposal obj)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "A");
                p.Add("P_FyId", obj.fyId);
                p.Add("P_letterNo", obj.letterNo);
                p.Add("P_submittedByid", obj.submittedByid);
                p.Add("P_categoryid", obj.categoryid);
                p.Add("P_subCategoryid", obj.subCategoryid);
                p.Add("P_projectTypeid", obj.projectTypeid);
                p.Add("P_districtid", obj.districtid);
                p.Add("P_ulbId", obj.ulbId);

                using (var multi = await Connection.QueryMultipleAsync("USP_V_Search", p, commandType: CommandType.StoredProcedure))
                {
                    var proposal = (await multi.ReadAsync<Proposal>()).ToList();
                    var proposalsummary = await multi.ReadFirstOrDefaultAsync<ProposalSummary>();
                    return new ProposalDetails
                    {
                        proposal = proposal,
                        proposalsummary = proposalsummary
                    };
                    //var resultSet1 = await multi.ReadAsync<dynamic>();
                    ////var resultSet2 = await multi.ReadAsync<dynamic>();

                    //(await multi.ReadAsync<ProposalSite>()).ToList();
                    //return new
                    //{
                    //    ResultSet1 = resultSet1,
                    //    ResultSet2 = resultSet2,
                    //};
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
