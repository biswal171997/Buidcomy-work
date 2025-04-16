using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Assembly_Tagging
{
	public class M_Assembly_Tagging 
	{
		public int taggingId { get; set; } = 0;
        public byte districtId { get; set; } = 0;
		public int assemblyId { get; set; } = 0;
        public short? blockId { get; set; }
		public int? createdBy { get; set; }
		public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

