using System;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;

namespace Mpv.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Remote : ControllerBase
    {
        private readonly IApi _api;

        public Remote(IApi api)
        {
            _api = api;
        }

        [HttpPost("toggle")]
        public ActionResult Post()
        {
            _api.ShowText("asdasd", TimeSpan.FromSeconds(3));

            return Ok();
        }
    }
}