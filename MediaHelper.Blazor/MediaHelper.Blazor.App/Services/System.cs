using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Newtonsoft.Json;

namespace MediaHelper.Blazor.App.Services
{
    public class System
    {
        private readonly HttpClient _client;

        public System(HttpClient client)
        {
            _client = client;
        }

        public async Task OpenFile(int episodeFileId, TimeSpan timeSpan)
        {
            await _client.PostAsync($"System/Open/{episodeFileId}?fromSeconds={Math.Floor(timeSpan.TotalSeconds)}", null);
        }

        public async Task<string[]> GetSystemDrives()
        {
            var data = await _client.GetStringAsync("System/filesystem/drives");
            return JsonConvert.DeserializeObject<string[]>(data);
        }

        public async Task<string[]> GetFoldersAndDirectorys(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            return await _client.GetJsonAsync<string[]>($"System/filesystem/{encodedPath}");
        }
    }

    public class FileNavigationService
    {
        private readonly System _system;

        private static readonly Regex FirstLevel = new Regex(@"[A-z]:\\[^\\]+");
        private static readonly Regex DriveLevel = new Regex(@"^[A-z]:\\$");

        public FileNavigationService(ApiClient apiClient)
        {
            _system = apiClient.System;
        }

        public async Task<string[]> GotoPath(string path)
        {
            return await _system.GetFoldersAndDirectorys(path);
        }

        public async Task<BackResponse> Back(string currentFilePath)
        {
            if (!CanGoBack(currentFilePath))
                return new BackResponse
                {
                    NewPath = currentFilePath,
                    Dirs = await _system.GetSystemDrives()
                };

            if(currentFilePath.Last() == '\\')
                currentFilePath = currentFilePath.Remove(currentFilePath.Length - 1);
            
            var index = currentFilePath.LastIndexOf("\\", StringComparison.Ordinal);
            var path = currentFilePath.Substring(0, index + 1);
            
            return new BackResponse
            {
                NewPath = path,
                Dirs = await _system.GetFoldersAndDirectorys(path)
            };
        }

        public bool CanGoBack(string currentFilePath)
        {
            return FirstLevel.IsMatch(currentFilePath);
            if (string.IsNullOrEmpty(currentFilePath))
                return false;
            
            return currentFilePath.Count(f => f == '/') == 2; //Blazor can't run the RegEx code ¯\_(ツ)_/¯
        }

        public bool IsCurrentDrivePath(string currentFilePath)
        {
            return DriveLevel.IsMatch(currentFilePath);
            if (string.IsNullOrEmpty(currentFilePath))
                return true;
            
            return currentFilePath.Count(f => f == '/') == 1;
        }
    }

    public struct BackResponse
    {
        public string[] Dirs { get; set; }
        public string NewPath { get; set; }
    }
}