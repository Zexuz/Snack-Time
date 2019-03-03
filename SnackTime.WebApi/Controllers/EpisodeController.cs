using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackTime.Core.Episodes;
using SonarrSharp;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Episode : ControllerBase
    {
        private readonly EpisodeProvider _episodeProvider;

        public Episode(SonarrClient client)
        {
            _episodeProvider = new EpisodeProvider(client);
        }

        [HttpGet("series/{seriesId}")]
        public async Task<ActionResult> GetEpisodesBySeriesId(int seriesId)
        {
            var episodes = await _episodeProvider.GetEpisodesForSeriesById(seriesId);
            return Ok(ApiResponseFactory.CreateSuccess(episodes));
        }

        [HttpGet("{episodeId}")]
        public async Task<ActionResult> GetEpisodeById(int episodeId)
        {
            var episode = await _episodeProvider.GetEpisodeById(episodeId);
            return Ok(ApiResponseFactory.CreateSuccess(episode));
        }
    }
}