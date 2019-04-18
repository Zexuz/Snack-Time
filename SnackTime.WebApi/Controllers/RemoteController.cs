using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Media.Episodes;
using SnackTime.Core.Process;
using SnackTime.Core.Session;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class RemoteController : ControllerBase
    {
        private readonly ProcessManager            _processManager;
        private readonly EpisodeFileLookupProvider _fileLookupProvider;
        private readonly Queue<Item>               _queue;

        public RemoteController(ProcessManager processManager, EpisodeFileLookupProvider fileLookupProvider, Queue<Item> queue)
        {
            _processManager = processManager;
            _fileLookupProvider = fileLookupProvider;
            _queue = queue;
        }

        [HttpGet("play/{mediaFileIdStr}/{startPositionInSec?}")]
        public async Task<ActionResult> PlayMedia(string mediaFileIdStr, int startPositionInSec)
        {
            if (!MediaFileId.TryParse(mediaFileIdStr, out var mediaFileId))
                return BadRequest($"{nameof(mediaFileIdStr)} is invalid");

            if (startPositionInSec < 0)
                return BadRequest($"{nameof(startPositionInSec)} must be > 0");

            if (!_processManager.IsMpvRunning())
            {
                var path = "C:\\Program Files (x86)\\SVP 4\\mpv64\\mpv.exe";
                var arguments = new[] {$"--input-ipc-server={NamedPipeFactory.GetPipeNameForCurrentOs()}"};
                _processManager.StartProcess(path, arguments);
            }

            if (!_processManager.IsSvpRunning())
            {
                var path = "C:\\Program Files (x86)\\SVP 4\\SVPManager.exe";
                _processManager.StartProcess(path);
            }

            var fileInfo = await _fileLookupProvider.GetFileInfoForId(mediaFileId.FileId);

            _queue.AddToQueue(new Item
            {
                Path = fileInfo.Path,
                MediaFileId = mediaFileId
            });

            return StatusCode(202);
        }
    }
}