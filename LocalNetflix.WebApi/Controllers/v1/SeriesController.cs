using System.Collections.Generic;
using System.Threading.Tasks;
using Localnetflix.Backend.Database;
using Localnetflix.Backend.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocalNetflix.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SeriesController:Controller
    {
        private readonly IRepository<Series> _seriesRepo;

        public SeriesController(IRepository<Series> seriesRepo)
        {
            _seriesRepo = seriesRepo;
        }
        
        
        [HttpGet("")]
        public ActionResult<List<Series>> GetAll()
        {
            return Ok(_seriesRepo.GetAll());
        }

        
    }
}