using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonarrSharp;
using SonarrSharp.Models;

namespace MediaHelper.Blazor.Server.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Series[]>> Get()
        {
            var client = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");
            var series = await client.Series.GetSeries(true);
            return Ok(series);
        }
        
        [HttpGet("{seriesId}")]
        public async Task<ActionResult<Series>> GetById(int seriesId)
        {
            var client = new SonarrClient("localhost", 8989, "2e8fcac32bf147608239cab343617485");
            var series = await client.Series.GetSeries(seriesId,true);
            return Ok(series);
        }
    }
}