using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MediaHelper.Blazor.App.Models;
using MediaHelper.Model;

namespace MediaHelper.Blazor.App.Services
{
    public class FileNavigationService
    {
        private readonly SystemEndpoint _systemEndpoint;

        private static readonly Regex FirstLevel = new Regex(@"[A-z]:\\[^\\]+");
        private static readonly Regex DriveLevel = new Regex(@"^[A-z]:\\$");

        public FileNavigationService(ApiClient apiClient)
        {
            _systemEndpoint = apiClient.SystemEndpoint;
        }

        public async Task<FileExploror> GotoPath(string path)
        {
            return await _systemEndpoint.GetFoldersAndDirectorys(path);
        }
        
        public async Task<string[]> GetSystemDrives()
        {
            return await _systemEndpoint.GetSystemDrives();
        }

        public async Task<BackResponse> Back(string currentFilePath)
        {
            if (!CanGoBack(currentFilePath))
                return new BackResponse
                {
                    NewPath = currentFilePath,
                    FileExploror = new FileExploror {Dirs = await _systemEndpoint.GetSystemDrives()}
                };

            if (currentFilePath.Last() == '\\')
                currentFilePath = currentFilePath.Remove(currentFilePath.Length - 1);

            var index = currentFilePath.LastIndexOf("\\", StringComparison.Ordinal);
            var path = currentFilePath.Substring(0, index + 1);

            return new BackResponse
            {
                NewPath = path,
                FileExploror = await _systemEndpoint.GetFoldersAndDirectorys(path)
            };
        }

        public bool CanGoBack(string currentFilePath)
        {
            return FirstLevel.IsMatch(currentFilePath);
        }

        public bool IsCurrentDrivePath(string currentFilePath)
        {
            return DriveLevel.IsMatch(currentFilePath);
        }
      
    }
}