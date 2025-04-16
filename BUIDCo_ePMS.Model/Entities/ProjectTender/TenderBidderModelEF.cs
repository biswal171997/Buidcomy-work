using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.ProjectTender
{
    public class TenderBidderModelEF
    {
        public int bidderID { get; set; }
        public int tenderId { get; set; }
        public int projectId { get; set; }
        public string? bidderDetailsList { get; set; }
        public int createdBy { get; set; }
    }
    public class ViewTenderBidderModelEF
    {
        public int bidderID { get; set; }
        public int tenderId { get; set; }
        public int totalBider { get; set; }
        public int projectId { get; set; }
        public string? projectCode { get; set; }
        public string? createdOn { get; set; }
        public string? projectName { get; set; }
        public decimal? projectAmount { get; set; }
        public decimal? constructionArea { get; set; }
        public decimal? length { get; set; }
        public string? openingDate { get; set; }
        public decimal? emdAmount { get; set; }
        public string? submissionDate { get; set; }
        public string? nitDocFileName { get; set; }
        public string? letterNo { get; set; }
        public string? clientName { get; set; }
        public string? bidderName { get; set; }
        public string? emailId { get; set; }
        public string? contactNo { get; set; }
        public string? bankName { get; set; }
        public decimal? amount { get; set; }

    }
}
