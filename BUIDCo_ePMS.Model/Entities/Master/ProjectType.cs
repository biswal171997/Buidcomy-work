using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.Entities.Master
{
	public class ProjectTypeMaster 
	{
		public int typeId { get; set; } = 0;
        public string? projectType { get; set; }
		public string? typeDesc { get; set; }
		public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

