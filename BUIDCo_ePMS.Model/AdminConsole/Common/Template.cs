﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BUIDCO.Domain.Common
{
    //[Table("BUIDCO_TBL_TEMPLATE")]
    public class Template //: BaseEntity<int>
    {
        public int TEMPLATEID { get; set; }
        public string TEMPLATE_NAME { get; set; }
        public int COLUMNID { get; set; }
        public string COLUMNNAME { get; set; }
        public string CSS_FILE { get; set; }
        //public override int Key
        //{
        //    get { return TEMPLATEID; }
        //    set { TEMPLATEID = value; }
        //}
    }
}
