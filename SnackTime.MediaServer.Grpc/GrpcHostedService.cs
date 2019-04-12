using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using SnackTime.MediaServer.ProtoGenerated;

namespace SnackTime.MediaServer.Grpc
{
    public class GrpcHostedService : IHostedService
    {
        private readonly Server _server;

        public GrpcHostedService(
            ServerPort serverPort,
            Greeter.GreeterBase greeterImpl,
            Service.Series.Series.SeriesBase seriesImpl
        )
        {
            var server = new Server
            {
                Services =
                {
                    Greeter.BindService(greeterImpl),
                    Service.Series.Series.BindService(seriesImpl)
                },
                Ports = {serverPort}
            };

            _server = server;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _server.Start();

            foreach (var serverPort in _server.Ports)
            {
                Console.WriteLine($"gRPC Server listening on {serverPort.Host}:{serverPort.Port}");
            }

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken) => await _server.ShutdownAsync();
    }
}