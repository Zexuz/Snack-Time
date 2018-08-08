using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MediaHelper.Model;

namespace MediaHelper.Blazor.App.Services
{
    public class FileNavigationService
    {
        private readonly System _system;

        private static readonly Regex FirstLevel = new Regex(@"[A-z]:\\[^\\]+");
        private static readonly Regex DriveLevel = new Regex(@"^[A-z]:\\$");

        public FileNavigationService(ApiClient apiClient)
        {
            _system = apiClient.System;
        }

        public async Task<FileExploror> GotoPath(string path)
        {
            return await _system.GetFoldersAndDirectorys(path);
        }
        
        public async Task<string[]> GetSystemDrives()
        {
            return await _system.GetSystemDrives();
        }

        public async Task<BackResponse> Back(string currentFilePath)
        {
            if (!CanGoBack(currentFilePath))
                return new BackResponse
                {
                    NewPath = currentFilePath,
                    FileExploror = new FileExploror {Dirs = await _system.GetSystemDrives()}
                };

            if (currentFilePath.Last() == '\\')
                currentFilePath = currentFilePath.Remove(currentFilePath.Length - 1);

            var index = currentFilePath.LastIndexOf("\\", StringComparison.Ordinal);
            var path = currentFilePath.Substring(0, index + 1);

            return new BackResponse
            {
                NewPath = path,
                FileExploror = await _system.GetFoldersAndDirectorys(path)
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