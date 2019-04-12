using System.Collections.Generic;
using System.Threading.Tasks;
using SnackTime.MediaServer.ProtoGenerated;
using SonarrSharp;

namespace SnackTime.Core.Media.Episodes
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

        public async Task<List<Episode>> GetEpisodesForSeriesById(int seriesId)
        {
            var episodes = await _client.Episode.GetEpisodes(seriesId);
            return _seriesBuilder.Build(episodes);
        }

        public async Task<Episode> GetEpisodeById(int id)
        {
            var episodes = await _client.Episode.GetEpisode(id);
            return _seriesBuilder.Build(episodes);
        }
    }
}