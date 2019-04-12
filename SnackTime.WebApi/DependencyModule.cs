using Autofac;
using Grpc.Core;
using SnackTime.MediaServer.Service.Episode;
using SnackTime.MediaServer.Service.Series;

namespace SnackTime.WebApi
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
            
            builder.RegisterInstance(new Series.SeriesClient(channel)).AsSelf();
            builder.RegisterInstance(new Episode.EpisodeClient(channel)).AsSelf();
        }
    }
}