using System.Collections.Generic;
using System.Linq;
using SnackTime.MediaServer.Models.ProtoGenerated;

namespace SnackTime.Core.Media.Episodes
{
    public class EpisodeBuilder
    {
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

            return new Episode
            {
                Title = GrpcStringParser.Parse(episode.Title),
                Overview = GrpcStringParser.Parse(episode.Overview),
                SeriesId = episode.SeriesId,
                SeasonNumber = episode.SeasonNumber,
                EpisideNumber = episode.EpisodeNumber,
                EpisodeFileId = episode.EpisodeFileId,
                PlayableId = mediaFileId.ToString(),
            };
        }
    }
}