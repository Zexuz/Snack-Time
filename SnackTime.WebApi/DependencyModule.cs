using Autofac;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using SnackTime.MediaServer.Service.Episode;
using SnackTime.MediaServer.Service.File;
using SnackTime.MediaServer.Service.Series;
using SnackTime.MediaServer.Service.Session;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi
{
    public class DependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var channel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);

            builder.RegisterInstance(new Series.SeriesClient(channel)).AsSelf();
            builder.RegisterInstance(new Episode.EpisodeClient(channel)).AsSelf();
            builder.RegisterInstance(new File.FileClient(channel)).AsSelf();
            builder.RegisterInstance(new Session.SessionClient(channel)).AsSelf();

            builder.RegisterType<MediaPlayerObserver>().As<IHostedService>().SingleInstance();

            builder.RegisterType<FileService>().AsSelf();
            builder.RegisterType<FileDownloadService>().AsSelf();
        }
    }
}