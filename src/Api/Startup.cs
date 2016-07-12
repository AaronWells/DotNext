using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Api.Models;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddAuthorization();

            services.AddScoped<ISqlServerConnection, ScopedSqlServerConnection>();

            const string connection = @"Data Source=(local);Initial Catalog=DotNext;Integrated Security=True";
            services.AddDbContext<DotNextContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,

                ScopeName = "api1",
                AutomaticAuthenticate = true
            });

            app.UseRowLevelAuthenticationContext();

            app.UseMvc();
        }
    }
}