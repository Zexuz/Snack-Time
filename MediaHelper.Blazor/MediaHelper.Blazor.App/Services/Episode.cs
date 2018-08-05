using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace MediaHelper.Blazor.App.Services
{
    public class Episode
    {
        private readonly HttpClient _client;

        public Episode(HttpClient client)
        {
            _client = client;
        }

        public async Task<SonarrSharp.Models.Episode[]> GetSeasons(int seriesId)
        {
            return await _client.GetJsonAsync<SonarrSharp.Models.Episode[]>($"Episode/{seriesId}");
        }
    }
}