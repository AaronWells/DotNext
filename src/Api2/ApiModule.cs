using Nancy;
using Nancy.Security;
using System.Security.Claims;

namespace Api2
{
    public class ApiModule : NancyModule
    {
        protected ClaimsPrincipal Principal
        {
            get { return Context.CurrentUser; }
        }

        public ApiModule(PeopleRepository repository)
        {
            this.RequiresAuthentication();

            Get("/", args => "Hello World, it's Nancy on .NET Core");
            Get("/claims", args => Principal.Claims);
            Get("/api/{resource}", args =>
            {
                return repository.GetAll(args.resource);
            });
        }
    }
}
