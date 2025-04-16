using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Assembly_Master
{
	public class M_Assembly_Master 
	{
		public int? assemblyId { get; set; }
		public int? Leveldetailid { get; set; }
		public string? assemblyName { get; set; }
		public string? assemblyDesc { get; set; }
		public int? createdBy { get; set; }
		public string? createdOn { get; set; }
		public int? updatedBy { get; set; }
		public string? updatedOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

