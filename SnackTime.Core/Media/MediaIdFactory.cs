using SnackTime.MediaServer.Models.ProtoGenerated;

namespace SnackTime.Core.Media
{
    public class MediaIdFactory
    {
        public MediaId FromEpisode(SonarrSharp.Models.Episode episode)
        {
            var episodeId = new EpisodeId
            {
                SeriesId = episode.SeriesId,
                SeasonNr = episode.SeasonNumber,
                EpisodeNr = episode.EpisodeNumber,
            };

            return new MediaId(Provider.Sonarr, episodeId.ToString());
        }
    }
}