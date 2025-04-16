using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.Proposal
{
    public class Proposal
    {
        public int proposalid { get; set; }
        public int fyId { get; set; }
        public string? submittedBy { get; set; }
        public int submittedByid { get; set; }
        public string? proposalName { get; set; }
        public int categoryid { get; set; }
        public string? categoryName { get; set; }
        public int subCategoryid { get; set; }
        public string? subCategoryName { get; set; }
        public int projectTypeid { get; set; }
        public int districtid { get; set; }
        public string? district { get; set; }
        public int officerId { get; set; }
        public string? officername { get; set; }
        public int ulbId { get; set; }
        public string? ulb { get; set; }
        public string? letterNo { get; set; }
        public DateTime proposalLetterDate { get; set; }
        public string? letterDocPath { get; set; }
        public string? subject { get; set; }
        public int proposalStatus { get; set; }
        public string? remarks { get; set; }
        public int statusId { get; set; }
        public int createdBy { get; set; }
        public string? status { get; set; }
    }
    public class ProposalDetails
    {
        public List<Proposal> proposal { get; set; }
        public ProposalSummary proposalsummary { get; set; }
    }
    public class ProposalSummary
    {
        public int TotalApplication { get; set; }
        public int NewApplication { get; set; }
        public int InProgress { get; set; }
        public int Approved { get; set; }
        public int Cancelled { get; set; }
    }
    public class ProposalSite
    {
        public int landId { get; set; }
        public int proposalId { get; set; }
        public string? area { get; set; }
        public string? nocPath { get; set; }
        public string? plannedMap { get; set; }
        public int districtId { get; set; }
        public int blockId { get; set; }
        public int Wardid { get; set; }
        public string? address { get; set; }
        public decimal lattitude { get; set; }
        public decimal longitude { get; set; }
        public string? khataNo { get; set; }
        public string? khesraNo { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public List<ProposalSiteDocument>? proposalsitedocs { get; set; }
    }
    public class ProposalFdr
    {
        public int fdrId { get; set; }
        public int proposalId { get; set; }
        public int preparedBy { get; set; }
        public string? preparedByName { get; set; }
        public DateTime submittedOn { get; set; }
        public string? agencyName { get; set; }
        public DateTime loaDate { get; set; }
        public string? loaNo { get; set; }
        public int duration { get; set; }
        public string? loaLetterPath { get; set; }
        public string? pptPath { get; set; }
        public string? fdrPath { get; set; }
        public string? mapPath { get; set; }
        public string? designLayout { get; set; }
        public int createdBy { get; set; }
    }
    public class ProposalSiteDocument
    {
        public int landId { get; set; }
        public int proposalId { get; set; }
        public string? docPath { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
    }
    public class ProposalInformation
    {
        public Proposal? proposal { get; set; }
        public List<ProposalSite>? proposalsite { get; set; }
        public ProposalFdr? proposalfdr { get; set; }
    }
}
