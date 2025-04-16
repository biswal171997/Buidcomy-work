using System;
using BUIDCo_ePMS.Model.BaseEntityModel;
namespace BUIDCo_ePMS.Model.M_Financial_Year
{
	public class FinancialYear 
	{
		public int fyId { get; set; } = 0;
        public string? fyName { get; set; }
		public int createdBy { get; set; } = 0;
		public bool? deletedFlag { get; set; }
	}
}

