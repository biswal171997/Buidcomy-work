// ***********************************************************************
// Assembly         : BUIDCO.Web.Areas.AdminConsole
// Author           : Manas Bej
// Created          : 29-SEP-2018
//
// Last Modified By : Manoj Kumar Behera
// Last Modified On : 29-SEP-2018
// ***********************************************************************
// <copyright file="ConnectionFactory.cs" company="CSM technologies">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using MySql.Data.MySqlClient;
using System.Data;

namespace BUIDCO.Web.Areas.AdminConsole.Factory
{
    /// <summary>
    /// Class ConnectionFactory.
    /// </summary>
    /// <seealso cref="BUIDCO.Web.Areas.AdminConsole.Factory.IConnectionFactory" />
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public ConnectionFactory(string connectionString)
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
