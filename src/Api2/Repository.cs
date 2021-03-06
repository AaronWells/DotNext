﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Api2
{
    public class Repository
    {
        private readonly string _connectionString;
        private readonly ICurrentRequest _request;

        public Repository(ICurrentRequest request)
        {
            _request = request; 
            _connectionString = @"Data Source=(local);Initial Catalog=DotNext;Integrated Security=True";
        }

        public IDbConnection Connection => new SqlConnection(_connectionString);

        private void BeforeCall(IDbConnection dbConnection)
        {
            var educationContext = _request.Context.CurrentUser.Claims.FirstOrDefault(c => c.Type == "client_educationContext")?.Value ?? "";
            var dbUser = _request.Context.CurrentUser.Claims.FirstOrDefault(c => c.Type == "client_dbuser")?.Value ?? "";
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = $@"EXEC sp_set_session_context @key=N'UserId', @value='{educationContext}';" +
                              $@"EXECUTE AS USER = '{dbUser}';";
            cmd.ExecuteNonQuery();
        }

        private void AfterCall(IDbConnection dbConnection)
        {
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = $@"REVERT;";
            cmd.ExecuteNonQuery();
        }

        public IEnumerable<dynamic> GetAll(string resource)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                BeforeCall(dbConnection);
                var results = dbConnection.Query($"SELECT * FROM {resource}");
                AfterCall(dbConnection);
                return results;
            }
        }
    }
}
