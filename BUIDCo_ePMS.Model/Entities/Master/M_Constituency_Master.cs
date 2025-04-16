using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Constituency_Master
{
	public class M_Constituency_Master 
	{
		public int constituencyId { get; set; } = 0;
        public int districtId { get; set; } = 0;
        public string constituencyName { get; set; }
		public int? createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

