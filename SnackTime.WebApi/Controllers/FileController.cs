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

        [HttpGet("download")]
        public async Task<ActionResult> DownloadFile()
        {
            await _fileDownloadService.DownloadFile();
            return StatusCode(202);
        }
    }
}