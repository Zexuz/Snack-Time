using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly SettingsService _settingsService;

        public SettingsController(ILogger<SettingsController> logger, SettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        [HttpGet("")]
        public ActionResult GetSettings()
        {
            return Ok(_settingsService.Get());
        }

        [HttpPost("")]
        public ActionResult SaveSettings([FromBody] Settings settings)
        {
            _settingsService.Save(settings);
            return Ok();
        }
    }
}