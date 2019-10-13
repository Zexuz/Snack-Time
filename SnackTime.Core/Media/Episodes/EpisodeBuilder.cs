using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Models.ProtoGenerated;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.Core.Media.Episodes
{
    public class EpisodeBuilder
    {
        private readonly ISessionRepoFactory _sessionRepoFactory;

        public EpisodeBuilder(ISessionRepoFactory sessionRepoFactory)
        {
            _sessionRepoFactory = sessionRepoFactory;
        }

        public async Task<List<Episode>> Build(IEnumerable<SonarrSharp.Models.Episode> episodes)
        {
            var tasks = episodes.Select(Build).ToList();
            await Task.WhenAll(tasks);

            return tasks.Select(task => task.Result)
                .OrderByDescending(episode => episode.SeasonNumber)
                .ToList();
        }

        public async Task<Episode> Build(SonarrSharp.Models.Episode episode)
        {
            var mediaId = new MediaIdFactory().FromEpisode(episode);
            var sessionRepo = await _sessionRepoFactory.GetRepo();

            var allSessionsForCurrentEpisode = (await sessionRepo.GetAll())
                .Where(session => session.MediaId == mediaId.ToString())
                .ToList();

            var lastSession = allSessionsForCurrentEpisode.OrderByDescending(session => session.EndUTC).FirstOrDefault();

            return new Episode
            {
                Title = GrpcStringParser.Parse(episode.Title),
                Overview = GrpcStringParser.Parse(episode.Overview),
                SeriesId = episode.SeriesId,
                SeasonNumber = episode.SeasonNumber,
                EpisideNumber = episode.EpisodeNumber,
                EpisodeFileId = episode.EpisodeFileId,
                PlayableId = new PlayableId(Provider.Sonarr, episode.EpisodeFileId).ToString(),
                Progress = new Progress
                {
                    LastWatchedUtc = lastSession?.EndUTC                 ?? 0,
                    WatchedInSec = lastSession?.Duration.EndPostionInSec ?? 0,
                    Lenght = lastSession?.MediaLenghtInSec               ?? 0
                },
            };
        }
    }
}