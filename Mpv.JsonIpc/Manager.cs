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

        private StreamReader _pipeReader;
        private StreamWriter _pipeWriter;

        public Manager(INamedPipeFactory pipeFactory)
        {
            _pipe = pipeFactory.CreateNamedPipe();
        }

        //If we ever want to listen to random MPV actions, we can always just create a sepperate pipe for that.
        //So one pipe for sending/receiving RPC call, and one just to read/oberser events from properties 
        public async Task<Response<T>> Execute<T>(Request request)
        {
            if (!_pipe.IsConnected)
            {
                _pipe.Connect();

                _pipeReader = new StreamReader(_pipe);
                _pipeWriter = new StreamWriter(_pipe);
            }

            var messageToSend = JsonConvert.SerializeObject(request);
            await _pipeWriter.WriteLineAsync(messageToSend);
            await _pipeWriter.FlushAsync();

            var counter = 0;
            while (true)
            {
                await Task.Delay(25);
                counter++;

                if (counter > 1000)
                {
                    throw new Exception("Retries maxed out");
                }


                var messageReceived = await _pipeReader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(messageReceived))
                {
                    continue;
                }

                var response = JsonConvert.DeserializeObject<Response<T>>(messageReceived);

                if (response.RequestId != request.RequestId)
                {
                    continue;
                }

                return response;
            }
        }

        public void Dispose()
        {
            _pipe.Dispose();
        }
    }
}