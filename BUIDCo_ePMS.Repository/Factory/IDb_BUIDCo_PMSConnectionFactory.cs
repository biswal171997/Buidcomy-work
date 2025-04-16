using System.Data;

namespace BUIDCo_ePMS.Repository.Factory
{
     public interface IDb_BUIDCo_PMSConnectionFactory
    {
        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        IDbConnection GetConnection { get; }
    }
}
