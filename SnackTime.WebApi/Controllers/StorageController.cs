using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SnackTime.WebApi.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        [HttpGet("")]
        public async Task<ActionResult> GetDriveInfo()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                Console.WriteLine($"{drive.Name}, {drive.TotalSize / (1024 * 1024 * 1024)}/{drive.AvailableFreeSpace / (1024 * 1024 * 1024)}");
            }


            return Ok(DriveInfo.GetDrives().Select(info => new Drive
            {
                Name = info.Name,
                TotalSize = info.TotalSize,
                AvailableFreeSize = info.AvailableFreeSpace
            }));
        }

        [HttpGet("size")]
        public async Task<ActionResult> Size()
        {
            var tempDirInfo = new DirectoryInfo(@"D:\SnackTime\temp");
            var globalDirInfo = new DirectoryInfo(@"D:\SnackTime\");

            var tempDirSize = tempDirInfo.EnumerateFiles().Sum(file => file.Length);
            var totalSize = globalDirInfo.EnumerateFiles().Sum(file => file.Length);
            var filesSize = totalSize - tempDirSize;
            return Ok(new {TempDir = tempDirSize, TotalSize = totalSize, FileSize = filesSize});
        }
    }

    public class Drive
    {
        public long   TotalSize         { get; set; }
        public long   AvailableFreeSize { get; set; }
        public string Name              { get; set; }
    }
}