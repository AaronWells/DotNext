using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Models
{
    public class DotNextContextFactory : IDbContextFactory<DotNextContext>
    {
        public DotNextContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<DotNextContext>();
            DbConnection dbConnection = new SecureDbConnection();
            builder.UseSqlServer(dbConnection);
            return new DotNextContext(builder.Options);
        }
    }
}