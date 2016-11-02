using Nancy;
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
        NancyContext Context { get; }
    }

    internal class CurrentRequest: ICurrentRequest
    {
        public NancyContext Context { get; }

        public CurrentRequest(NancyContext context)
        {
            Context = context;
        }
    }
}
