using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mpv.JsonIpc
{
    public sealed class Manager : IDisposable, IManager
    {
        private readonly NamedPipeClientStream _pipe;

        private StreamReader _pipeIn;
        private StreamWriter _pipeOut;

        public Manager(INamedPipeFactory pipeFactory)
        {
            _pipe = pipeFactory.CreateNamedPipe();
        }

        public async Task<Response<T>> Execute<T>(Request message)
        {
            if (!_pipe.IsConnected)
            {
                _pipe.Connect();
                _pipeIn = new StreamReader(_pipe);
                _pipeOut = new StreamWriter(_pipe) {AutoFlush = true};
            }

            var messageToSend = JsonConvert.SerializeObject(message);
            Console.WriteLine(messageToSend);
            _pipeOut.WriteLine(messageToSend);

            var readLineTask = _pipeIn.ReadLineAsync();


            const int timeout = 1000;
            if (await Task.WhenAny(readLineTask, Task.Delay(timeout)) != readLineTask)
            {
                return new Response<T>
                {
                    Data = default(T),
                    Error = $"Got a timeout after {timeout}ms",
                    RequestId = -1
                };
            }

            var messageReceived = readLineTask.Result;
            Console.WriteLine(messageReceived);
            return JsonConvert.DeserializeObject<Response<T>>(messageReceived);
        }

        public void Dispose()
        {
            _pipe.Dispose();
        }
    }
}