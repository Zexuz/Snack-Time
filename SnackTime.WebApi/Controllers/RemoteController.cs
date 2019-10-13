using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Media;
using SnackTime.Core.Media.Episodes;
using SnackTime.Core.Process;
using SnackTime.Core.Session;
using SnackTime.Core.Settings;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class RemoteController : ControllerBase
    {
        private readonly ProcessManager            _processManager;
        private readonly EpisodeFileLookupProvider _fileLookupProvider;
        private readonly Queue<Item>               _queue;
        private readonly SettingsService           _settingsService;

        public RemoteController
        (
            ProcessManager processManager,
            EpisodeFileLookupProvider fileLookupProvider,
            Queue<Item> queue,
            SettingsService settingsService
        )
        {
            _processManager = processManager;
            _fileLookupProvider = fileLookupProvider;
            _queue = queue;
            _settingsService = settingsService;
        }

        [HttpGet("play/{playableIdStr}/{startPositionInSec?}")]
        public async Task<ActionResult> PlayMedia(string playableIdStr, double startPositionInSec)
        {
            if (!PlayableId.TryParse(playableIdStr, out var playableId))
                return BadRequest($"{nameof(playableIdStr)} is invalid");

            if (startPositionInSec < 0)
                return BadRequest($"{nameof(startPositionInSec)} must be > 0");

            var settings = _settingsService.Get();

            if (string.IsNullOrWhiteSpace(settings.System.MpvPath))
                return BadRequest("mpv path must be set in the settings tab");

            if (!_processManager.IsMpvRunning())
            {
                var arguments = new[] {$"--input-ipc-server={NamedPipeFactory.GetPipeNameForCurrentOs()}"};
                _processManager.StartProcess(settings.System.MpvPath, arguments);
            }

            if (!_processManager.IsSvpRunning() && !string.IsNullOrWhiteSpace(settings.System.SvpPath))
            {
                _processManager.StartProcess(settings.System.SvpPath);
            }

            var fileInfo = await _fileLookupProvider.GetFileInfoForId(playableId.FileId);

            _queue.AddToQueue(new Item
            {
                Path = fileInfo.Path,
                MediaId = new MediaId() //TODO compine MediaId and PlayableId...
                PlayableId = playableId,
                StartPosition = TimeSpan.FromSeconds(startPositionInSec),
            });

            return StatusCode(202);
        }
    }
}