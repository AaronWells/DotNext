using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Api.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Api
{
    public class Startup
    {
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=DotNext;Integrated Security=True";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddAuthorization();
            
            services.AddDbContext<DotNextContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            //app.UseRowLevelAuthenticationContext();

            app.UseMvc();
        }
    }
}