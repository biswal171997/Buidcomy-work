using System.Data;
using System.Data.SqlClient ;
using MySql.Data.MySqlClient;
namespace BUIDCo_ePMS.Repository.Factory
{
    public class Db_BUIDCo_PMSConnectionFactory:IDb_BUIDCo_PMSConnectionFactory
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public Db_BUIDCo_PMSConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Gets the get connection.
        /// </summary>
        /// <value>The get connection.</value>
        public IDbConnection GetConnection => new MySqlConnection(_connectionString);
    }
}
