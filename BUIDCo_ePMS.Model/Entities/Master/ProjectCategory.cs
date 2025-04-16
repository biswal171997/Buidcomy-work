using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.Entities.Master
{
	public class ProjectCategory 
	{
		public int categoryId { get; set; } = 0;
        public string? categoryIds { get; set; }
        public string? categoryName { get; set; }
		public string? categoryDesc { get; set; }
		public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

