using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.Master
{
    public class ApplicationStatus
    {
        public int? statusId { get; set; }
        public string? statusName { get; set; }
        public int? createdBy { get; set; }
        public string? createdOn { get; set; }
        public int? updatedBy { get; set; }
        public string? updatedOn { get; set; }
        public bool? deletedFlag { get; set; }
    }
}
