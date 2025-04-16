using System;
using System.Collections.Generic;
using System.Text;

namespace BUIDCO.Domain.Common
{
   public class Block : BaseEntity<int>
    {
        /// <summary>
        /// BLOCK Id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// BLOCK CODE
        /// </summary>
        public int DISTRICT_CODE { get; set; }
        /// <summary>
        /// BLOCK Name
        /// </summary>
        public string DISTRICT_NAME { get; set; }
        /// <summary>
        /// District Id
        /// </summary>
        public int DIST_ID { get; set; }
        /// <summary>
        /// Ovveride the Primary key of the entity
        /// </summary>
        public override int Key
        {
            get { return ID; }
            set { ID = value; }
        }
    }
}
