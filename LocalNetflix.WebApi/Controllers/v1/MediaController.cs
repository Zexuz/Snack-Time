using System;
using System.Threading.Tasks;
using LocalNetflix.Grpc.Impl;
using Microsoft.AspNetCore.Mvc;

namespace LocalNetflix.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MediaController : Controller
    {
        private MediaPlayerClient _mediaPlayerClient;

        public MediaController()
        {
            _mediaPlayerClient = new MediaPlayerClient("localhost", 50051);
        }
        
        [HttpGet("playing/current")]
        public async Task<ActionResult<string>> Index()
        {
            var infoResponse = await _mediaPlayerClient.Info();
            
            if(infoResponse.IsError)
                return StatusCode(503,infoResponse.Error.ToString());

            var info = infoResponse.Response;
            
            var m = $"{info.State.ToString()}: {info.FileName}, [{TimeSpan.FromSeconds(info.Eplipsed)}/{TimeSpan.FromSeconds(info.Duration)}]";
            return Ok(m);
        }
    }
}