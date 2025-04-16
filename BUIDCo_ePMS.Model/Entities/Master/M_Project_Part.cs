using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Project_Part
{
	public class M_Project_Part 
	{
		public int partId { get; set; } = 0;
        public string? partName { get; set; }
		public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

