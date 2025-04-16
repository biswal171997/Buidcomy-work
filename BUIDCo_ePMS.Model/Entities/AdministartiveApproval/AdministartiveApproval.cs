using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.AdministartiveApproval
{
    public class AdminApprovalViewEF
    {
        public int? ProposalId { get; set; }
        public String? District { get; set; }
        public string? ProposalSubject { get; set; }
        public string? ProposalSubmittedBy { get; set; }
        public string? Proposalcategory { get; set; }
        public string? Proposalsubcategory { get; set; }
        public string? ProposalLetterNo { get; set; }
        public string? ProposalLetterDate { get; set; }
        public string? ProposalLetterdocpath { get; set; }
        public Decimal? EstimatedCost { get; set; }

        public string? TAApprovedBy { get; set; }
        public string? TAGeneratedLetterDocPath { get; set; }
        public string? TAGeneratedLetterDate { get; set; }
        public int? IsAALetterGenerated { get; set; }
        public string? AAGeneratedLetterDocPath { get; set; }
        public string? AAGeneratedLetterDate { get; set; }

        public int? IsAAUploaded { get; set; }
        //public string? AAUploadedFileDocPath { get; set; }
        public string? AAAUploadedDate { get; set; }
        public string? AAStatus { get; set; }

        public int? IsAADetailsApproved { get; set; }

        public string? CreatedByUserId { get; set; }
    }

    public class AdminApprovalSaveEF
    {

        public string? Action { get; set; }
        public int? AAId { get; set; }
        public int? ProposalId { get; set; }
        public string? AALetterPath { get; set; }
        public string? AALetterNo { get; set; }
        public string? AALetterDate { get; set; }
        public int ? AASchemeID { get; set; }
        //public int? AAApprovedBY { get; set; }
        //public string? AASignedDocumentPath { get; set; }
        public string? AAOtherDocuemntPath { get; set; }
        public int? IsMultipleProject { get; set; }
        public string? ProjectDetailsList { get; set; }
        public string? AARemarks { get; set; }
        public int? AACreatedBy { get; set; }

        public string? ProposalSubject { get; set; }
        public string? ProposalDistrict { get; set; }
        public string? ProposalCreatedBy { get; set; }
        public string? ProposalCreatedOn { get; set; }
        public string? ProposalEstimatedAmount { get; set; }
        public string? TASignedDocumentPath { get; set; }
        public Decimal? ProposalArea { get; set; }
    }

    public class DropdownList
    {
        public int? Id { get; set; }
        public string? Value { get; set; }
    }
}
