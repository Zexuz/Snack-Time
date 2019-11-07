using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Repository;
using SonarrSharp;
using SonarrSharp.Models;
using Episode = SnackTime.Core.Repository.Episode;
using Series = SnackTime.Core.Repository.Series;
using Image = SnackTime.Core.Repository.Image;

namespace SnackTime.Core.Providers.Sonarr
{
    public class SonarrService : IProvider
    {
        private readonly SonarrClient           _client;
        private readonly SeriesRepo             _seriesRepo;
        private readonly EpisodeRepo            _episodeRepo;
        private readonly MediaFileRepo          _mediaFileRepo;
        private readonly ILogger<SonarrService> _logger;

        public SonarrService(SonarrClient client, SeriesRepo seriesRepo, ILogger<SonarrService> logger, EpisodeRepo episodeRepo,
                             MediaFileRepo mediaFileRepo)
        {
            _client = client;
            _seriesRepo = seriesRepo;
            _logger = logger;
            _episodeRepo = episodeRepo;
            _mediaFileRepo = mediaFileRepo;
        }


        public class SeriesWrapper
        {
            public Series               Series          { get; set; }
            public List<EpisodeWrapper> EpisodeWrappers { get; set; } = new List<EpisodeWrapper>();
        }

        public class EpisodeWrapper
        {
            public Episode     Episode     { get; set; }
            public EpisodeFile EpisodeFile { get; set; }
        }

        public async Task Sync()
        {
            _logger.LogInformation($"Starting Sync for provider 'Sonarr'");

            var sw = Stopwatch.StartNew();

            // TODO: Do this in Parallel instead of in series to increase performance
            foreach (var series in await _client.Series.GetSeries(true))
            {
                var seriesColl = _seriesRepo.GetDb().GetCollection<Series>();
                var episodeColl = _seriesRepo.GetDb().GetCollection<Episode>();

                episodeColl.EnsureIndex(episode => episode.ProviderId);

                seriesColl.Insert(new Series
                {
                    ProviderId = series.Id,
                    Title = series.Title,
                    Images = series.Images.Select(image => new Image {Type = image.CoverType.ToString("G"), Url = image.Url}).ToList(),
                });


                foreach (var episode in  await _client.Episode.GetEpisodes(series.Id))
                {
                    episodeColl.FindOne()
                    episodeColl.Insert()
                }


//                var episodes = await _client.Episode.GetEpisodes(series.Id);
//
//                foreach (var episode in episodes)
//                {
//                    var epColl = _episodeRepo.GetDb().GetCollection<Episode>();
//                    epColl.FindOne(e=>e. )
//                }
//
//                var e = episodes.Select(episode => new Repository.Episode
//                {
//                    Title = episode.Title,
//                    EpisodeNr = episode.EpisodeNumber,
//                    SeasonNr = episode.SeasonNumber,
////                    MediaFile = episode.EpisodeFileId,
//                    SeriesId = episode.SeriesId,
//                    HasWatchedToFinnish = false,
//                    ProviderId = episode.Id,
//                }).ToList();
//
//                _episodeRepo.Upsert(e);
//
//                var s = new Repository.Series
//                {
//                    Title = series.Title,
//                    ImageUrl = series.Images[0].Url,
//                    ProviderId = series.Id,
//                    Episodes = e.ToList()
//                };
//
//                _seriesRepo.Upsert(s);
//
////                foreach (var episode in episodes)
////                {
////                    var episodeFile = await GetEpisodeFile(episode);
////                    _mediaFileRepo.Upsert(new MediaFile
////                    {
////                        Path = episodeFile.SceneName,
////                        Quality = episodeFile.Quality.Quality.Name.ToString("G"),
////                        Length = episode.
////
////                    });
////                }
            }

            _logger.LogInformation($"Finished Sync for provider 'Sonarr', took {sw.Elapsed:g}");
        }

        private async Task<EpisodeFile> GetEpisodeFile(SonarrSharp.Models.Episode episode)
        {
            if (!episode.HasFile)
            {
                return null;
            }

            return await _client.EpisodeFile.GetEpisodeFile(episode.EpisodeFileId);
        }
    }


    public interface IProvider
    {
        Task Sync();
    }
}