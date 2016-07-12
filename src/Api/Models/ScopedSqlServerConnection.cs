using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Logging;

namespace Api.Models
{
    public class ScopedSqlServerConnection: SqlServerConnection
    {
        public ScopedSqlServerConnection(IDbContextOptions options, ILogger<SqlServerConnection> logger) : base(options, logger)
        {
        }

        public override void Open()
        {
            base.Open();
            var cmd = DbConnection.CreateCommand();
            cmd.CommandText = $@"EXEC sp_set_session_context @key=N'UserId', @value='Admin@email.com';";
            cmd.ExecuteNonQuery();
        }

        public override async Task OpenAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await base.OpenAsync(cancellationToken);
            var cmd = DbConnection.CreateCommand();
            cmd.CommandText = $@"EXEC sp_set_session_context @key=N'UserId', @value='Admin@email.com';";
            await cmd.ExecuteNonQueryAsync(cancellationToken);
        }
    }
}
