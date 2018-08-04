using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace MediaHelper.Blazor.App.Services
{
    public class ApiClient
    {
        private readonly string     _baseUrl;
        private          HttpClient _client;
        private          Series     _series;
        private          System     _system;

        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient {BaseAddress = new Uri(_baseUrl)};


            _series = new Series(_client);
            _system = new System(_client);
        }

        public Series Series => _series;
        public System System => _system;
    }

    public class Series
    {
        private readonly HttpClient _client;

        public Series(HttpClient client)
        {
            _client = client;
        }

        public async Task<SonarrSharp.Models.Series[]> GetAll()
        {
            return await _client.GetJsonAsync<SonarrSharp.Models.Series[]>("Series");
        }

        public async Task<SonarrSharp.Models.Episode[]> GetSeasons(int seriesId)
        {
            return await _client.GetJsonAsync<SonarrSharp.Models.Episode[]>($"Episode/{seriesId}");
        }
    }

    public class System
    {
        private readonly HttpClient _client;

        public System(HttpClient client)
        {
            _client = client;
        }

        public async Task OpenFile(int episodeFileId)
        {
            await _client.PostAsync($"System/Open/{episodeFileId}", null);
        }
    }
}