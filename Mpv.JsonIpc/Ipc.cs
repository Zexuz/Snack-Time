using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mpv.JsonIpc
{
    public class Ipc : IIpc
    {
        private readonly IManager _manager;

        public Ipc(IManager manager)
        {
            _manager = manager;
        }

        public async Task<Response<T>> GetProperty<T>(Property property, params string[] args)
        {
            var request = CreateCommand(new[] {"get_property", property.GetStringValue()}, args);
            return await ExecuteCommand<T>(request);
        }

        public async Task<Response<T>> SetProperty<T>(Property property, params object[] args)
        {
            var request = CreateCommand(new[] {"set_property", property.GetStringValue()}, args);
            return await ExecuteCommand<T>(request);
        }

        public async Task<Response<T>> SetPropertyString<T>(Property property, params string[] args)
        {
            var request = CreateCommand(new[] {"set_property_string", property.GetStringValue()}, args);
            return await ExecuteCommand<T>(request);
        }

        public async Task<Response<T>> CycleProperty<T>(Property property)
        {
            var request = CreateCommand(new[] {"cycle", property.GetStringValue()});
            return await ExecuteCommand<T>(request);
        }

        public Request CreateCommand(IEnumerable<object> command)
        {
            return CreateCommand(command, Array.Empty<object>());
        }

        public Request CreateCommand(IEnumerable<object> command, object arg)
        {
            return CreateCommand(command, new[] {arg});
        }

        public async Task<Response<T>> ExecuteCommand<T>(Request request)
        {
            return await _manager.Execute<T>(request);
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