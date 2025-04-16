using System;
using System.Collections.Generic;
using System.Text;

namespace BUIDCO.Domain.Common
{
    public class ComponentDomain : BaseEntity<int>
    {

        /// <summary>
        /// REGDID Id
        /// </summary>
        public int REGDID { get; set; }
        /// <summary>
        /// MEETING DATE
        /// </summary>
        public string MEETINGDATE { get; set; }
        /// <summary>
        /// LETTER NUMBER
        /// </summary>
        public string LETTERNO { get; set; }
        /// <summary>
        /// PROCEEDING FILE
        /// </summary>
        public string PROCEEDINGFILE { get; set; }
        /// <summary>
        /// TYPE
        /// </summary>
        public int TYPE { get; set; }
        /// <summary>
        /// CREATED BY
        /// </summary>
        public int CREATEDBY { get; set; }
        /// <summary>
        /// UPDATED BY
        /// </summary>
        public int UPDATEDBY { get; set; }
        /// <summary>
        /// COMPONENT ID
        /// </summary>
        public int COMPONENTID { get; set; }
        /// <summary>
        /// DEPT ID
        /// </summary>
        public int DEPTID { get; set; }
        /// <summary>
        /// COMPONENT NAME
        /// </summary>
        public string COMPONENTNAME { get; set; }
        /// <summary>
        /// TARGET DATE
        /// </summary>
        public string TARGETDATE { get; set; }
        /// <summary>
        /// Ovveride the Primary key of the entity
        /// </summary>
        public override int Key
        {
            get { return REGDID; }
            set { REGDID = value; }
        }
        /// <summary>
        /// COMPONENT NAME
        /// </summary>
        public bool DCOMPONENTNAME { get; set; }
        
    }
}
