using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.Entities.Master
{
	public class ProjectSubcategory 
	{
		public int subCategoryId { get; set; } = 0;
        public int categoryId { get; set; } = 0;
		public string? categoryName { get; set; }
        public string? subCategoryName { get; set; }
		public string? subCategoryDesc { get; set; }
		public int createdBy { get; set; }
		public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool deletedFlag { get; set; }
	}
}

