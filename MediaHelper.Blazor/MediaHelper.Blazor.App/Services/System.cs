using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MediaHelper.Model;
using Microsoft.AspNetCore.Blazor;
using Newtonsoft.Json;

namespace MediaHelper.Blazor.App.Services
{
    public class SystemEndpoint
    {
        private readonly HttpClient _client;

        public SystemEndpoint(HttpClient client)
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

        public async Task<FileExploror> GetFoldersAndDirectorys(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            return await _client.GetJsonAsync<FileExploror>($"System/filesystem/{encodedPath}");
        }

        public async Task UpdateMpcHcLocation(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            await _client.PutAsync($"System/mpchc/{encodedPath}", null);
        }

        public async Task<string> GetMpcHcLocation()
        {
            return await _client.GetStringAsync($"System/mpchc/");
        }

        public async Task UpdateSonarrLocation(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            await _client.PutAsync($"System/sonarr/{encodedPath}", null);
        }

        public async Task UpdateRadarrLocation(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            await _client.PutAsync($"System/radarr/{encodedPath}", null);
        }

        public async Task<string> GetRadarrLocation()
        {
            return await _client.GetStringAsync($"System/radarr/");
        }

        public async Task<string> GetSonarrLocation()
        {
            return await _client.GetStringAsync($"System/sonarr/");
        }
    }
}