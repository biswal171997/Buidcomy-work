using System;
using System.Collections.Generic;
using System.Text;

namespace BUIDCO.Domain.Common
{
    public class SuccessMessage
    {
        public int successid { get; set; }
        public string successmessage { get; set; }
    }

    public class DbTransactionResult : SuccessMessage
    {
        public DbTransactionResult()
        {
            successid = 1;
        }
        public int count { get; set; }
    }
}
