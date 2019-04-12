using System.Threading.Tasks;
using Autofac;
using Grpc.Core;
using SnackTime.MediaServer.ProtoGenerated;

namespace SnackTime.MediaServer
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Impl>().As<Greeter.GreeterBase>();
            builder.RegisterType<SeriesController>().As<Service.Series.Series.SeriesBase>();
        }
    }

    public class Impl : Greeter.GreeterBase
    {
        public override Task<GreetResponse> Greet(GreetRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GreetResponse
            {
                Phrase = $"Hello {request.Name}"
            });
        }
    }
}