using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Mpv.JsonIpc.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeFactory = new NamedPipeFactory();

            
            using (var manager = new Manager(pipeFactory))
            {
                var api = new Api(manager);
                
                while (true)
                {
//                    var volume = api.GetVolume().Result;
//                    Console.WriteLine($"The volume is {volume}");
                    api.ShowText("Robin",TimeSpan.FromSeconds(10)).Wait();
                    Thread.Sleep(5000);
                }
            }
        }
    }

    public class Api
    {
        private readonly Manager _manager;

        public Api(Manager manager)
        {
            _manager = manager;
        }

        public async Task ShowText(string text, TimeSpan duration)
        {
            var request = new Request
            {
                Command = new[] {"show-text", text, duration.TotalMilliseconds.ToString(CultureInfo.InvariantCulture)},
                RequestId = 1337
            };
            

            await _manager.Execute<string>(request);
        }
        
        public async Task<float> GetVolume()
        {
            var result = await GetProperty<float>(Property.Volume);
            return result.Data;
        }
        
        private async Task<Response<T>> GetProperty<T>(Property property, params string[] args)
        {
            var request = new Request
            {
                Command = new[] {"get_property", property.GetStringValue()}.Concat(args).ToArray(),
                RequestId = 1337
            };
            

            return await _manager.Execute<T>(request);
        }
    }


    public enum Property
    {
        Volume
    }

    public static class PropertyEnumConverterExtension
    {
        private static readonly Dictionary<Property, string> Map = new Dictionary<Property, string>
        {
            {Property.Volume, "volume"}
        };

        public static string GetStringValue(this Property property)
        {
            return Map[property];
        }
    }
}