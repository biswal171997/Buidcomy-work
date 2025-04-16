// ***********************************************************************
// Assembly         : DataUnification.Domain
// Author           : 
// Created          : 
//
// Last Modified By :  
// Last Modified On : 
// ***********************************************************************
// <copyright file="Department.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace BUIDCO.Domain.Common
{
    public class Department : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int DEPTID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DEPTNAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool DELETEDFLAG { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override int Key
        {
            get { return DEPTID; }
            set { DEPTID = value; }
        }

    }
}
