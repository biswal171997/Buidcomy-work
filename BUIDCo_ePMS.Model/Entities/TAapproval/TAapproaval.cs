using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.TAapproval
{
    public class TAViewEF
    {
        public int? TAId { get; set; }
        public int? ProposalId { get; set; }
        public string? ProposalLetterNo { get; set; }
        public string? ProposalSubmittedBy { get; set; }
        public string? Proposalcategory { get; set; }
        public string? Proposalsubcategory { get; set; }
        public string? ProposalSubject { get; set; }
        public string? LetterDate { get; set; }
        public string? TAUploadedDate { get; set; }
        public string? District { get; set; }
        public string ? ProposalLetter { get; set; }
        public int? generateStatus { get; set; }
        public string? TADate { get; set; }
        public string? TAletterPath { get; set; }
        public string? createdon { get; set; }
        public string? CreatedBy { get; set; }
        public string? ProposalArea { get; set; }
        public decimal? estimattedCost { get; set; }
        public string? TANazariMap { get; set; }
        public string? TADrawingPath { get; set; }
        public string? TAOtherDocPath { get; set; }
        public string? TAremarks { get; set; }
        public string? TAletterNo { get; set; }
        public string? TAestimattedcost { get; set; }
    }
    public class TASearchEF
    {
        public int? TAId { get; set; }
        public int? ProposalId { get; set; }
        public int? fyId { get; set; }
        public int? submittedByid { get; set; }
        public int? ProposalProposedBy { get; set; }
        public int? categoryid { get; set; }
        public int? subCategoryid { get; set; }
        public int? projectTypeid { get; set; }
        public int? districtid { get; set; }
        public int? ulbId { get; set; }
        public int? letterNo { get; set; }
        public int? CreatedBy { get; set; }

    }
    public class TALetterModel
    {
        public int UserID { get; set; }
        public string FromName { get; set; }
        public string FromDesignation { get; set; }
        public string ToDepartment { get; set; }
        public string ToOfficer { get; set; }
    }
    
    public class TAApprovalSave
    {
        public string? TAid { get; set; }
        public string? Action { get; set; }
        public int? ProposalID { get; set; }
        public string? TAletterPath { get; set; }
        public string? TAletterNo { get; set; }
        public string? TAletterDate { get; set; }
        public decimal? EstimattedCost { get; set; }
        public string? NazariMap { get; set; }
        public string? DrawingPath { get; set; }
        public string? OtherDocPath { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }


        public IFormFile? NazariMapUpload { get; set; }
        public IFormFile? DrawingUpload { get; set; }
        public IFormFile? OtherDocUpload { get; set; }
        public IFormFile? LetterUpload { get; set; }

        public int? Createdby { get; set; }
    }

    public class FacilityModel
    {
        public string ProjectName { get; set; }
        public string PAN { get; set; }
        public List<BankDetailModel> BankDetails { get; set; } = new List<BankDetailModel>();
    }

    public class BankDetailModel
    {
        public string InstrumentType { get; set; }
        public decimal PGAmount { get; set; }
        public string BankName { get; set; }
        public string ValidTill { get; set; }
        public string DocumentPath { get; set; }
    }
}
