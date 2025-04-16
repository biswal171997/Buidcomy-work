using DataUnification.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUIDCO.Domain.DynamicForm
{
    [Table("DF_FORM_RESULT")]
    public class DformResultDomain : BaseEntity<int>
    {
        [Key]
        public int ID { get; set; }
        public int FORMID { get; set; }

        public override int Key { get { return ID; } set { ID = value; } }

        public string RESULTJSON { get; set; }

        public int ISAPPROVED { get; set; }

        public int DELETEDFLAG { get; set; }
        public DateTime CREATEDDATE { get; set; }
        //public string MONTH { get; set; }
        //public string YEAR { get; set; }
        public DFormDomain Form { get; set; }

        public DformAdminApproval approval { get; set; }
    }
}
