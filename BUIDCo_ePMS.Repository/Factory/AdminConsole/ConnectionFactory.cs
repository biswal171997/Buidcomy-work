// ***********************************************************************
// Assembly         : BUIDCO.Repository
// Author           : Monalisa Pahi
// Created          : 15-MAR-2021
//
// Last Modified By : Monalisa Pahi
// Last Modified On : 15-MAR-2021
// ***********************************************************************
// <copyright file="ConnectionFactory.cs" company="CSM technologies">
//     Copyright ©  2021
// </copyright>
// <summary></summary>
// ***********************************************************************
using BUIDCO.Repository.Contract.Factory;
using System.Data;
using MySql.Data.MySqlClient;

namespace BUIDCO.Repository.Factory
{
    /// <summary>
    /// Class ConnectionFactory.
    /// </summary>
    /// <seealso cref="BUIDCO.Repository.Contract.Factory.IConnectionFactory" />
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
