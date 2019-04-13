using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackTime.MediaServer.Service.Episode;
using SnackTime.WebApi.Helpers;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Episode : ControllerBase
    {
        private readonly MediaServer.Service.Episode.Episode.EpisodeClient _episodeProvider;

        public Episode(MediaServer.Service.Episode.Episode.EpisodeClient episodeProvider)
        {
            _episodeProvider = episodeProvider;
        }

        [HttpGet("series/{seriesId}")]
        public async Task<ActionResult> GetEpisodesBySeriesId(int seriesId)
        {
            var res = await _episodeProvider.GetBySeriesIdAsync(new GetBySeriesIdRequest {SeriesId = seriesId});
            return Ok(ApiResponseFactory.CreateSuccess(res.Episodes));
        }

        [HttpGet("{episodeId}")]
        public async Task<ActionResult> GetEpisodeById(int episodeId)
        {
            var res = await _episodeProvider.GetByIdAsync(new GetByIdRequest {Id = episodeId});
            return Ok(ApiResponseFactory.CreateSuccess(res.Episode));
        }
    }
}