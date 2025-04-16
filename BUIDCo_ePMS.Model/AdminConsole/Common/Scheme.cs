using BUIDCO.Domain.DynamicForm;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUIDCO.Domain.Common
{
    [Table("LGD_TBL_SCHEME")]
    public class Scheme : BaseEntity<int>
    {
       
        public int ID { get; set; }
        public string SCHEME_NAME { get; set; }

        public int DEPTID { get; set; }

        public string DEPTNAME { get; set; }
        public string TYPE { get; set; }

        public string GOAL_IMAGE { get; set; }
        public string SCRIPT_FILE { get; set; }
        
        public int TEMPLATEID { get; set; }
        public override int Key
        {
            get { return ID; }
            set { ID = value; }
        }

        public virtual DFormDomain Form { get; set; }
        public int ISDIVISION { get; set; }
        public string OLAPTABLE { get; set; } 
        public int TARGETVALUE { get; set; }
    }
    //public class PostSelectedViewModel
    //{
    //    public int[] SelectedIds { get; set; }
    //}
}
