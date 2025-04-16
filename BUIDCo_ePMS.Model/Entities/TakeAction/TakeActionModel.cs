using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.TakeAction
{

    public class TakeActionDetails
    {
        public ProposalDetails Proposal { get; set; }
        public DPRDetails DPR { get; set; }
        public List<ProjectSiteDetails> ProjectSite { get; set; }
        public TADetails TAdata { get; set; }
        public AADetails AAdata { get; set; }
        

        //public List<TAProposalDetailsModel> TAProposalDetails { get; set; } = new List<TAProposalDetailsModel>();
        //public List<SomeOtherModel1> OtherData1 { get; set; } = new List<SomeOtherModel1>();
        //public List<SomeOtherModel2> OtherData2 { get; set; } = new List<SomeOtherModel2>();
        //public List<SomeOtherModel3> OtherData3 { get; set; } = new List<SomeOtherModel3>();
    }
    public class ProposalDetails
    {
        public int? ProposalId { get; set; }
        public string? ProposalLetterNo { get; set; }
        public string? ProposalSubmittedBy { get; set; }
        public string? Proposalcategory { get; set; }
        public string? Proposalsubcategory { get; set; }
        public string? ProposalSubject { get; set; }
        public string? LetterDate { get; set; }
        public string? District { get; set; }
        public string? ProposalLetter { get; set; }
        public int? generateStatus { get; set; }
        public string? createdon { get; set; }
        public string? CreatedBy { get; set; }
        public string? ProposalArea { get; set; }
        public string? proposerName { get; set; }
        public string? remarks { get; set; }

    }
    public class DPRDetails
    {
        public int? ProposalId { get; set; }
        public string? PreparedBy { get; set; }
        public string? SubmittedOn { get; set; }
        public string? AgencyName { get; set; }
        public string? LOADate { get; set; }
        public string? LOANo { get; set; }
        public string? LOALetterPath { get; set; }
        public string? PPTPath { get; set; }
        public string? FDRPath { get; set; }
        public string? MapPath { get; set; }
        public string? DesignLayout { get; set; }
        public string? workduration { get; set; }
        


    }
    public class ProjectSiteDetails
    {
        public int? ProposalId { get; set; }
        public string? Area { get; set; }
        public string? Nocpath { get; set; }
        public string? Plannedmap { get; set; }
        public string? Address { get; set; }
        public string? Lattitude { get; set; }
        public string? Longitude { get; set; }
        public string? Khatano { get; set; }
        public string? Khesrano { get; set; }
        public string? docpath { get; set; }
     



    }
    public class TADetails
    {
        public string? taletterpath { get; set; }
        public string? taletterno { get; set; }
        public string? taletterdate { get; set; }
        public string? estimattedcost { get; set; }
        public string? Taapprovedby { get; set; }
        public string? nazarimap { get; set; }
        public string? drawingpath { get; set; }
        public string? Otherdocpath { get; set; }
        public string? taremarks { get; set; }
        public string? createdby { get; set; }
        public string? createdon { get; set; }




    }

    public class AADetails
    {
      
        public string? AALetterPath { get; set; }
        public string? AALetterNo { get; set; }
        public string? AALetterDate { get; set; }
        public string? AASchemeName { get; set; }
        public string? AAOtherDocuemntPath { get; set; }
        public int? IsMultipleProject { get; set; }
        public string? ProjectDetailsList { get; set; }
        public string? AARemarks { get; set; }
        public string? AACreatedBy { get; set; }
        public string? AAApprovedBy { get; set; }
        public string? Createdon { get; set; }

    }
    public class TakeActionSearch
    {
        public int? ProposalId { get; set; }
    }
    public class TakeActionSave
    {
        public int? ProposalId { get; set; }
        public int? ModuleId { get; set; }
        public IFormFile? IformFile { get; set; }
        public int? Status { get; set; }
        public string? Remarks { get; set; }
        public string? docPath { get; set; }
        public int? CreatedBy { get; set; }
    }
}
