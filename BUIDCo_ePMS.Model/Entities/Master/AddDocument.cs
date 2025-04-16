using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.Master
{
    public class AddDocument
    {
        public int Approve_Status { get; set; }
        public int? Id { get; set; }
        public int? PendingWithUser { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? remarks { get; set; }

        public string? ImageDescription { get; set; }
        public int? Status { get; set; }
        public string? ActiveFrom { get; set; }
        public string? ActiveTo { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        public int? DeletedBy { get; set; }
        public int? IsDeleted { get; set; }
        public int? IsActive { get; set; }
        public IFormFile? ImageFile { get; set; }

        //--------------------Previous Records--
        public string? BannerImageUrl { get; set; } = "";
        public string? BannerName { get; set; } = "";
        //--------------------------

        public int? Plink { get; set; }
    }
}
