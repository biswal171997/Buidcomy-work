﻿using BUIDCO.Domain.AdminConsole.HierarchyMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUIDCO.Domain.AdminConsole.LevelMaster;

namespace BUIDCO.Domain.AdminConsole.LevelDetailsMaster
{
    public class LevelDetailsMaster
    {
        public string INTLEVELDETAILID { get; set; }
        public int INTHIERARCHYID { get; set; }
        public string NVCHLEVELNAME { get; set; }

        //public string 
        public int INTLEVELID { get; set; }
        public int INTPARENTID { get; set; }
        public string VCHALIAS { get; set; }
        public string VCHTELNO { get; set; }
        public string VCHFAXNO { get; set; }
        
        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }

        public int INTPARENTID_block { get; set; }
        public int INTPARENTID_gp { get; set; }
        public int INTPARENTID_level5 { get; set; }
        public int ParentPosition { get; set; }

        public List<Hierarchy> HierarchyList { get; set; }
        public List<LevelMaster> ParentLevelList { get; set; }
        public List<LevelDetails> ParentLevelDetailsList { get; set; }
        public List<LevelDetails> ParentLevelDetailsList_Edit { get; set; }
    }
    public class LevelDetails
    {
        public int INTLEVELDETAILID { get; set; }
        public string NVCHLEVELNAME { get; set; }

        public string VCHALIAS { get; set; }
        public string NVCHLABEL { get; set; }
        public string NVCHHIERARCHYNAME { get; set; }
        public string parentlevelDetails { get; set; }
        public string INTPARENTID { get; set; }
        public string INTPOSITION { get; set; }
        public string ParentPosition { get; set; }
        public string Label2Text { get; set; }
        public string LabelText { get; set; }




    }
    public class LevelDetailsMasterModel
    {
        public List<Hierarchy> HierarchyList { get; set; }
        public List<LevelMaster> ParentLevelList { get; set; }
        public List<LevelDetails> ParentLevelDetailsList { get; set; }
        public List<LevelDetails> LevelDetailsList { get; set; }
        public string INTLEVELDETAILID { get; set; }
        public int INTUPDATEDBY { get; set; }
    }
    public class LevelMaster
    {
        public string INTLEVELID { get; set; }
        public int INTHIERARCHYID { get; set; }
        public string NVCHLABEL { get; set; }
        public string VCHALLIAS { get; set; }
        public int INTPARENTID { get; set; }
        public string VCHHIERARCHYALIAS { get; set; }
        public string NVCHHIERARCHYNAME { get; set; }
        public int INTCREATEDBY { get; set; }
        public int INTUPDATEDBY { get; set; }
        public string parentlevel { get; set; }
    }
}
