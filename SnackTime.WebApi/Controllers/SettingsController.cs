using Microsoft.AspNetCore.Mvc;
using SnackTime.Core.Settings;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly SettingsService _settingsService;

        public SettingsController(SettingsService settingsService)
        {
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