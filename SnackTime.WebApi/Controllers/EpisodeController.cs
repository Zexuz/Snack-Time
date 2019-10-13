using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SnackTime.Core;
using SnackTime.MediaServer.Service.Episode;
using SnackTime.WebApi.Helpers;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Episode : ControllerBase
    {
        private readonly MediaServer.Service.Episode.Episode.EpisodeClient _episodeProvider;

        public Episode(GrpcClientProvider clientProvider)
        {
            _episodeProvider = clientProvider.GetEpisodeClient();
        }

        [HttpGet("series/{seriesId}")]
        public async Task<ActionResult> GetEpisodesBySeriesId(int seriesId)
        {
            var res = await _episodeProvider.GetBySeriesIdAsync(new GetBySeriesIdRequest {SeriesId = seriesId});
            return Ok(ApiResponseFactory.CreateSuccess(res.Episodes));
        }

        [HttpGet("series/{seriesId}/recommended")]
        public async Task<ActionResult> GetRecommendedEpisodeBySeriesId(int seriesId)
        {
            var res = await _episodeProvider.GetRecommendedBySeriesIdAsync(new GetRecommendedBySeriesIdRequest {SeriesId = seriesId});
            return Ok(ApiResponseFactory.CreateSuccess(res.Episode));
        }

        [HttpGet("{episodeId}")]
        public async Task<ActionResult> GetEpisodeById(int episodeId)
        {
            var res = await _episodeProvider.GetByIdAsync(new GetByIdRequest {Id = episodeId});
            return Ok(ApiResponseFactory.CreateSuccess(res.Episode));
        }
    }
}