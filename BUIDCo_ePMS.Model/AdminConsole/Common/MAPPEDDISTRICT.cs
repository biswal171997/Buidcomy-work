using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataUnification.Domain.Common
{
    [Table("MAPPED_DISTRICT")]
    public class MAPPED_DISTRICT  
    {
        public int ID { get; set; }
        public string LGD_DIST_CODE { get; set; }
        public string LGD_DIST_NAME { get; set; }
        public string SOURCE_DIST_CODE { get; set; }
        public string SOURCE_DIST_NAME { get; set; }
        public string SOURCE_CENSUS_2001_CODE { get; set; }
        public string SOURCE_CENSUS_2011_CODE { get; set; }
        public string SOURCE_CENSUS_2021_CODE { get; set; }
        public int USERID { get; set; }
        public int SCHEMEID { get; set; }         
    }
}
