using Autofac;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using SnackTime.Core.Settings;
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
            builder.RegisterType<GrpcClientProvider>().AsSelf().SingleInstance();
            builder.RegisterType<MediaPlayerObserver>().As<IHostedService>().SingleInstance();

            builder.RegisterType<FileService>().AsSelf();
            builder.RegisterType<SessionSyncService>().AsSelf();
            builder.RegisterType<FileDownloadService>().AsSelf();
        }
    }

    public class GrpcClientProvider
    {
        private readonly SettingsService _settingsService;

        //TODO FIXT THIS!
        private static Channel _lastChannel = new Channel("127.0.0.1:50052", ChannelCredentials.Insecure);
        private static string  _lastAddress = "127.0.0.1";

        public GrpcClientProvider(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }


        public Series.SeriesClient GetSeriesClient()
        {
            return new Series.SeriesClient(GetChannel());
        }

        public Episode.EpisodeClient GetEpisodeClient()
        {
            return new Episode.EpisodeClient(GetChannel());
        }

        public File.FileClient GetFileClient()
        {
            return new File.FileClient(GetChannel());
        }

        public Session.SessionClient GetSessionClient()
        {
            return new Session.SessionClient(GetChannel());
        }

        private Channel GetChannel()
        {
            var address = _settingsService.Get().MediaServerAddress;
            if (_lastAddress == address)
            {
                return _lastChannel;
            }

            _lastAddress = address;
            _lastChannel = new Channel(_lastAddress, 50052, ChannelCredentials.Insecure);

            return _lastChannel;
        }
    }
}