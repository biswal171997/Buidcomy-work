using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Entities.Processflow
{
    public class ProcessflowModel
    {
        public int SelectedMode { get; set; } = 0;
        public int INTUSERID { get; set; } = 0;
        public string? VCHUSERNAME { get; set; }
        public int? INTPLINKID { get; set; }  // Auto-incremented
        public string? NVCHPLINKNAME { get; set; }
        public int LevelNO { get; set; }
       public int? APCID { get; set; }
        public int INTDESIGID { get; set; } = 0;  // Auto-incremented
        public string? NVCHDESIGNAME { get; set; }

        public string? UserOrDesignation { get; set; }


        public int IsHighestLevelNo { get; set; }
    }
    public class ProcessRequestModel
    {
        public int SelectedMode { get; set; } // 1 for User, 2 for Designation
        public List<ProcessflowModel> ?Processes { get; set; }
    }
}
