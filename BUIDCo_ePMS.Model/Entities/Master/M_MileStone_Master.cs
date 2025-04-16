using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_MileStone_Master
{
	public class M_MileStone_Master 
	{
		public int milestoneId { get; set; } = 0;
		public int categoryId { get; set; }
		public string? categoryName { get; set; }
        public string? milestoneName { get; set; }
		public string? MileStoneDesc { get; set; }
        public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

