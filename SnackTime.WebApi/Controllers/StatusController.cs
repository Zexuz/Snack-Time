using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Settings;
using SnackTime.WebApi.Helpers;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly StatusService _statusService;

        public StatusController(ILogger<StatusController> logger, StatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        [HttpGet("isOnline")]
        public ActionResult IsOnline()
        {
            var isOnline = _statusService.IsOnline();
            return Ok(ApiResponseFactory.CreateSuccess(isOnline));
        }
    }
}