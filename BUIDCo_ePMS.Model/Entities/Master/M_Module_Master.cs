using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Module_Master
{
	public class M_Module_Master 
	{
		public int moduleId { get; set; } = 0;
        public string? moduleName { get; set; }
		public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

