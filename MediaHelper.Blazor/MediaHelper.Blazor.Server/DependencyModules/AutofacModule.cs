using Autofac;
using MediaHelper.EventBus;
using Microsoft.Extensions.Configuration;

namespace MediaHelper.Blazor.Server.DependencyModules
{
    public class AutofacModule : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RabbitMqEventBus>().As<IEventBus>();
            
//            builder.RegisterType<ProcessManager>().As<ProcessManager>().SingleInstance();
            builder.Register(context => new RabbitMqConnection("localhost")).As<IEventBusConnection>().SingleInstance();


//            builder.Register(context =>
//            {
//                var mediaHub = context.Resolve<IHubContext<MediaPlayerHub>>();
//                return new WebSocketWrapper((message, methodName) => mediaHub.Clients.All.SendAsync(methodName, message));
//            }).As<IWebSocketWrapper>();
        }
    }
}