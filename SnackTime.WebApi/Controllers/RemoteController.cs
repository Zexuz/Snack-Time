using System;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core.Process;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class Remote : ControllerBase
    {
        private readonly IApi            _api;
        private readonly IProcessManager _processManager;

        public Remote(IApi api, IProcessManager processManager)
        {
            _api = api;
            _processManager = processManager;
        }

        [HttpPost("toggle")]
        public ActionResult Post()
        {
            _api.ShowText("asdasd", TimeSpan.FromSeconds(3));

            return Ok();
        }

        [HttpGet("play")]
        public ActionResult PlayMedia()
        {
            var path = "C:\\Program Files (x86)\\SVP 4\\mpv64\\mpv.exe";
            var arguments = new[] {$"--input-ipc-server={NamedPipeFactory.GetPipeNameForCurrentOs()}"};

            if (_processManager.IsProcessRunning(path))
            {
                return BadRequest($"Process {path} already running");
            }

            _processManager.StartProcess(path, arguments);

            _api.ShowText("Started", TimeSpan.FromSeconds(2));

            _api.PlayMedia(@"D:\Downloads\TorrentDay\Blue Planet II\Season 1\Blue Planet II - S01E04 - Big Blue WEBDL-1080p.mkv");

            return Ok();
        }
    }
}