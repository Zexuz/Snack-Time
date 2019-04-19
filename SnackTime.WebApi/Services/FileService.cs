using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SnackTime.WebApi.Services
{
    public class FileService
    {
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task CombineMultipleFilesIntoSingleFile(
            string inputDirectoryPath,
            string filePattern,
            string outputFilePath,
            bool removeWhenComplete = true
        )
        {
            var filePaths = Directory.GetFiles(inputDirectoryPath, filePattern);
            _logger.LogDebug("Number of files: {0}.", filePaths.Length);
            using (var outputStream = File.Create(outputFilePath))
            {
                foreach (var filePath in filePaths)
                {
                    using (var inputStream = File.OpenRead(filePath))
                    {
                        await inputStream.CopyToAsync(outputStream);
                    }

                    _logger.LogDebug("The file {0} has been processed.", filePath);
                }
            }

            if (removeWhenComplete)
            {
                foreach (var filePath in filePaths)
                {
                    File.Delete(filePath);
                    _logger.LogDebug("Removed {0} ", filePath);
                }
            }
        }
    }
}