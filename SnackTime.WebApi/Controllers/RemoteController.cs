using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core.Media.Episodes;
using SnackTime.Core.Process;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Remote : ControllerBase
    {
        private readonly IApi            _api;
        private readonly ProcessManager _processManager;
        private readonly EpisodeFileLookupProvider _fileLookupProvider;
        private readonly EpisodeProvider _episodeProvider;

        public Remote(IApi api, ProcessManager processManager, EpisodeFileLookupProvider fileLookupProvider, EpisodeProvider episodeProvider)
        {
            _api = api;
            _processManager = processManager;
            _fileLookupProvider = fileLookupProvider;
            _episodeProvider = episodeProvider;
        }

        [HttpPost("toggle")]
        public ActionResult Post()
        {
            _api.ShowText("asdasd", TimeSpan.FromSeconds(3));

            return Ok();
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

            await _api.ShowText($"Now playing {fileInfo.Path.Substring(fileInfo.Path.LastIndexOf('\\') + 1)}", TimeSpan.FromSeconds(5));
            await _api.PlayMedia(fileInfo.Path);

            return Ok();
        }
    }
}