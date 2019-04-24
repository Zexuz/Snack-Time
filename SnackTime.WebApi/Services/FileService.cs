using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SnackTime.App.Settings.ProtoGenerated;
using SnackTime.Core.Settings;

namespace SnackTime.WebApi.Services
{
    public class FileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly SettingsService _settingsService;

        public FileService(ILogger<FileService> logger, SettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        public async Task CombineMultipleFilesIntoSingleFile(
            string inputDirectoryPath,
            string filePattern,
            string outputFilePath,
            bool removeWhenComplete = true
        )
        {
            var filePaths = GetFilesInPath(inputDirectoryPath, filePattern);
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
        
        public string[] GetLocalFiles()
        {
            var fileDir = _settingsService.Get().System.FileDir;
            if (string.IsNullOrWhiteSpace(fileDir))
            {
                throw new Exception($"The settings prop {nameof(LocalSystem.FileDir)} has not been set");
            }


            return GetFilesInPath(fileDir);
        }

        private static string[] GetFilesInPath(string path, string pattern = "*")
        {
            return Directory.GetFiles(path, pattern);
        }
        
       
    }
}