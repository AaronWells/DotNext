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

        public ApiModule(PeopleRepository repository): base("/api")
        {
            this.RequiresAuthentication();    
            Get("/{resource}", args =>
            {
                return repository.GetAll(args.resource);
            });
        }
    }
}
