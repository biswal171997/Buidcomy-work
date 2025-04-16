using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BUIDCO.Repository.Extention
{
    public class MySqlDynamicParameters : SqlMapper.IDynamicParameters
    {
        private readonly DynamicParameters dynamicParameters = new DynamicParameters();
        private readonly List<MySqlParameter> sqlParameters = new List<MySqlParameter>();

        public void Add(string name, MySqlDbType sqlDbType, ParameterDirection direction, object value = null, int? size = null)
        {
            var sqlParameter = new MySqlParameter();
            if (size.HasValue)
            {
                sqlParameter.ParameterName = name;
                sqlParameter.MySqlDbType = sqlDbType;
                sqlParameter.Direction = direction;
                sqlParameter.Value = value;
                sqlParameter.Size = size.Value;
            }
            else
            {
                sqlParameter.ParameterName = name;
                sqlParameter.MySqlDbType = sqlDbType;
                sqlParameter.Direction = direction;
                sqlParameter.Value = value;
            }

            sqlParameters.Add(sqlParameter);
        }

        public void Add(string name, MySqlDbType sqlDbType, ParameterDirection direction)
        {
            var sqlParameter = new MySqlParameter();
            sqlParameter.ParameterName = name;
            sqlParameter.MySqlDbType = sqlDbType;
            sqlParameter.Direction = direction;
            sqlParameters.Add(sqlParameter);
        }

        public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            ((SqlMapper.IDynamicParameters)dynamicParameters).AddParameters(command, identity);

            var sqlCommand = command as MySqlCommand;

            if (sqlCommand != null)
            {
                sqlCommand.Parameters.AddRange(sqlParameters.ToArray());
            }
        }
        public object GetOutParamValue(string param)
        {
            object res = 0;
            MySqlCommand cmd = new MySqlCommand();
            res = Convert.ToString(cmd.Parameters[param].Value);
            return res;
        }
    }
}
