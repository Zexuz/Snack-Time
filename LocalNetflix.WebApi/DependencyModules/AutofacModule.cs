using Autofac;
using Localnetflix.Backend.Database;
using Localnetflix.Backend.Database.Models;
using LocalNetflix.Backend;
using LocalNetflix.WebApi.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace LocalNetflix.WebApi.DependencyModules
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
            builder.RegisterType<MediaPlayerHub>().As<MediaPlayerHub>();
            builder.RegisterType<Repository<Series>>().As<IRepository<Series>>();
            builder.RegisterType<SeriesRepository>().As<ISeriesRepository>();
            builder.RegisterType<EpisodeFileParserService>().As<IEpisodeFileParserService>();
            builder.RegisterType<SeriesService>().As<ISeriesService>();
            builder.RegisterType<EpisodeFactory>().As<IEpisodeFactory>();


            builder.Register(context =>
            {
                var mediaHub = context.Resolve<IHubContext<MediaPlayerHub>>();
                return new WebSocketWrapper((message, methodName) => mediaHub.Clients.All.SendAsync(methodName, message));
            }).As<IWebSocketWrapper>();
        }
    }
}