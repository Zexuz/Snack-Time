using System.Linq;
using System.Threading.Tasks;
using MediaHelper.Backend;
using MediaHelper.Model;
using Microsoft.AspNetCore.Mvc;
using SonarrSharp;

namespace MediaHelper.Blazor.Server.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly MedieFileService _mediaFileService;
        private          SonarrClient     _sonarrClient;

        public EpisodeController()
        {
            _mediaFileService = new MedieFileService();
            _sonarrClient = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");
        }

        [HttpGet("{seriesId}")]
        public async Task<ActionResult> Get(int seriesId)
        {
            var episodes = await _sonarrClient.Episode.GetEpisodes(seriesId);
            return Ok(episodes);
        }

        [HttpGet("continueWatching/{seriesId}")]
        public async Task<ActionResult<ContinueWatchingResponse>> ContinueWatching(int seriesId)
        {
            var lastWatchedMediaFile = _mediaFileService.GetLastWatched(seriesId);
            var episodes = await _sonarrClient.Episode.GetEpisodes(seriesId);


            if (lastWatchedMediaFile == null)
                return Ok(new ContinueWatchingResponse
                {
                    Episode = episodes.First(episode => episode.SeasonNumber == 1),
                    Status = ContinueWatchingStatus.NewSeries
                });

            var lastWatchedEpisode = episodes.First(episode => episode.EpisodeFileId == lastWatchedMediaFile.IdFromProvider);
            if (!lastWatchedMediaFile.IsCompleted)
                return Ok(new ContinueWatchingResponse
                {
                    Episode = lastWatchedEpisode,
                    WhereToStart = lastWatchedMediaFile.Watched,
                    Status = ContinueWatchingStatus.InProgress
                });
            
            var nextEpisode = episodes.FirstOrDefault(episode => episode.Id == lastWatchedEpisode.Id + 1);
            if (nextEpisode == null)
            {
                return Ok(new ContinueWatchingResponse
                {
                    Episode = null,
                    Status = ContinueWatchingStatus.NoNewEpisodes
                });
            }

            return Ok(new ContinueWatchingResponse
            {
                Episode = nextEpisode,
                Status = ContinueWatchingStatus.NextEpisode
            });
        }
    }
}