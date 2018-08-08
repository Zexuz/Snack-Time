using System.Threading.Tasks;
using MediaHelper.Backend;
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
            var client = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");
            var series = await client.Series.GetSeries(true);
            return Ok(series);
        }

        [HttpGet("lastWatched")]
        public async Task<OkObjectResult> LastWatched()
        {
            var mediaFileService = new MedieFileService();
            return Ok(mediaFileService.GetLastWatched());
        }
    }
}