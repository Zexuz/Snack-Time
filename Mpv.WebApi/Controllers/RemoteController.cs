using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mpv.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Remote : ControllerBase
    {
        [HttpPost("toggle")]
        public ActionResult Post()
        {
            return Ok();
        }
    }
}