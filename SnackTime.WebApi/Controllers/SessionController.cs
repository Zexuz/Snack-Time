using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Session;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;
        private readonly SessionService             _sessionService;
        private readonly SessionSyncService         _sessionSyncService;

        public SessionController(ILogger<SessionController> logger, SessionService sessionService, SessionSyncService sessionSyncService)
        {
            _logger = logger;
            _sessionService = sessionService;
            _sessionSyncService = sessionSyncService;
        }

        [HttpGet("")]
        public ActionResult GetAll()
        {
            return Ok(_sessionService.GetAll());
        }

        [HttpGet("sync")]
        public async Task<ActionResult> SyncSession()
        {
            await _sessionSyncService.Sync();
            return Ok();
        }
    }
}