using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnackTime.Core.Settings;
using SnackTime.WebApi.Helpers;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly SettingsService             _settingsService;

        public SettingsController(ILogger<SettingsController> logger, SettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        [HttpGet("")]
        public ActionResult GetSettings()
        {
            var settings = _settingsService.Get();
            return Ok(ApiResponseFactory.CreateSuccess(settings));
        }

        [HttpPost("")]
        public ActionResult SaveSettings([FromBody] App.Settings.ProtoGenerated.Settings settings)
        {
            _settingsService.Save(settings);
            return Ok(ApiResponseFactory.CreateSuccess(new { }));
        }
    }
}