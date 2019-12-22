using System;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SnackTime.Core;
using SnackTime.Core.Providers.Sonarr;
using SnackTime.Core.Repository;
using SonarrSharp;

namespace Runner
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var client = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");
            var pathServcice = new PathService();

            var seriesRepo = new SeriesRepo(pathServcice);

            await new SonarrService(
                client,
                seriesRepo,
                new Logger<SonarrService>(new NullLoggerFactory()),
                new EpisodeRepo(pathServcice),
                new MediaFileRepo(pathServcice)
            ).Sync();
        }
    }
}