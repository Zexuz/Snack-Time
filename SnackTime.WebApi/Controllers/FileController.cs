using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Media.Episodes;
using SnackTime.Core.Process;
using SnackTime.Core.Session;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileDownloadService _fileDownloadService;

        public FileController(FileDownloadService fileDownloadService)
        {
            _fileDownloadService = fileDownloadService;
        }

        [HttpGet("download/{mediaFileIdStr}")]
        public async Task<ActionResult> DownloadFile(string mediaFileIdStr)
        {
            if (!MediaFileId.TryParse(mediaFileIdStr, out var mediaFileId))
                return BadRequest($"{nameof(mediaFileIdStr)} is invalid");
            
            await _fileDownloadService.DownloadFile(mediaFileId);
            return StatusCode(202);
        }
    }
}