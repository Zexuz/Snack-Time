using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Session;
using SnackTime.Core.Settings;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly SessionService _sessionService;

        public SessionController(ILogger<SessionController> logger, SessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [HttpGet("")]
        public ActionResult GetSettings()
        {
            return Ok(_sessionService.GetAll());
        }

    }
}