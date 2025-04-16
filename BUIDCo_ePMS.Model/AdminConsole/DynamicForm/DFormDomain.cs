using BUIDCO.Domain.Common;
using DataUnification.Domain;
using DynamicForm.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUIDCO.Domain.DynamicForm
{
    [Table("DF_FORM")]
    public class DFormDomain : BaseEntity<int>
    {
         
        public int ID { get; set; }
        public int SchemeId { get; set; }
        public override int Key { get { return ID; } set { ID = value; } }
         
        public string FORMID { get; set; }
        public string JSONSTRING { get; set; }

        public Scheme scheme { get; set; }
        public int ISQUATER { get; set; }
    }
}
