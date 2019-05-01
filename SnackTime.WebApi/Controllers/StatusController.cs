using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackTime.WebApi.Helpers;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly StatusService             _statusService;
        private readonly INotify                   _notify;

        public StatusController(ILogger<StatusController> logger, StatusService statusService, INotify notify)
        {
            _logger = logger;
            _statusService = statusService;
            _notify = notify;
        }

        [HttpGet("isOnline")]
        public async Task<ActionResult> IsOnline()
        {
            var isOnline = await _statusService.IsOnline();
            return Ok(ApiResponseFactory.CreateSuccess(isOnline));
        }

        [HttpGet("sendWebsocket")]
        public async Task<ActionResult> SendWebSocket()
        {
            await _notify.SendToAll("This is a message");
            return Ok();
        }
    }
}