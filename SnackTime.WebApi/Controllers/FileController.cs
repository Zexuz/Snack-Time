using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mpv.JsonIpc;
using SnackTime.Core;
using SnackTime.Core.Media.Episodes;
using SnackTime.Core.Process;
using SnackTime.Core.Session;
using SnackTime.WebApi.Helpers;
using SnackTime.WebApi.Services;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FileDownloadService _fileDownloadService;
        private readonly FileService _fileService;

        public FileController(FileDownloadService fileDownloadService, FileService fileService)
        {
            _fileDownloadService = fileDownloadService;
            _fileService = fileService;
        }

        [HttpGet("download/{mediaFileIdStr}")]
        public async Task<ActionResult> DownloadFile(string mediaFileIdStr)
        {
            if (!MediaFileId.TryParse(mediaFileIdStr, out var mediaFileId))
                return BadRequest($"{nameof(mediaFileIdStr)} is invalid");

            await _fileDownloadService.DownloadFile(mediaFileId);
            return StatusCode(202);
        }

        [HttpGet("downloads")]
        public ActionResult GetLocalFiles()
        {
            var localFilePaths = _fileService.GetLocalFiles();
            return Ok(ApiResponseFactory.CreateSuccess(localFilePaths));
        }
    }
}