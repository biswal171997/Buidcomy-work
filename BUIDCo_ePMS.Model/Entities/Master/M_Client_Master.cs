using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Client_Master
{
	public class M_Client_Master 
	{
		public int clientId { get; set; } = 0;
        public string? clientName { get; set; }
		public int createdBy { get; set; } = 0;
        public string? createdOn { get; set; }
		public bool? deletedFlag { get; set; }
	}
}

