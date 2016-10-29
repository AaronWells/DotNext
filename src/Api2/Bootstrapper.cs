using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy.TinyIoc;

namespace Api2
{
    public class Bootstrapper: DefaultNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Register<ICurrentRequest>((c, o) => new CurrentRequest(context));
        }
    }

    public interface ICurrentRequest
    {
        NancyContext context { get; }
    }

    internal class CurrentRequest: ICurrentRequest
    {
        public NancyContext context { get; }

        public CurrentRequest(NancyContext context)
        {
            this.context = context;
        }
    }
}
