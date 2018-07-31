using System.Collections.Generic;
using System.Threading.Tasks;
using Localnetflix.Backend.Database;
using Localnetflix.Backend.Database.Models;
using LocalNetflix.Backend;
using Microsoft.AspNetCore.Mvc;

namespace LocalNetflix.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeriesController:Controller
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }
        
        
        [HttpGet("")]
        public ActionResult<List<Series>> GetAll()
        {
            return Ok(_seriesService.GetAll());
        }

        
    }
}