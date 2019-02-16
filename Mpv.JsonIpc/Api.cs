using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Mpv.JsonIpc
{
    public class Api
    {
        private readonly Ipc _ipc;

        public Api(Ipc ipc)
        {
            _ipc = ipc;
        }

        public async Task ShowText(string text, TimeSpan duration)
        {
            var request = _ipc.CreateCommand(new[] {"show-text", text}, duration.TotalMilliseconds.ToString(CultureInfo.InvariantCulture));
            await _ipc.ExecuteCommand<string>(request);
        }

        public async Task<float> GetVolume()
        {
            var result = await _ipc.GetProperty<float>(Property.Volume);
            return result.Data;
        }
    }

    public class Ipc
    {
        private readonly Manager _manager;

        public Ipc(Manager manager)
        {
            _manager = manager;
        }

        public async Task<Response<T>> ExecuteCommand<T>(Request request)
        {
            return await _manager.Execute<T>(request);
        }

        public async Task<Response<T>> GetProperty<T>(Property property, params string[] args)
        {
            var request = CreateCommand(new[] {"get_property", property.GetStringValue()}, args);
            return await _manager.Execute<T>(request);
        }

        public async Task<Response<T>> SetProperty<T>(Property property, params object[] args)
        {
            var request = CreateCommand(new[] {"set_property", property.GetStringValue()}, args);
            return await _manager.Execute<T>(request);
        }

        public async Task<Response<T>> SetPropertyString<T>(Property property, params string[] args)
        {
            var request = CreateCommand(new[] {"set_property_string", property.GetStringValue()}, args);
            return await _manager.Execute<T>(request);
        }

        public async Task<Response<T>> CycleProperty<T>(Property property)
        {
            var request = CreateCommand(new[] {"cycle", property.GetStringValue()});
            return await _manager.Execute<T>(request);
        }

        public Request CreateCommand(IEnumerable<object> command)
        {
            return CreateCommand(command, Array.Empty<object>());
        }
        
        public Request CreateCommand(IEnumerable<object> command, object arg)
        {
            return CreateCommand(command, new[] {arg});
        }

        public Request CreateCommand(IEnumerable<object> command, IEnumerable<object> args)
        {
            return new Request
            {
                Command = command.Concat(args).ToArray(),
                RequestId = GenerateNewRequestId(),
            };
        }


        private static int GenerateNewRequestId()
        {
            return 10;
//            return _random.Next(0, 10000);
        }
    }
}