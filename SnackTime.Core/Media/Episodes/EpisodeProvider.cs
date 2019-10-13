using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using SnackTime.Core.Database;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Models.ProtoGenerated;
using SonarrSharp;

namespace SnackTime.Core.Media.Episodes
{
    public class EpisodeProvider
    {
        private readonly SonarrClient        _client;
        private readonly EpisodeBuilder      _seriesBuilder;
        private readonly ISessionRepoFactory _sessionRepoFactory;

        public EpisodeProvider(SonarrFactory sonarrFactory, EpisodeBuilder episodeBuilder, ISessionRepoFactory sessionRepoFactory)
        {
            _client = sonarrFactory.GetClient();
            _seriesBuilder = episodeBuilder;
            _sessionRepoFactory = sessionRepoFactory;
        }

        public async Task<List<Episode>> GetEpisodesForSeriesById(int seriesId)
        {
            var episodes = await _client.Episode.GetEpisodes(seriesId);
            return await _seriesBuilder.Build(episodes);
        }

        public async Task<Episode> GetEpisodeById(int id)
        {
            var episodes = await _client.Episode.GetEpisode(id);
            return await _seriesBuilder.Build(episodes);
        }

        public async Task<Episode> GetRecommended(int seriesId)
        {
            var sessionRepo = await _sessionRepoFactory.GetRepo();
            var session = await sessionRepo.GetLastSessionForMedia(new MediaId(Provider.Sonarr, seriesId.ToString()));

            if (!MediaId.TryParse(session.MediaId, out var mediaId))
            {
                throw new Exception($"Media file id {session.MediaId} is invalid");
            }

            if (!EpisodeId.TryParse(mediaId.IdFromProvider, out var episodeId))
            {
                throw new Exception($"Episode id {session.MediaId} is invalid");
            }

            var episodes = (await GetEpisodesForSeriesById(seriesId))
                .OrderBy(episode => episode.SeasonNumber)
                .ThenBy(episode => episode.EpisodeFileId)
                .ToArray();

            var index = GetIndex(episodes, episodeId);

            var watchedEpisodeToEnd = false;
            if (watchedEpisodeToEnd)
            {
                return episodes[index + 1];
            }

            return episodes[index];
        }

        private static int GetIndex(Episode[] episodes, EpisodeId episodeToFind)
        {
            return Array.FindIndex(episodes, w => w.SeasonNumber == episodeToFind.SeasonNr && w.EpisideNumber == episodeToFind.EpisodeNr);
        }
    }
}