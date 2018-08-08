using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonarrSharp;

namespace MediaHelper.Blazor.Server.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        [HttpGet("{seriesId}")]
        public async Task<OkObjectResult> Get(int seriesId)
        {
            var client = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");
            var episodes = await client.Episode.GetEpisodes(seriesId);
            return Ok(episodes);
        }
    }
}