using System;
using System.Threading.Tasks;
using LocalNetflix.Backend;
using LocalNetflix.Grpc.Impl;
using Microsoft.AspNetCore.Mvc;

namespace LocalNetflix.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MediaController : Controller
    {
        private readonly ISeriesService    _seriesService;
        private readonly IEpisodeFactory _episodeFactory;
        private          MediaPlayerClient _mediaPlayerClient;

        public MediaController(ISeriesService seriesService, IEpisodeFactory episodeFactory)
        {
            _seriesService = seriesService;
            _episodeFactory = episodeFactory;
            _mediaPlayerClient = new MediaPlayerClient("localhost", 50051);
        }

        [HttpGet("playing/current")]
        public async Task<ActionResult<string>> Index()
        {
            var infoResponse = await _mediaPlayerClient.Info();

            if (infoResponse.IsError)
                return StatusCode(503, infoResponse.Error.ToString());

            var info = infoResponse.Response;

            var episode = _episodeFactory.ParserEpisodeFromMediaInfo(info);
            _seriesService.NewSeriesInMediaPlayer(episode);

            var m = $"{info.State.ToString()}: {info.FileName}, [{TimeSpan.FromSeconds(info.Eplipsed)}/{TimeSpan.FromSeconds(info.Duration)}]";
            return Ok(m);
        }
    }
}