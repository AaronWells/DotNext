using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Api.Models
{
    public class SecureDbConnection : DbConnection
    {
        private readonly SqlConnection _sqlConnection;
        private string _userContext;

        public SecureDbConnection(string connectionString, string userContext)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _userContext = userContext;
        }
        
        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _sqlConnection.BeginTransaction(isolationLevel);
        }

        public override void Close()
        {
            _sqlConnection.Close();
        }

        public override void Open()
        {
            _sqlConnection.Open();
            var cmd = _sqlConnection.CreateCommand();
            cmd.CommandText = $@"EXEC sp_set_session_context @key=N'UserId', @value='{_userContext}';";
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
