using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class RowLevelAuthenticationContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DotNextContext _context;

        public RowLevelAuthenticationContextMiddleware(RequestDelegate next, DotNextContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task Invoke(HttpContext context)
        {
//            await _context.Database.ExecuteSqlCommandAsync($@"EXEC sp_set_session_context @key=N'UserId', @value='Admin@email.com';");
            await _next.Invoke(context);
        }
    }

    public static class RowLevelAuthenticationContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseRowLevelAuthenticationContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RowLevelAuthenticationContextMiddleware>();
        }
    }
}
