using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.CreateProject
{

    public class ProposalList
    {
        public int? proposalId { get; set; }
        public string? letterNo { get; set; }
        public string? proposalSubject { get; set; }
    }

    public class ProposalDetail
    {
        public int? proposalId { get; set; }
        public string? letterNo { get; set; }
        public string? letterSubmittedDate { get; set; }
        public string? proposalSubject { get; set; }
        public string? letterDocPath { get; set; }

        public string? proposalLocation { get; set; }
        public string? areaOfConstruction { get; set; }
        public int? length { get; set; }

        public string? proposalSubmittedBy { get; set; }
        public string? createdBy { get; set; }
        public string? createdOn { get; set; }
        public string? sanctionBy { get; set; }
        public string? executionMode { get; set; }
        public decimal? amount { get; set; }
        public decimal? estimatedAmount { get; set; }
        public decimal? approvedAmount { get; set; }
        public decimal? sanctionedAmount { get; set; }

        public string? letterDocPathTA { get; set; }
        public string? letterDocPathAA { get; set; }
        public string? letterDocPathTS { get; set; }


    }

    public class ProjectSavedDetail
    {
        public int? ProjectId { get; set; }
        public int? ProposalId { get; set; }
        public string? ProposalLetterNo { get; set; }
        public string? ProposalLetterSubmittedDate { get; set; }
        public string? ProposalSubject { get; set; }
        public string? ProposalLetterDocPath { get; set; }

        public string? ProposalLocation { get; set; }
        public string? ProposalAreaOfConstruction { get; set; }
        public int? ProposalLength { get; set; }

        public string? ProposalSubmittedBy { get; set; }
        public string? ProposalCreatedBy { get; set; }
        public string? ProposalCreatedOn { get; set; }
        public string? ProposalSanctionBy { get; set; }
        public string? ExecutionMode { get; set; }
        public decimal? ProposalAmount { get; set; }
        public decimal? ProposalEstimatedAmount { get; set; }
        public decimal? ProposalApprovedAmount { get; set; }
        public decimal? ProposalSanctionedAmount { get; set; }

        public string? ProposalLetterDocPathTA { get; set; }
        public string? ProposalLetterDocPathAA { get; set; }
        public string? ProposalLetterDocPathTS { get; set; }

        public string? ProjectName { get; set; }
        public decimal? ProjectAmount { get; set; }
        public decimal? ProjectAreaOfConstruction { get; set; }
        public decimal? ProjectLength { get; set; }
    }

    public class ProjectDetail
    {
        public int? ProjectId { get; set; }
        public int? ProposalId { get; set; }
        public string? ProjectName { get; set; }
        public decimal? EstimatedAmount { get; set; }
        public string? AreaOfConstruction { get; set; }
        public decimal? Length { get; set; }

        public int? CreatedBy { get; set; }

        public decimal? ReviseUpdatedAmount { get; set; }
        public string? ReviseAmountDocpath { get; set; }
        public string? ReviseAmountRemarks { get; set; }
    }



    public class ProjectViewEF
    {
        public int? ProjectId { get; set; }
        public int? ProposalId { get; set; }
        public string? ProposalLetterNo { get; set; }
        public string? ProposalSubmittedBy { get; set; }
        public string? ProposalProposedBy { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectSubject { get; set; }
        public string? ProjectSubmittedDate { get; set; }
        public decimal? AreaOfConstruction { get; set; }
        public decimal? Length { get; set; }
        public string? ExecutionMode { get; set; }
        public decimal? SanctionedAmount { get; set; }

        public decimal? RevisedAmount { get; set; }
        public string? ProjectStage { get; set; }
        
    }



}
