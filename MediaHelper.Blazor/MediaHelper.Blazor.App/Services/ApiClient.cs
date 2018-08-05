using System;
using System.Net.Http;

namespace MediaHelper.Blazor.App.Services
{
    public class ApiClient
    {
        public Series  Series  { get; }
        public System  System  { get; }
        public Episode Episode { get; }
        
        
        public ApiClient(string baseUrl)
        {
            var client = new HttpClient {BaseAddress = new Uri(baseUrl)};


            Series = new Series(client);
            System = new System(client);
            Episode = new Episode(client);
        }
    
    }
}