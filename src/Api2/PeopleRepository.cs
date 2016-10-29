using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Api2
{
    public class PeopleRepository
    {
        private string connectionString;
        private ICurrentRequest request;

        public PeopleRepository(ICurrentRequest request)
        {
            this.request = request; 
            connectionString = @"Data Source=(local);Initial Catalog=DotNext;Integrated Security=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        private void BeforeCall(IDbConnection dbConnection)
        {
            var educationContext = request.context.CurrentUser.Claims.FirstOrDefault(c => c.Type == "client_educationContext")?.Value ?? "";
            var dbUser = request.context.CurrentUser.Claims.FirstOrDefault(c => c.Type == "client_dbuser")?.Value ?? "";
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
            using (IDbConnection dbConnection = Connection)
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
