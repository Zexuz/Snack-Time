using Grpc.Core;
using SnackTime.Core.Settings;
using SnackTime.MediaServer.Service.Episode;
using SnackTime.MediaServer.Service.File;
using SnackTime.MediaServer.Service.Series;
using Status = SnackTime.MediaServer.Service.Status.Status;

namespace SnackTime.Core
{
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

        public MediaServer.Service.Session.Session.SessionClient GetSessionClient()
        {
            return new MediaServer.Service.Session.Session.SessionClient(GetChannel());
        }

        public Status.StatusClient GetStatusClient()
        {
            return new Status.StatusClient(GetChannel());
        }

        private Channel GetChannel()
        {
            var address = _settingsService.Get().Remote.MediaServerAddress;
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