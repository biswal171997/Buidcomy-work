using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.TSApproval
{
    public class TSApproval
    {
        public int tsId { get; set; }
        public int proposalId { get; set; }
        public string? submittedBy { get; set; }
        public string? scheme { get; set; }
        public string? categoryName { get; set; }
        public string? subCategoryName { get; set; }
        public string? district { get; set; }
        public string? proposalLetterNo { get; set; }
        public DateTime proposalLetterDate { get; set; }
        public string? proposalSubject { get; set; }
        public string? proposalletterPath { get; set; }
        public string? taestimatedCost { get; set; }
        public string? aaLetterPath { get; set; }
        public DateTime aaLetterDate { get; set; }
        public DateTime tsLetterGendate { get; set; }
        public string? tsLetterPath { get; set; }
        public string? status { get; set; }
    }
    public class TSSummary
    {
        public int TotalApplication { get; set; }
        public int NewApplication { get; set; }
        public int InProgress { get; set; }
        public int Approved { get; set; }
        public int Cancelled { get; set; }
    }
    public class TSDetails
    {
        public List<TSApproval>? tsapproval { get; set; }
        public TSSummary? tssummary { get; set; }
    }
    public class TSApprovalUpload
    {
        public int tsId { get; set; }
        public string? proposalId { get; set; }
        public string? tsLetterPath { get; set; }
        public DateTime tsLetterGendate { get; set; }
        public string? tsLetterNo { get; set; }
        public DateTime tsLetterDate { get; set; }
        public string? tsApprovedBy { get; set; }
        public string? signedTSLetterPath { get; set; }
        public string? executionMode { get; set; }
        public string? boqPath { get; set; }
        public int skilledLabour { get; set; }
        public int unskilledLabour { get; set; }
        public string? otherDocPath { get; set; }
        public string? tsRemarks { get; set; }
        public int createdBy { get; set; }
        public decimal taEstimatedCost { get; set; }
        public decimal aaEstimatedAmount { get; set; }
    }
}
