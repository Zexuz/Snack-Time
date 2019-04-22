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
        private readonly ISessionRepoFactory        _sessionRepoFactory;
        private readonly SessionSyncService         _sessionSyncService;

        public SessionController(ILogger<SessionController> logger, SessionSyncService sessionSyncService, ISessionRepoFactory sessionRepoFactory)
        {
            _logger = logger;
            _sessionSyncService = sessionSyncService;
            _sessionRepoFactory = sessionRepoFactory;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            var session = await _sessionRepoFactory.GetRepo();
            return Ok(await session.GetAll());
        }

        [HttpGet("sync")]
        public async Task<ActionResult> SyncSession()
        {
            await _sessionSyncService.Sync();
            return Ok();
        }
    }
}