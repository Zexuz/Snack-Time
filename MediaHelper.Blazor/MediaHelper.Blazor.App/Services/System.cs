using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}