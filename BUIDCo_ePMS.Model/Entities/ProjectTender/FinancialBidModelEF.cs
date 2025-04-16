using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.ProjectTender
{
    public class FinancialBidModelEF
    {
        public int bidderID { get; set; }
        public decimal? financialScore { get; set; }
        public decimal? bidAmount { get; set; }
        public string? financialBidDocFile { get; set; }
        public string? loaDocFile { get; set; }
        public int winnerStatus { get; set; }
        public IFormFile? IformfinancialBidDocFile { get; set; }
        public IFormFile? IformloaDocFile { get; set; }
    }
    public class FinancialBidModel
    {
        public int ID { get; set; }
        public int financialID { get; set; }
        public int createdBy { get; set; }
        public int projectId { get; set; }
        public int tenderId { get; set; }
        public int technicalBidID { get; set; }
        public string? JsonFinancialList { get; set; }
        public int technicalStatus { get; set; }
        public List<FinancialBidModelEF>? FiancialBidList { get; set; } = new List<FinancialBidModelEF>();
    }

    public class ViewFinancialBidModelEF
    {
        public string? bidderName { get; set; }
        public decimal? bidAmount { get; set; }
        public decimal? financialScore { get; set; }
        public int bidderID { get; set; }
        public int ID { get; set; }
        public int financialID { get; set; }
        public int tenderId { get; set; }
        public int projectId { get; set; }
        public string? projectCode { get; set; }
        public string? projectName { get; set; }
        public string? openingDate { get; set; }
        public string? submissionDate { get; set; }
        public string? letterNo { get; set; }
        public string? financialBidDocFile { get; set; }
        public string? loaDocFile { get; set; }
        public int winnerStatus { get; set; }
        public string? createdOn { get; set; }
        public decimal? projectAmount { get; set; }
        public decimal? constructionArea { get; set; }
        public decimal? length { get; set; }
        public string? nitDocFileName { get; set; }
        public string? clientName { get; set; }
        public decimal? emdAmount { get; set; }
    }
}
