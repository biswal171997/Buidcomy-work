using System;
using System.Collections.Generic;
using System.Text;

namespace BUIDCO.Domain.DynamicForm
{
   public class DformEditconfig : BaseEntity<int>
    {
        public int ID { get; set; }
        public int FORMID { get; set; }
        public int RESULTID { get; set; }
        public string COLUMNNAME { get; set; }
        public int USERID { get; set; }
        public int STATUS { get; set; }
        public string Remark { get; set; }
        public int APPROVESTATUS { get; set; }
        public string APPLICANT_NO { get; set; }
        public int INTAPPROVEDBY { get; set; }
        public override int Key { get { return ID; } set { ID = value; } }
    }
}
