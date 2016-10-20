using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Api.Models
{
    public class SecureDbConnection : DbConnection
    {
        private readonly SqlConnection _sqlConnection;
        private readonly string _userContext;
        private readonly string _dbUser;

        public SecureDbConnection(string connectionString, string userContext, string dbUser)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _userContext = userContext;
            _dbUser = dbUser;
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _sqlConnection.BeginTransaction(isolationLevel);
        }

        public override void Close()
        {
            var cmd = _sqlConnection.CreateCommand();
            cmd.CommandText = $@"REVERT;";
            cmd.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public override void Open()
        {
            _sqlConnection.Open();
            var cmd = _sqlConnection.CreateCommand();
            cmd.CommandText =   $@"EXEC sp_set_session_context @key=N'UserId', @value='{_userContext}';" +
                                $@"EXECUTE AS USER = '{_dbUser}';";
            cmd.ExecuteNonQuery();
        }

        public override string ConnectionString
        {
            get { return _sqlConnection.ConnectionString; }
            set { _sqlConnection.ConnectionString = value; }
        }

        public override string Database => _sqlConnection.Database;

        public override ConnectionState State => _sqlConnection.State;

        public override string DataSource => _sqlConnection.DataSource;

        public override string ServerVersion => _sqlConnection.ServerVersion;

        protected override DbCommand CreateDbCommand()
        {
            return _sqlConnection.CreateCommand();
        }

        public override void ChangeDatabase(string databaseName)
        {
            _sqlConnection.ChangeDatabase(databaseName);
        }
    }
}
