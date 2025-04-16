namespace BUIDCO.Domain.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class States : BaseEntity<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int StateId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool bitStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public override int Key
        {
            get { return StateId; }
            set { StateId = value; }
        }
    }
}
