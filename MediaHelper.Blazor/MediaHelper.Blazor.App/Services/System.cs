using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MediaHelper.Model;
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

        public async Task<FileExploror> GetFoldersAndDirectorys(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            return await _client.GetJsonAsync<FileExploror>($"System/filesystem/{encodedPath}");
        }

        public async Task  UpdateMpcHcLocation(string path)
        {
            var encodedPath = WebUtility.UrlEncode(path);
            await _client.PutAsync($"System/mpchc/{encodedPath}",null);
        }
    }
}