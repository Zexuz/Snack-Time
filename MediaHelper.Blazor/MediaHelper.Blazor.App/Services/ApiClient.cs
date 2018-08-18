using System;
using System.Net.Http;

namespace MediaHelper.Blazor.App.Services
{
    public class ApiClient
    {
        public Series  Series  { get; }
        public SystemEndpoint  SystemEndpoint  { get; }
        public Episode Episode { get; }
        public History History { get; }


        public ApiClient(string baseUrl)
        {
            var client = new HttpClient {BaseAddress = new Uri(baseUrl)};


            Series = new Series(client);
            SystemEndpoint = new SystemEndpoint(client);
            Episode = new Episode(client);
            History = new History(client);
        }
    }
}