using System.Threading.Tasks;
using MediaHelper.Protobuf.grpc.Impl;
using Microsoft.AspNetCore.Mvc;
using SonarrSharp;

namespace MediaHelper.Blazor.Server.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        
        [HttpGet]
        public async Task<OkObjectResult> Get()
        {
            var client = new SonarrClient("localhost",8989,"2e8fcac32bf147608239cab343617485");
            var series = await client.Series.GetSeries(true);
            return Ok(series);
        }
    }
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        [HttpGet("{seriesId}")]
        public async Task<OkObjectResult> Get(int seriesId)
        {
            var client = new SonarrClient("localhost",8989,"2e8fcac32bf147608239cab343617485");
            var episodes = await client.Episode.GetEpisodes(seriesId);
            return Ok(episodes);
        }
    }
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        [HttpPost("open/{episodeFileId}")]
        public async Task<OkResult> Get(int episodeFileId)
        {
            var client = new SonarrClient("localhost",8989,"2e8fcac32bf147608239cab343617485");
            var episodeFile = await client.EpisodeFile.GetEpisodeFile(episodeFileId);
            
            var mpcHcClient = new MediaPlayerClient("localhost", 50051);
            await mpcHcClient.OpenFile(episodeFile.Path);
            
            return Ok();
        }
    }
    
    
    
    
}