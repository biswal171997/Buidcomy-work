

using System.ComponentModel.DataAnnotations.Schema;

namespace BUIDCO.Domain.DynamicForm
{
    [Table("DF_FORMRESULT_APPROVAL")]
    public class DformAdminApproval
    {
        public int RESULTID { get; set; }
        public string NOTES { get; set; }
    }
}
