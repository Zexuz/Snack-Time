using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnackTime.Series.ProtoGenerated;
using SonarrSharp;
using SonarrSharp.Enum;

namespace SnackTime.Core.Episodes
{
    public class EpisodeProvider
    {
        private readonly SonarrClient   _client;
        private readonly EpisodeBuilder _seriesBuilder;

        public EpisodeProvider(SonarrClient client)
        {
            _client = client;
            _seriesBuilder = new EpisodeBuilder();
        }

        public async Task<List<SnackTime.Episodes.ProtoGenerated.Episode>> GetEpisodesForSeriesById(int seriesId)
        {
            var episodes = await _client.Episode.GetEpisodes(seriesId);
            return _seriesBuilder.Build(episodes);
        }

        public async Task<SnackTime.Episodes.ProtoGenerated.Episode> GetEpisodeById(int id)
        {
            var episodes = await _client.Episode.GetEpisode(id);
            return _seriesBuilder.Build(episodes);
        }
    }

    public class EpisodeBuilder
    {
        public List<SnackTime.Episodes.ProtoGenerated.Episode> Build(IEnumerable<SonarrSharp.Models.Episode> episodes)
        {
            return episodes.Select(Build)
                .OrderByDescending(episode => episode.SeasonNumber)
                .ToList();
        }

        public SnackTime.Episodes.ProtoGenerated.Episode Build(SonarrSharp.Models.Episode episode)
        {
            return new SnackTime.Episodes.ProtoGenerated.Episode
            {
                Title = GrpcStringParser.Parse(episode.Title),
                Overview = GrpcStringParser.Parse(episode.Overview),
                SeriesId = episode.SeriesId,
                SeasonNumber = episode.SeasonNumber,
                EpisideNumber = episode.EpisodeNumber,
                EpisodeFileId = episode.EpisodeFileId,
            };
        }
    }

    public static class GrpcStringParser
    {
        public static string Parse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return string.Empty;
            }


            return string.IsNullOrWhiteSpace(str) ? string.Empty : str;
        }
    }
}