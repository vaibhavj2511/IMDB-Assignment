using Dapper;
using Microsoft.Extensions.Options;
using SessionDemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



namespace SessionDemoApp.Helper
{
    public class SqlHelper<G> : ISqlHelper<G>
    {
        private readonly ConnectionString _connectionString;

        public SqlHelper(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public void Execute(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                connection.ExecuteScalar(sql, param);
            }
        }

        public int Insert(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                int index = connection.ExecuteScalar<int>(sql, param);
                return index;
            }
        }

        public IEnumerable<G> Query(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                return connection.Query<G>(sql, param);
            }
        }

        public G SingleQuery(string sql, object param = null)
        {
            using (var connection = new SqlConnection(_connectionString.IMDBDB))
            {
                var value = connection.QueryFirstOrDefault<G>(sql, param);
                return value;
            }
        }
    }
}
