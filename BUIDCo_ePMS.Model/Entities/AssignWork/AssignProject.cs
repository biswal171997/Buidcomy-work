using System;
using System.ComponentModel.DataAnnotations;
using BUIDCo_ePMS.Model.BaseEntityModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace BUIDCo_ePMS.Model.Entities.AssignProjectWork
{
    public class AssignProject
    {
      
        public string? proposerName { get; set; }
        public string? FilePath { get; set; }


        public int? id { get; set; }
        // public string? ProjectName { get; set; }
        public string? projectName { get; set; }
        public string? AssignTo { get; set; }
        public string? AgreementAmount { get; set; }
        public int? tenderId { get; set; }
        public string? ProjectDetails { get; set; }
        public int hiddenProjectId { get; set; }
        public int? bidderId { get; set; }
        public string? panNo { get; set; }
        public string? gstNo { get; set; }
        public string? licenseNo { get; set; }
        public string? phoneNo { get; set; }
        public string? faxNo { get; set; }
        public string? emailId { get; set; }
        public string? mobileNo { get; set; }
        public string? ContactNo { get; set; }
        public string? contactPerson { get; set; }
        public string? contactPersonMobileNumber { get; set; }
        public string? InstrumentType { get; set; }
        public string? PGAmount { get; set; }
        public string? BankName { get; set; }
        public DateTime? ValidTill { get; set; }
        // public string? UploadPGDocument { get; set; }

        [JsonProperty("UploadPGDocumentPath")]
        public string? UploadPGDocumentPath { get; set; }
        public string? address { get; set; }
        public int? projectDuration { get; set; }

        [DataType(DataType.Date)]
        public DateTime? startDate { get; set; }
        public string? startDateS { get; set; }

        [DataType(DataType.Date)]
        public DateTime? endDate { get; set; }
        public string? endDateS { get; set; }
        public string? UploadLetter { get; set; }

        [JsonProperty("UploadLetterdoc")]
        public IFormFile? UploadLetterdoc { get; set; }
        public string? bgStatus { get; set; }
        public string? letterDocpath { get; set; }
        public int? createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
        public string? bankdetailsList { get; set; }
        public string? letterNo { get; set; }
        public string? subject { get; set; }
        public string? tenderNo { get; set; }
        public string? nitDocFileName { get; set; }
        public string? constructionArea { get; set; }
        public string? length { get; set; }
        public string? projectAmount { get; set; }
        public string? submittedByid { get; set; }
        public string? SubmittedBy { get; set; }
        public string? proposedBy { get; set; }
        public string? prposalDoc { get; set; }
        public string? ProposalCreatedBy { get; set; }
        public string? openingDate { get; set; }
        public string? submissionDate { get; set; }
        public string? emdAmount { get; set; }





        // public List<BankDetailModel>? bankdetailsList { get; set; }
        public List<BankDetailModel>? bankdetailsList1 { get; set; } = new List<BankDetailModel>();
        public string? bankdetailsList12 { get; set; }


    }

    public class PgDetailModel
    {
        public string InstrumentType { get; set; }
        public string PGAmount { get; set; }
        public string BankName { get; set; }
        public string ValidTill { get; set; }
        public IFormFile File { get; set; } // File input
    }



    public class BankDetailModel
    {
        public string? InstrumentType { get; set; }
        public decimal PGAmount { get; set; }
        public string? BankName { get; set; }
        public string? ValidTill { get; set; }

        [JsonProperty("UploadPGDocumentPath")]
        public string? UploadPGDocumentPath { get; set; }

        [JsonProperty("uploadLetterdoc")]
        public IFormFile? UploadPGDocument { get; set; }

    }

    public class ViewAssignProject {
        public int id { get; set; }
        public int districtids { get; set; }
        public int projectTypeid { get; set; }
        public int fyId { get; set; }
        public string submittedByid { get; set; }
        public int categoryid { get; set; }
        public int subCategoryid { get; set; }
        public int ulbId { get; set; }
       
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string? projectName { get; set; }
        public string? projectDuration { get; set; }
        public string? projectCode { get; set; }
        public int? proposalId { get; set; }
        public string? loaName { get; set; }
        public string? loaBidAmount { get; set; }
        public string? loaAggrimentAmt { get; set; }
        public string? letterNo { get; set; }
        public string? subject { get; set; }
        public string? ValidTill { get; set; }
        public string? letterDocpath { get; set; }

        public static object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }

    public class ViewAssignProject1
    {
     public string? FilePath { get; set; }

    public int? id { get; set; }
    // public string? ProjectName { get; set; }
    public string? projectName { get; set; }
     public string? AssignTo { get; set; }
     public string? AgreementAmount { get; set; }
    public int? tenderId { get; set; }
    public string? ProjectDetails { get; set; }
    public int projectId { get; set; }
    public int? bidderId { get; set; }
    public string? panNo { get; set; }
    public string? gstNo { get; set; }
    public string? licenseNo { get; set; }
    public string? phoneNo { get; set; }
    public string? faxNo { get; set; }
    public string? emailId { get; set; }
    public string? mobileNo { get; set; }
    public string? ContactNo { get; set; }

    public string? contactPerson { get; set; }
    public string? contactPersonMobileNumber { get; set; }
    public string? InstrumentType { get; set; }
    public string? PGAmount { get; set; }
    public string? BankName { get; set; }
    public string? ValidTill { get; set; }
    // public string? UploadPGDocument { get; set; }

    [JsonProperty("UploadPGDocumentPath")]
    public string? UploadPGDocumentPath { get; set; }
    public string? address { get; set; }
    public int? projectDuration { get; set; }

   // [DataType(DataType.Date)]
    public string? startDate { get; set; }

   // [DataType(DataType.Date)]
    public string? endDate { get; set; }
    public string? UploadLetter { get; set; }

    [JsonProperty("UploadLetterdoc")]
    public IFormFile? UploadLetterdoc { get; set; }
    public string? bgStatus { get; set; }
    public string? letterDocpath { get; set; }
    public int? createdBy { get; set; } = 0;
    public string? createdOn { get; set; }
    public string? bankdetailsList { get; set; }
    public string? letterNo { get; set; }
    public string? subject { get; set; }
    public string? tenderNo { get; set; }
    public string? nitDocFileName { get; set; }
    public string? constructionArea { get; set; }
    public string? length { get; set; }
    public string? projectAmount { get; set; }
    public string? submittedByid { get; set; }
    public string? SubmittedBy { get; set; }
    public string? proposedBy { get; set; }
    public string? PrposalDoc { get; set; }
    public string? ProposalCreatedBy { get; set; }
    public string? openingDate { get; set; }
    public string? submissionDate { get; set; }
    public string? emdAmount { get; set; }

    public string? InstrumentType1 { get; set; }
    public decimal PGAmount1 { get; set; }
    public string? BankName1 { get; set; }
    public string? ValidTill1 { get; set; }
    public string? UploadPgDocuments { get; set; }
    }
    public class ViewBidderDetails
    {
        public string? bidderName { get; set; }
        public int bidderID { get; set; }
        public int AgreementAmount { get; set; }
    }
    public class ViewBankComponent
    {
        public int payCompId { get; set; }
        public string? PaymentComponent { get; set; }
    }
}


