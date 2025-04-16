// ***********************************************************************
// Assembly         : DataUnification.Domain
// Author           : 
// Created          : 
//
// Last Modified By :  
// Last Modified On : 
// ***********************************************************************
// <copyright file="Districts.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BUIDCO.Domain.Common
{
    /// <summary>
    /// District model
    /// </summary>
    public class Districts: BaseEntity<int>
    {
        /// <summary>
        /// District Id
        /// </summary>
        public int DIVISION_CODE { get; set; }
        /// <summary>
        /// District Name
        /// </summary>
        public string DIVISION_NAME { get; set; }
        /// <summary>
        /// State Id
        /// </summary>
        public int? StateId { get; set; }
        /// <summary>
        /// Deleted flag : 1-deleted, 0-active
        /// </summary>
        /// 
        public int intlevelid { get; set; }
        public bool bitStatus { get; set; }
        /// <summary>
        /// Ovveride the Primary key of the entity
        /// </summary>
        public override int Key
        {
            get { return DIVISION_CODE; }
            set { DIVISION_CODE = value; }
        }
    }
}
