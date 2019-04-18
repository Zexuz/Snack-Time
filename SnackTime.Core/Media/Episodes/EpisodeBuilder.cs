using System.Collections.Generic;
using System.Linq;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Models.ProtoGenerated;
using SnackTime.MediaServer.Storage.ProtoGenerated;

namespace SnackTime.Core.Media.Episodes
{
    public class EpisodeBuilder
    {
        private readonly SessionService _sessionService;

        public EpisodeBuilder(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public List<Episode> Build(IEnumerable<SonarrSharp.Models.Episode> episodes)
        {
            return episodes.Select(Build)
                .OrderByDescending(episode => episode.SeasonNumber)
                .ToList();
        }

        public Episode Build(SonarrSharp.Models.Episode episode)
        {
            var mediaFileId = new MediaFileId
            {
                Provider = Providers.Sonarr,
                MediaId = episode.SeriesId,
                FileId = episode.EpisodeFileId,
            };

            var allSessionsForCurrentEpisode = _sessionService.GetAll()
                .Where(session => session.MediaId == mediaFileId.ToString())
                .ToList();

            var end = allSessionsForCurrentEpisode.Max(session => (long?) session.Duration.EndPostionInSec) ?? 0;
            var lastWatchedSession = allSessionsForCurrentEpisode.OrderBy(session => session.EndUTC).FirstOrDefault();

            return new Episode
            {
                Title = GrpcStringParser.Parse(episode.Title),
                Overview = GrpcStringParser.Parse(episode.Overview),
                SeriesId = episode.SeriesId,
                SeasonNumber = episode.SeasonNumber,
                EpisideNumber = episode.EpisodeNumber,
                EpisodeFileId = episode.EpisodeFileId,
                PlayableId = mediaFileId.ToString(),
                Progress = new Progress
                {
                    LastWatchedUtc = lastWatchedSession?.EndUTC ?? 0,
                    WatchedInSec = end,
                    Lenght = lastWatchedSession?.MediaLenghtInSec ?? 0
                },
            };
        }
    }
}