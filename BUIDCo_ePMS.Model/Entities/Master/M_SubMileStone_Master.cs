using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_SubMileStone_Master
{
	public class M_SubMileStone_Master 
	{
		public int? submilestoneId { get; set; } = 0;
		public int categoryId { get; set; }
		public string? categoryName { get; set; }
        public int milestoneId { get; set; }
		public string? milestoneName { get; set; }
        public string? submilestoneName { get; set; }
		public string? SubMilestoneDesc { get; set; }
        public int createdBy { get; set; }
  //      public string? createdOn { get; set; }
		//public int? updatedBy { get; set; }
		//public string? updatedOn { get; set; }
		//public bool? deletedFlag { get; set; }
	}
}

