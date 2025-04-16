using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.ProjectTender
{
    public class ProjectTenderEF
    {
        public int tenderId { get; set; }
        public int projectId { get; set; }
        public string? projectName { get; set; }
        public string? tenderNo { get; set; }
        public string? tenderSubject { get; set; }
        public DateTime publishedDate { get; set; }
        public DateTime openingDate { get; set; }
        public DateTime submissionDate { get; set; }
        public decimal? emdAmount { get; set; }
        public decimal? processingFee { get; set; }
        public string? nitDocFileName { get; set; }
        public int createdBy { get; set; }
    }
    public class Projects
    {
        public int tenderId { get; set; }
        public int projectId { get; set; }
        public string? projectName { get; set; }
        public string? projectCode { get; set; }
        public string? createdOn { get; set; }
        public int constructionArea { get; set; }
        public int length { get; set; }
        public decimal? projectAmount { get; set; }

    }
    public class ViewProjectTenderEF
    {
        public int? tenderId { get; set; }
        public string? tenderNo { get; set; }
        public string? openingDate { get; set; }
        public string? tenderSubject { get; set; }
        public string? publishedDate { get; set; }
        public string? submissionDate { get; set; }
        public decimal? emdAmount { get; set; }
        public decimal? processingFee { get; set; }
        public string? nitDocFileName { get; set; }
        public int projectId { get; set; }
        public string? projectName { get; set; }
        public string? projectCode { get; set; }
        public decimal? projectAmount { get; set; }
        public int? constructionArea { get; set; }
        public int? length { get; set; }
        public int corrigendumCount { get; set; }
        public int addendumCount { get; set; }

    }
    public class ProjectTenderCorrigendumEF
    {
        public int corrigendumId { get; set; }
        public int tenderId { get; set; }
        public int projectId { get; set; }
        public string? corrigendumType { get; set; }
        public string? corrigendumDate { get; set; }
        public int approveBy { get; set; }
        public string? corrigendumFileName { get; set; }
        public int createdBy { get; set; }
        public string? CorrigendumList { get; set; }
    }
    public class VewProjectTenderCorrigendumEF
    {
        public int corrigendumId { get; set; }
        public string? projectCode { get; set; }
        public string? createdOn { get; set; }
        public string? projectName { get; set; }
        public decimal? constructionArea { get; set; }
        public decimal? length { get; set; }
        public decimal? projectAmount { get; set; }
        public string? openingDate { get; set; }
        public string? submissionDate { get; set; }
        public string? nitDocFileName { get; set; }
        public string? CorrigendumList { get; set; }
        public string? letterNo { get; set; }
        public string? clientName { get; set; }
        public int corrigendumCount { get; set; }
        public int addendumCount { get; set; }
        public string? corrigendumType { get; set; }
        public string? corrigendumDate { get; set; }
        public int approveBy { get; set; }
        public string? corrigendumFileName { get; set; }
        public decimal? emdAmount { get; set; }

    }
    public class UserMasterModelEF
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
    }
    public class ViewCorrigendumAddendumDetailsEF
    {
        public int ID { get; set; }
        public int corrigendumId { get; set; }
        public string? refNo { get; set; }
        public string? description { get; set; }
    }
}
