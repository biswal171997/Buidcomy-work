using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.Master
{
    public class ClientMaster
    {
        public string? SchemeName { get; set; }
        public string? ClientName { get; set; }
        //public string? Desc { get; set; }
        public string? clientDesc { get; set; }
        public int ClientId { get; set; }
        public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
        public int? updatedBy { get; set; }
        public string? updatedOn { get; set; }
        public bool? deletedFlag { get; set; }
        public int schemeId { get; set; }
    }
}
