using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core.Media.Episodes;
using SnackTime.Core.Process;
using SnackTime.Core.Session;
using SnackTime.MediaServer.Models.ProtoGenerated;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Remote : ControllerBase
    {
        private readonly IApi                      _api;
        private readonly ProcessManager            _processManager;
        private readonly EpisodeFileLookupProvider _fileLookupProvider;
        private readonly Queue<Item>               _queue;

        public Remote(ProcessManager processManager, EpisodeFileLookupProvider fileLookupProvider, Queue<Item> queue)
        {
            _processManager = processManager;
            _fileLookupProvider = fileLookupProvider;
            _queue = queue;
        }

        [HttpGet("play/{fileId}")]
        public async Task<ActionResult> PlayMedia(int fileId)
        {
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

            var fileInfo = await _fileLookupProvider.GetFileInfoForId(fileId);

            _queue.AddToQueue(new Item
            {
                Path = fileInfo.Path,
                FileId = fileInfo.SeriesId,
                Provider = Providers.Sonarr,
            });

            return StatusCode(202);
        }
    }
}